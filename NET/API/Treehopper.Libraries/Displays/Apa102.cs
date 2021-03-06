﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Treehopper.Libraries.IO;
using Treehopper.Libraries.Utilities;
using Treehopper.Utilities;

namespace Treehopper.Libraries.Displays
{
    /// <summary>
    ///     Shiji Lighting Co. iPixel APA102 (DotStar) Smart RGB LED
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         The APA102
    ///     </para>
    /// </remarks>
    [Supports("Shiji Lighting Co.", "iPixel APA102C")]
    public class Apa102 : IFlushable
    {
        private readonly Spi spi;
        private double freq;

        /// <summary>
        ///     Construct a new chain of APA102-based smart LEDs.
        /// </summary>
        /// <param name="spi">The SPI port to use</param>
        /// <param name="numLeds">The number of APA102 smart LEDs in this chain</param>
        /// <param name="frequency">The frequency to use</param>
        public Apa102(Spi spi, int numLeds, double frequency = 6)
        {
            this.spi = spi;
            spi.Enabled = true;
            this.freq = frequency;
            for (var i = 0; i < numLeds; i++)
                Leds.Add(new Led(this));
        }

        /// <summary>
        ///     Gets the LEDs belonging to this APA102 instance.
        /// </summary>
        public IList<Led> Leds { get; } = new List<Led>();

        /// <summary>
        ///     Gets or sets the global brightness of the LED strip
        /// </summary>
        public double Brightness { get; set; } = 1.0;

        /// <summary>
        ///     Whether this strip of LEDs should be updated immediately, or only when <see cref="FlushAsync(bool)" /> is called.
        /// </summary>
        public bool AutoFlush { get; set; } = true;

        /// <summary>
        ///     The parent Flushable interface.
        /// </summary>
        public IFlushable Parent => null;

        /// <summary>
        ///     Flush current LED values to the SPI bus to update the LEDs.
        /// </summary>
        /// <param name="force">Unused for this method</param>
        /// <returns>An awaitable task</returns>
        public async Task FlushAsync(bool force = false)
        {
            var header = new byte[] {0x00, 0x00, 0x00, 0x00};
            var bytes = new List<byte>();
            foreach (var led in Leds)
            {
                var global = (byte) (0xE0 | (byte) Math.Round(Brightness * 31));

                bytes.Add(global);
                bytes.Add((byte) Math.Round(255.0 * Utility.BrightnessToCieLuminance(led.blue / 255.0)));
                bytes.Add((byte) Math.Round(255.0 * Utility.BrightnessToCieLuminance(led.green / 255.0)));
                bytes.Add((byte) Math.Round(255.0 * Utility.BrightnessToCieLuminance(led.red / 255.0)));
            }

            // still experimenting with this
            for (var i = 0; i < 5 + Leds.Count / 15; i++)
                bytes.Add(0x00);

            var message = header.Concat(bytes).ToArray();
            //var footer = new byte[] {0xff, 0xff, 0xff, 0xff };
            //message = message.Concat(footer).ToArray();

            var chunkCount = 0;
            while (true)
            {
                var chunk = message.Skip(chunkCount * 255).Take(255).ToArray();
                if (chunk.Length == 0)
                    break;

                await spi.SendReceiveAsync(chunk, null, ChipSelectMode.SpiActiveLow, freq, SpiBurstMode.BurstTx,
                    SpiMode.Mode11).ConfigureAwait(false);
                chunkCount++;
            }
        }

        /// <summary>
        ///     Clear the display immediately, resetting all LEDs' values.
        /// </summary>
        /// <returns>An awaitable task</returns>
        public async Task Clear()
        {
            var oldAutoFlush = AutoFlush;
            AutoFlush = false;
            Leds.ForEach(led => led.SetRgb(0, 0, 0));
            await FlushAsync().ConfigureAwait(false);
            AutoFlush = oldAutoFlush;
        }

        /// <summary>
        ///     Represents a single APA102 LED's value
        /// </summary>
        public class Led : IRgbLed
        {
            private readonly Apa102 driver;
            internal float red, green, blue;

            internal Led(Apa102 driver)
            {
                this.driver = driver;
            }

            /// <summary>
            ///     The red gain to apply
            /// </summary>
            public float RedGain { get; set; }

            /// <summary>
            ///     The green gain to apply
            /// </summary>
            public float GreenGain { get; set; }

            /// <summary>
            ///     The blue gain to apply
            /// </summary>
            public float BlueGain { get; set; }

            /// <summary>
            ///     Set the RGB value of this RGB LED
            /// </summary>
            /// <param name="red">The red intensity, from 0-255</param>
            /// <param name="green">The green intensity, from 0-255</param>
            /// <param name="blue">The blue intensity, from 0-255</param>
            public void SetRgb(float red, float green, float blue)
            {
                this.red = red;
                this.green = green;
                this.blue = blue;

                if (driver.AutoFlush)
                    driver.FlushAsync().Wait();
            }

            /// <summary>
            ///     Set the hue, saturation, and luminance of this RGB LED
            /// </summary>
            /// <param name="hue">The hue, from 0-360 degrees, of the desired color</param>
            /// <param name="saturation">The saturation, from 0-100, of the desired color</param>
            /// <param name="luminance">The luminance, from 0-100, of the desired color</param>
            public void SetHsl(float hue, float saturation, float luminance)
            {
                SetColor(Color.FromHsl(hue, saturation, luminance));
            }

            /// <summary>
            ///     Set the color of the RGB LED
            /// </summary>
            /// <param name="color">The desired color</param>
            public void SetColor(Color color)
            {
                SetRgb(color.R, color.G, color.B);
            }
        }
    }
}