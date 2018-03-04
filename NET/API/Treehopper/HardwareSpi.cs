﻿using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Treehopper.Utilities;

namespace Treehopper
{
    /// <summary>
    ///     Provides access to SPI communication.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Treehopper is capable of communicating with many devices equipped with serial peripheral interface (SPI)
    ///         communication.
    ///         SPI is a full-duplex synchronous serial communication standard that uses four pins:
    ///         <list type="number">
    ///             <item>
    ///                 <term>MISO</term>
    ///                 <description>
    ///                     Short for "Master In, Slave Out." This pin carries data from the device to the Treehopper.
    ///                     It is on pin 1
    ///                 </description>
    ///             </item>
    ///             <item>
    ///                 <term>MOSI</term>
    ///                 <description>
    ///                     Short for "Master Out, Slave In." This pin carries data from the Treehopper to the device.
    ///                     It is on pin 2
    ///                 </description>
    ///             </item>
    ///             <item>
    ///                 <term>SCK</term>
    ///                 <description>
    ///                     Short for "Serial Clock." This pin carries the clock signal from the Treehopper to the
    ///                     device. It is on pin 0
    ///                 </description>
    ///             </item>
    ///             <item>
    ///                 <term>CS</term>
    ///                 <description>
    ///                     Short for "Chip Select." Treehopper asserts this pin when communication begins, and
    ///                     de-asserts when communication is done.
    ///                 </description>
    ///             </item>
    ///         </list>
    ///         The SPI specification allows for many different configuration options, so the datasheet for the device must be
    ///         consulted to determine the communication rate, the
    ///         clock phase and polarity, as well as the chip select polarity. Not all devices use all pins, but the SPI
    ///         peripheral will always allocate the SCK, MISO, and MOSI pin once the peripheral is enabled.
    ///     </para>
    ///     <para>
    ///         The clock rate to operate the SPI bus at is specified by the
    ///         <see cref="SendReceiveAsync(byte[], SpiChipSelectPin, ChipSelectMode, double, SpiBurstMode, SpiMode)" /> function.
    ///         The minimum clock rate is 93.75 kHz (0.093.75 MHz), while the maximum clock rate is 24 MHz, but there are no
    ///         performance gains above 6 MHz. Since Treehopper's MCU has no internal DMA, bytes are placed into the SPI buffer
    ///         one by one by the processor; it takes 8 cycles to perform this operation, and since the processor runs at 48
    ///         MHz, the fastest effective data transfer rate is 6 MHz.
    ///     </para>
    ///     <para>
    ///         Many simple devices that contain shift registers may also be interfaced with using the SPI module. The
    ///         <see cref="ChipSelectMode" /> configuration contains pulse modes compatible with these devices.
    ///     </para>
    ///     <para>
    ///         Before implementing SPI communication for a given device, check the Treehopper.Libraries assembly, which
    ///         contains support for popular hobbyist devices, as well as generic
    ///         shift registers and latches.
    ///     </para>
    /// </remarks>
    public class HardwareSpi : Spi
    {
        private readonly TreehopperUsb _device;
        private bool _enabled;

        internal HardwareSpi(TreehopperUsb device)
        {
            _device = device;
        }

        private Pin Sck => _device.Pins[0];

        private Pin Miso => _device.Pins[1];

        private Pin Mosi => _device.Pins[2];

        /// <summary>
        ///     Enable or disable the SPI module.
        /// </summary>
        /// <remarks>
        ///     When enabled, the MOSI, MISO, and SCK pins become reserved, and cannot be used for digital or analog operations.
        ///     When disabled, these pins return to an unassigned state.
        /// </remarks>
        public bool Enabled
        {
            get { return _enabled; }

            set
            {
                if (_enabled == value) return;
                _enabled = value;

                SendConfig();

                if (_enabled)
                {
                    Mosi.Mode = PinMode.Reserved;
                    Miso.Mode = PinMode.Reserved;
                    Sck.Mode = PinMode.Reserved;
                }
                else
                {
                    Mosi.Mode = PinMode.Unassigned;
                    Miso.Mode = PinMode.Unassigned;
                    Sck.Mode = PinMode.Unassigned;
                }
            }
        }

        /// <summary>
        ///     Send/receive data
        /// </summary>
        /// <param name="dataToWrite">
        ///     a byte array of the data to send. The length of the transaction is determined by the length
        ///     of this array.
        /// </param>
        /// <param name="chipSelect">The chip select pin, if any, to use during this transaction.</param>
        /// <param name="chipSelectMode">The chip select mode to use during this transaction (if a CS pin is selected)</param>
        /// <param name="speedMhz">The speed to perform this transaction at.</param>
        /// <param name="burstMode">Whether to use one of the burst modes</param>
        /// <param name="spiMode">The SPI mode to use during this transaction.</param>
        /// <returns>An awaitable byte array with the received data.</returns>
        public async Task<byte[]> SendReceiveAsync(byte[] dataToWrite, SpiChipSelectPin chipSelect = null,
            ChipSelectMode chipSelectMode = ChipSelectMode.SpiActiveLow, double speedMhz = 6,
            SpiBurstMode burstMode = SpiBurstMode.NoBurst, SpiMode spiMode = SpiMode.Mode00)
        {
            var transactionLength = dataToWrite.Length;
            var returnedData = new byte[transactionLength];

            if (Enabled != true)
                Utility.Error("SPI module must be enabled before starting transaction", true);

            if (chipSelect != null && chipSelect.SpiModule != this)
                Utility.Error("Chip select pin must belong to this SPI module", true);

            using (await _device.ComsLock.LockAsync().ConfigureAwait(false))
            {
                var spi0Ckr = (int) Math.Round(24.0 / speedMhz - 1);
                if (spi0Ckr > 255.0)
                {
                    spi0Ckr = 255;
                    Debug.WriteLine(
                        "NOTICE: Requested SPI frequency of {0} MHz is below the minimum frequency, and will be clipped to 0.09375 MHz (93.75 kHz).",
                        speedMhz);
                }
                else if (spi0Ckr < 0)
                {
                    spi0Ckr = 0;
                    Debug.WriteLine(
                        "NOTICE: Requested SPI frequency of {0} MHz is above the maximum frequency, and will be clipped to 24 MHz.",
                        speedMhz);
                }

                var actualFrequency = 48.0 / (2.0 * (spi0Ckr + 1.0));

                if (Math.Abs(actualFrequency - speedMhz) > 1)
                    Debug.WriteLine(
                        "NOTICE: SPI module actual frequency of {0} MHz is more than 1 MHz away from the requested frequency of {1} MHz",
                        actualFrequency, speedMhz);

                if (dataToWrite.Length > 255)
                    throw new Exception("Maximum packet length is 255 bytes");

                var header = new byte[7];
                header[0] = (byte) DeviceCommands.SpiTransaction;
                header[1] = (byte) (chipSelect?.PinNumber ?? 255);
                header[2] = (byte) chipSelectMode;
                header[3] = (byte) spi0Ckr;
                header[4] = (byte) spiMode;
                header[5] = (byte) burstMode;
                header[6] = (byte) transactionLength;

                // just send the header
                if (burstMode == SpiBurstMode.BurstRx)
                {
                    await _device.SendPeripheralConfigPacketAsync(header).ConfigureAwait(false);
                }
                else
                {
                    var dataToSend = new byte[transactionLength + header.Length];
                    Array.Copy(header, dataToSend, header.Length);
                    Array.Copy(dataToWrite, 0, dataToSend, header.Length, transactionLength);

                    var bytesRemaining = dataToSend.Length;
                    var offset = 0;
                    while (bytesRemaining > 0)
                    {
                        var transferLength = bytesRemaining > 64 ? 64 : bytesRemaining;
                        var tmp = dataToSend.Skip(offset).Take(transferLength);
                        await _device.SendPeripheralConfigPacketAsync(tmp.ToArray()).ConfigureAwait(false);
                        offset += transferLength;
                        bytesRemaining -= transferLength;
                    }
                }

                // no need to wait if we're not reading anything
                if (burstMode != SpiBurstMode.BurstTx)
                {
                    var bytesRemaining = transactionLength;
                    var srcIndex = 0;
                    while (bytesRemaining > 0)
                    {
                        var numBytesToTransfer = bytesRemaining > 64 ? 64 : bytesRemaining;
                        var receivedData = await _device.ReceiveCommsResponsePacketAsync((uint) numBytesToTransfer)
                            .ConfigureAwait(false);
                        Array.Copy(receivedData, 0, returnedData, srcIndex,
                            receivedData.Length); // just in case we don't get what we're expecting
                        srcIndex += numBytesToTransfer;
                        bytesRemaining -= numBytesToTransfer;
                    }
                }
            }

            return returnedData;
        }

        /// <summary>
        ///     Gets a string representing the SPI peripheral's state
        /// </summary>
        /// <returns>the state of the SPI peripheral</returns>
        public override string ToString()
        {
            if (Enabled)
                return "Enabled";
            return "Not enabled";
        }

        private void SendConfig()
        {
            var dataToSend = new byte[2];
            dataToSend[0] = (byte) DeviceCommands.SpiConfig;
            dataToSend[1] = (byte) (_enabled ? 0x01 : 0x00);
            _device.SendPeripheralConfigPacketAsync(dataToSend);
        }
    }
}