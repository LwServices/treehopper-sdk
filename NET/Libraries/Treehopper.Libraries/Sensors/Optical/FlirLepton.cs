﻿using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Treehopper.Libraries.Sensors.Optical
{
    /// <summary>
    ///     FLIR Lepton
    /// </summary>
    [Supports("FLIR", "Lepton")]
    public class FlirLepton
    {
        private readonly ushort[,] blackFrame;

        private readonly int height = 60;
        private readonly int width = 80;
        private SpiDevice dev;
        SpiChipSelectPin cs;
        /// <summary>
        ///     Construct a FLIR Lepton
        /// </summary>
        /// <param name="spi">The Spi module to use</param>
        public FlirLepton(Spi spi, SpiChipSelectPin cs)
        {
            this.dev = new SpiDevice(spi, cs, ChipSelectMode.SpiActiveLow, 6, SpiMode.Mode11);
            this.cs = cs;

            blackFrame = new ushort[height, width];
            for (var i = 0; i < height; i++)
            for (var j = 0; j < width; j++)
                blackFrame[i, j] = 0xffff;
        }

        /// <summary>
        ///     Get the raw frame from the sensor
        /// </summary>
        /// <returns>An awaitable 2D-array of values</returns>
        public async Task<ushort[,]> GetRawFrameAsync()
        {
            //cs.DigitalValue = false;
            //await Task.Delay(185).ConfigureAwait(false);
            //cs.DigitalValue = true;
            var frame = new ushort[height, width];
            var frameAcquired = false;
            var syncAcquired = false;
            while (!frameAcquired)
            {
                syncAcquired = false;
                ushort[] packet = new ushort[1];
                while (!syncAcquired)
                {
                    packet = await GetPacketAsync().ConfigureAwait(false);
                    if ((packet[0] & 0x000f) != 0x000f) // check ID
                    {
                        syncAcquired = true;
                    }
                        
                }
                for (var i = 0; i < height; i++)
                {
                    if ((packet[0] & 0x000f) == 0x000f)
                    {
                        // lost sync
                        frameAcquired = true;
                        break;
                    }

                    for (var j = 0; j < width; j++)
                        frame[i, j] = packet[j+2];
                    if (i == height - 1)
                    {
                        frameAcquired = true;
                    }
                        
                    packet = await GetPacketAsync().ConfigureAwait(false);
                }
            }

            return frame;
        }

//#if WINDOWS_UWP
//        public async Task<WriteableBitmap> GetFrame()
//        {
//            WriteableBitmap frame  = new WriteableBitmap(width, height);
//            var correctedFrame = await GetCorrectedRasterFrameArray();
//            byte[] correctedArgbFrame = new byte[width * height * 4];
//            for (int i=0;i<width*height;i++)
//            {
//                correctedArgbFrame[i * 4 + 0] = correctedFrame[i];
//                correctedArgbFrame[i * 4 + 1] = correctedFrame[i];
//                correctedArgbFrame[i * 4 + 2] = correctedFrame[i];
//                correctedArgbFrame[i * 4 + 3] = 0xff;
//            }
//            await frame.PixelBuffer.AsStream().WriteAsync(correctedArgbFrame, 0, correctedArgbFrame.Length);
//            return frame;
//        }
//#else
//        public async Task<WriteableBitmap> GetFrame()
//        {
//            WriteableBitmap frame = new WriteableBitmap(80, 60, 300, 300, PixelFormats.Gray8, null);
//            var correctedFrame = await GetCorrectedRasterFrameArray();
//            frame.WritePixels(new Int32Rect(0, 0, 80, 60), correctedFrame, 1, 0);
//            return frame;
//        }
//#endif

        /// <summary>
        ///     Get the corrected raster frame
        /// </summary>
        /// <returns>A byte[] raster</returns>
        public async Task<byte[]> GetCorrectedRasterFrameArrayAsync()
        {
            var rawFrame = await GetRawFrameAsync();
            ushort maxVal = 0;
            var minVal = ushort.MaxValue;
            for (var i = 0; i < height; i++)
            for (var j = 0; j < width; j++)
            {
                if (rawFrame[i, j] > maxVal)
                    maxVal = rawFrame[i, j];
                if (rawFrame[i, j] < minVal)
                    minVal = rawFrame[i, j];
            }

            var range = maxVal - minVal;

            //Debug.WriteLine("max val: " + maxVal);
            //Debug.WriteLine("min val: " + minVal);

            var factor = 255.0 / range;

            var correctedFrame = new byte[width * height];

            for (var i = 0; i < height; i++)
            for (var j = 0; j < width; j++)
                correctedFrame[i * width + j] = (byte) (rawFrame[i, j] / 256);

            return correctedFrame;
        }

        private async Task<ushort[]> GetPacketAsync()
        {
            var data = await dev.SendReceiveAsync(new byte[164], SpiBurstMode.BurstRx).ConfigureAwait(false);
            ushort[] packet = new ushort[82];
            
            Buffer.BlockCopy(data, 0, packet, 0, 164);
            //byte[] data = await spi.SendReceive(new byte[164]);
            //IntPtr buffer = Marshal.AllocHGlobal(rawsize);
            //Marshal.Copy(data, 0, buffer, rawsize);
            //return Marshal.PtrToStructure<VoSPI>(buffer);
            return packet;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 164)]
        private struct VoSPI
        {
            public readonly ushort Id;

            public readonly ushort Crc;

            //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 80)]
            public ushort[] Payload;
        }
    }

    internal static class Crc16
    {
        private const ushort polynomial = 0xA001;
        private static readonly ushort[] table = new ushort[256];

        static Crc16()
        {
            ushort value;
            ushort temp;
            for (ushort i = 0; i < table.Length; ++i)
            {
                value = 0;
                temp = i;
                for (byte j = 0; j < 8; ++j)
                {
                    if (((value ^ temp) & 0x0001) != 0)
                        value = (ushort) ((value >> 1) ^ polynomial);
                    else
                        value >>= 1;
                    temp >>= 1;
                }
                table[i] = value;
            }
        }

        public static ushort ComputeChecksum(byte[] bytes)
        {
            ushort crc = 0;
            for (var i = 0; i < bytes.Length; ++i)
            {
                var index = (byte) (crc ^ bytes[i]);
                crc = (ushort) ((crc >> 8) ^ table[index]);
            }
            return crc;
        }
    }
}