﻿namespace Treehopper.Libraries.IO.PortExpander
{
    /// <summary>
    ///     PCF8575 16-bit I/O port expander
    /// </summary>
    [Supports("Texas Instruments", "PCF8575")]
    [Supports("NXP", "PCF8575")]
    public class Pcf8575 : Pcf8574
    {
        /// <summary>
        ///     Construct a PCF8575
        /// </summary>
        /// <param name="i2c">The I2c interface to use</param>
        /// <param name="Address0">The state of the Address0 pin</param>
        /// <param name="Address1">The state of the Address1 pin</param>
        /// <param name="Address2">The state of the Address2 pin</param>
        public Pcf8575(I2C i2c, bool Address0 = false, bool Address1 = false, bool Address2 = false) : base(i2c,
            Address0, Address1, Address2, 0x20, 16)
        {
        }
    }
}