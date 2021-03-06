﻿using System;
using System.Threading.Tasks;
using Treehopper.Libraries.IO.PortExpander;
using Treehopper.Libraries.Utilities;

namespace Treehopper.Libraries.Displays
{
    /// <summary>
    ///     Seeed Studio Grove I2c LCD with RGB backlight
    /// </summary>
    public class GroveI2cLcd : Hd44780
    {
        private readonly Pca9632 backlight;

        public GroveI2cLcd(I2C i2c) : base(new I2cParallelInterface(i2c), 16, 2)
        {
            // It's undocumented, but the Grove I2C LCD uses a PCA9632 for the RGB backlight
            backlight = new Pca9632(i2c);
        }

        public Task SetBacklight(Color color)
        {
            return SetBacklight(color.R, color.G, color.B);
        }

        public Task SetBacklight(int red, int green, int blue)
        {
            var redFixed = (byte) Math.Round(Utility.BrightnessToCieLuminance(red / 255d) * 255);
            var greenFixed = (byte) Math.Round(Utility.BrightnessToCieLuminance(green / 255d) * 255);
            var blueFixed = (byte) Math.Round(Utility.BrightnessToCieLuminance(blue / 255d) * 255);
            return backlight.SetOutputs(new byte[] {blueFixed, greenFixed, redFixed, 0x00});
        }

        private class I2cParallelInterface : WriteOnlyParallelInterface
        {
            private readonly SMBusDevice dev;

            public I2cParallelInterface(I2C i2c)
            {
                dev = new SMBusDevice(0x3e, i2c);
            }

            public int DelayMicroseconds { get; set; }

            public bool Enabled { get; set; }

            public int Width => 8;

            public Task WriteCommandAsync(uint[] command)
            {
                var bytes = new byte[command.Length];

                for (var i = 0; i < command.Length; i++)
                    bytes[i] = (byte) command[i];

                return dev.WriteBufferDataAsync(0x80, bytes);
            }

            public Task WriteDataAsync(uint[] data)
            {
                var bytes = new byte[data.Length];

                for (var i = 0; i < data.Length; i++)
                    bytes[i] = (byte) data[i];

                return dev.WriteBufferDataAsync(0x40, bytes);
            }
        }
    }
}