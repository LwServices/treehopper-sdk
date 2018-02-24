/// This file was auto-generated by RegisterGenerator. Any changes to it will be overwritten!
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Treehopper;
using Treehopper.Libraries.Utilities;

namespace Treehopper.Libraries.Sensors.Inertial
{
    public partial class L3gd20
    {
        internal enum FifoModes
        {
            Bypass = 0,
            Fifo = 1,
            Stream = 2,
            StreamToFifo = 3,
            BypassToStream = 4
        }

        protected class L3gd20Registers : RegisterManager
        {
            internal L3gd20Registers(SMBusDevice dev = null) : base(dev, true)
            {
                whoAmI = new WhoAmIRegister(this);
                _registers.Add(whoAmI);
                ctrlReg1 = new CtrlReg1Register(this);
                _registers.Add(ctrlReg1);
                ctrlReg2 = new CtrlReg2Register(this);
                _registers.Add(ctrlReg2);
                ctrlReg3 = new CtrlReg3Register(this);
                _registers.Add(ctrlReg3);
                ctrlReg4 = new CtrlReg4Register(this);
                _registers.Add(ctrlReg4);
                ctrlReg5 = new CtrlReg5Register(this);
                _registers.Add(ctrlReg5);
                referenceDataCapture = new ReferenceDataCaptureRegister(this);
                _registers.Add(referenceDataCapture);
                outTemp = new OutTempRegister(this);
                _registers.Add(outTemp);
                status = new StatusRegister(this);
                _registers.Add(status);
                outX = new OutXRegister(this);
                _registers.Add(outX);
                outY = new OutYRegister(this);
                _registers.Add(outY);
                outZ = new OutZRegister(this);
                _registers.Add(outZ);
                fifoCtrl = new FifoCtrlRegister(this);
                _registers.Add(fifoCtrl);
                fifoSrc = new FifoSrcRegister(this);
                _registers.Add(fifoSrc);
                intConfig = new IntConfigRegister(this);
                _registers.Add(intConfig);
                int1Src = new Int1SrcRegister(this);
                _registers.Add(int1Src);
                int1ThresholdX = new Int1ThresholdXRegister(this);
                _registers.Add(int1ThresholdX);
                int1ThresholdY = new Int1ThresholdYRegister(this);
                _registers.Add(int1ThresholdY);
                int1ThresholdZ = new Int1ThresholdZRegister(this);
                _registers.Add(int1ThresholdZ);
                int1Duration = new Int1DurationRegister(this);
                _registers.Add(int1Duration);
            }

            internal WhoAmIRegister whoAmI;
            internal CtrlReg1Register ctrlReg1;
            internal CtrlReg2Register ctrlReg2;
            internal CtrlReg3Register ctrlReg3;
            internal CtrlReg4Register ctrlReg4;
            internal CtrlReg5Register ctrlReg5;
            internal ReferenceDataCaptureRegister referenceDataCapture;
            internal OutTempRegister outTemp;
            internal StatusRegister status;
            internal OutXRegister outX;
            internal OutYRegister outY;
            internal OutZRegister outZ;
            internal FifoCtrlRegister fifoCtrl;
            internal FifoSrcRegister fifoSrc;
            internal IntConfigRegister intConfig;
            internal Int1SrcRegister int1Src;
            internal Int1ThresholdXRegister int1ThresholdX;
            internal Int1ThresholdYRegister int1ThresholdY;
            internal Int1ThresholdZRegister int1ThresholdZ;
            internal Int1DurationRegister int1Duration;

            internal class WhoAmIRegister : Register
            {
                internal WhoAmIRegister(RegisterManager regManager) : base(regManager, 0x0f, 1, false) { }

                public int value { get; set; }

                public async Task<WhoAmIRegister> read()
                {
                    await manager.read(this).ConfigureAwait(false);
                    return this;
                }
                internal override long getValue() { return ((value & 0xFF) << 0); }
                internal override void setValue(long _value)
                {
                    value = (int)((_value >> 0) & 0xFF);
                }

                public override string ToString()
                {
                    string retVal = "";
                    retVal += $"Value: { value } (offset: 0, width: 8)\r\n";
                    return retVal;
                }
            }
            internal class CtrlReg1Register : Register
            {
                internal CtrlReg1Register(RegisterManager regManager) : base(regManager, 0x20, 1, false) { }

                public int yEn { get; set; }
                public int xEn { get; set; }
                public int zEn { get; set; }
                public int pd { get; set; }
                public int bandwidth { get; set; }
                public int dataRate { get; set; }

                public async Task<CtrlReg1Register> read()
                {
                    await manager.read(this).ConfigureAwait(false);
                    return this;
                }
                internal override long getValue() { return ((yEn & 0x1) << 0) | ((xEn & 0x1) << 1) | ((zEn & 0x1) << 2) | ((pd & 0x1) << 3) | ((bandwidth & 0x3) << 4) | ((dataRate & 0x3) << 6); }
                internal override void setValue(long _value)
                {
                    yEn = (int)((_value >> 0) & 0x1);
                    xEn = (int)((_value >> 1) & 0x1);
                    zEn = (int)((_value >> 2) & 0x1);
                    pd = (int)((_value >> 3) & 0x1);
                    bandwidth = (int)((_value >> 4) & 0x3);
                    dataRate = (int)((_value >> 6) & 0x3);
                }

                public override string ToString()
                {
                    string retVal = "";
                    retVal += $"YEn: { yEn } (offset: 0, width: 1)\r\n";
                    retVal += $"XEn: { xEn } (offset: 1, width: 1)\r\n";
                    retVal += $"ZEn: { zEn } (offset: 2, width: 1)\r\n";
                    retVal += $"Pd: { pd } (offset: 3, width: 1)\r\n";
                    retVal += $"Bandwidth: { bandwidth } (offset: 4, width: 2)\r\n";
                    retVal += $"DataRate: { dataRate } (offset: 6, width: 2)\r\n";
                    return retVal;
                }
            }
            internal class CtrlReg2Register : Register
            {
                internal CtrlReg2Register(RegisterManager regManager) : base(regManager, 0x21, 1, false) { }

                public int hpFilterCutoff { get; set; }
                public int hpFilterMode { get; set; }

                public async Task<CtrlReg2Register> read()
                {
                    await manager.read(this).ConfigureAwait(false);
                    return this;
                }
                internal override long getValue() { return ((hpFilterCutoff & 0xF) << 0) | ((hpFilterMode & 0x3) << 4); }
                internal override void setValue(long _value)
                {
                    hpFilterCutoff = (int)((_value >> 0) & 0xF);
                    hpFilterMode = (int)((_value >> 4) & 0x3);
                }

                public override string ToString()
                {
                    string retVal = "";
                    retVal += $"HpFilterCutoff: { hpFilterCutoff } (offset: 0, width: 4)\r\n";
                    retVal += $"HpFilterMode: { hpFilterMode } (offset: 4, width: 2)\r\n";
                    return retVal;
                }
            }
            internal class CtrlReg3Register : Register
            {
                internal CtrlReg3Register(RegisterManager regManager) : base(regManager, 0x22, 1, false) { }

                public int i2Empty { get; set; }
                public int i2ORun { get; set; }
                public int i2Wtm { get; set; }
                public int i2Drdy { get; set; }
                public int ppOd { get; set; }
                public int hLactive { get; set; }
                public int i1boot { get; set; }
                public int i1Int1 { get; set; }

                public async Task<CtrlReg3Register> read()
                {
                    await manager.read(this).ConfigureAwait(false);
                    return this;
                }
                internal override long getValue() { return ((i2Empty & 0x1) << 0) | ((i2ORun & 0x1) << 1) | ((i2Wtm & 0x1) << 2) | ((i2Drdy & 0x1) << 3) | ((ppOd & 0x1) << 4) | ((hLactive & 0x1) << 5) | ((i1boot & 0x1) << 6) | ((i1Int1 & 0x1) << 7); }
                internal override void setValue(long _value)
                {
                    i2Empty = (int)((_value >> 0) & 0x1);
                    i2ORun = (int)((_value >> 1) & 0x1);
                    i2Wtm = (int)((_value >> 2) & 0x1);
                    i2Drdy = (int)((_value >> 3) & 0x1);
                    ppOd = (int)((_value >> 4) & 0x1);
                    hLactive = (int)((_value >> 5) & 0x1);
                    i1boot = (int)((_value >> 6) & 0x1);
                    i1Int1 = (int)((_value >> 7) & 0x1);
                }

                public override string ToString()
                {
                    string retVal = "";
                    retVal += $"I2Empty: { i2Empty } (offset: 0, width: 1)\r\n";
                    retVal += $"I2ORun: { i2ORun } (offset: 1, width: 1)\r\n";
                    retVal += $"I2Wtm: { i2Wtm } (offset: 2, width: 1)\r\n";
                    retVal += $"I2Drdy: { i2Drdy } (offset: 3, width: 1)\r\n";
                    retVal += $"PpOd: { ppOd } (offset: 4, width: 1)\r\n";
                    retVal += $"HLactive: { hLactive } (offset: 5, width: 1)\r\n";
                    retVal += $"I1boot: { i1boot } (offset: 6, width: 1)\r\n";
                    retVal += $"I1Int1: { i1Int1 } (offset: 7, width: 1)\r\n";
                    return retVal;
                }
            }
            internal class CtrlReg4Register : Register
            {
                internal CtrlReg4Register(RegisterManager regManager) : base(regManager, 0x23, 1, false) { }

                public int sim { get; set; }
                public int fullScale { get; set; }
                public int bigLittleEndian { get; set; }
                public int blockDataUpdate { get; set; }

                public async Task<CtrlReg4Register> read()
                {
                    await manager.read(this).ConfigureAwait(false);
                    return this;
                }
                internal override long getValue() { return ((sim & 0x1) << 0) | ((fullScale & 0x3) << 4) | ((bigLittleEndian & 0x1) << 6) | ((blockDataUpdate & 0x1) << 7); }
                internal override void setValue(long _value)
                {
                    sim = (int)((_value >> 0) & 0x1);
                    fullScale = (int)((_value >> 4) & 0x3);
                    bigLittleEndian = (int)((_value >> 6) & 0x1);
                    blockDataUpdate = (int)((_value >> 7) & 0x1);
                }

                public override string ToString()
                {
                    string retVal = "";
                    retVal += $"Sim: { sim } (offset: 0, width: 1)\r\n";
                    retVal += $"FullScale: { fullScale } (offset: 4, width: 2)\r\n";
                    retVal += $"BigLittleEndian: { bigLittleEndian } (offset: 6, width: 1)\r\n";
                    retVal += $"BlockDataUpdate: { blockDataUpdate } (offset: 7, width: 1)\r\n";
                    return retVal;
                }
            }
            internal class CtrlReg5Register : Register
            {
                internal CtrlReg5Register(RegisterManager regManager) : base(regManager, 0x24, 1, false) { }

                public int outSel { get; set; }
                public int int1Sel { get; set; }
                public int hPen { get; set; }
                public int fifoEn { get; set; }
                public int boot { get; set; }

                public async Task<CtrlReg5Register> read()
                {
                    await manager.read(this).ConfigureAwait(false);
                    return this;
                }
                internal override long getValue() { return ((outSel & 0x3) << 0) | ((int1Sel & 0x3) << 2) | ((hPen & 0x1) << 4) | ((fifoEn & 0x1) << 6) | ((boot & 0x1) << 7); }
                internal override void setValue(long _value)
                {
                    outSel = (int)((_value >> 0) & 0x3);
                    int1Sel = (int)((_value >> 2) & 0x3);
                    hPen = (int)((_value >> 4) & 0x1);
                    fifoEn = (int)((_value >> 6) & 0x1);
                    boot = (int)((_value >> 7) & 0x1);
                }

                public override string ToString()
                {
                    string retVal = "";
                    retVal += $"OutSel: { outSel } (offset: 0, width: 2)\r\n";
                    retVal += $"Int1Sel: { int1Sel } (offset: 2, width: 2)\r\n";
                    retVal += $"HPen: { hPen } (offset: 4, width: 1)\r\n";
                    retVal += $"FifoEn: { fifoEn } (offset: 6, width: 1)\r\n";
                    retVal += $"Boot: { boot } (offset: 7, width: 1)\r\n";
                    return retVal;
                }
            }
            internal class ReferenceDataCaptureRegister : Register
            {
                internal ReferenceDataCaptureRegister(RegisterManager regManager) : base(regManager, 0x25, 1, false) { }

                public int value { get; set; }

                public async Task<ReferenceDataCaptureRegister> read()
                {
                    await manager.read(this).ConfigureAwait(false);
                    return this;
                }
                internal override long getValue() { return ((value & 0xFF) << 0); }
                internal override void setValue(long _value)
                {
                    value = (int)((_value >> 0) & 0xFF);
                }

                public override string ToString()
                {
                    string retVal = "";
                    retVal += $"Value: { value } (offset: 0, width: 8)\r\n";
                    return retVal;
                }
            }
            internal class OutTempRegister : Register
            {
                internal OutTempRegister(RegisterManager regManager) : base(regManager, 0x26, 1, false) { }

                public int value { get; set; }

                public async Task<OutTempRegister> read()
                {
                    await manager.read(this).ConfigureAwait(false);
                    return this;
                }
                internal override long getValue() { return ((value & 0xFF) << 0); }
                internal override void setValue(long _value)
                {
                    value = (int)((_value >> 0) & 0xFF);
                }

                public override string ToString()
                {
                    string retVal = "";
                    retVal += $"Value: { value } (offset: 0, width: 8)\r\n";
                    return retVal;
                }
            }
            internal class StatusRegister : Register
            {
                internal StatusRegister(RegisterManager regManager) : base(regManager, 0x27, 1, false) { }

                public int xDataAvailable { get; set; }
                public int yDataAvailable { get; set; }
                public int zDataAvailable { get; set; }
                public int zyxDataAvailable { get; set; }
                public int xDataOverrun { get; set; }
                public int yDataOverrun { get; set; }
                public int zDataOverrun { get; set; }
                public int zyxDataOverrun { get; set; }

                public async Task<StatusRegister> read()
                {
                    await manager.read(this).ConfigureAwait(false);
                    return this;
                }
                internal override long getValue() { return ((xDataAvailable & 0x1) << 0) | ((yDataAvailable & 0x1) << 1) | ((zDataAvailable & 0x1) << 2) | ((zyxDataAvailable & 0x1) << 3) | ((xDataOverrun & 0x1) << 4) | ((yDataOverrun & 0x1) << 5) | ((zDataOverrun & 0x1) << 6) | ((zyxDataOverrun & 0x1) << 7); }
                internal override void setValue(long _value)
                {
                    xDataAvailable = (int)((_value >> 0) & 0x1);
                    yDataAvailable = (int)((_value >> 1) & 0x1);
                    zDataAvailable = (int)((_value >> 2) & 0x1);
                    zyxDataAvailable = (int)((_value >> 3) & 0x1);
                    xDataOverrun = (int)((_value >> 4) & 0x1);
                    yDataOverrun = (int)((_value >> 5) & 0x1);
                    zDataOverrun = (int)((_value >> 6) & 0x1);
                    zyxDataOverrun = (int)((_value >> 7) & 0x1);
                }

                public override string ToString()
                {
                    string retVal = "";
                    retVal += $"XDataAvailable: { xDataAvailable } (offset: 0, width: 1)\r\n";
                    retVal += $"YDataAvailable: { yDataAvailable } (offset: 1, width: 1)\r\n";
                    retVal += $"ZDataAvailable: { zDataAvailable } (offset: 2, width: 1)\r\n";
                    retVal += $"ZyxDataAvailable: { zyxDataAvailable } (offset: 3, width: 1)\r\n";
                    retVal += $"XDataOverrun: { xDataOverrun } (offset: 4, width: 1)\r\n";
                    retVal += $"YDataOverrun: { yDataOverrun } (offset: 5, width: 1)\r\n";
                    retVal += $"ZDataOverrun: { zDataOverrun } (offset: 6, width: 1)\r\n";
                    retVal += $"ZyxDataOverrun: { zyxDataOverrun } (offset: 7, width: 1)\r\n";
                    return retVal;
                }
            }
            internal class OutXRegister : Register
            {
                internal OutXRegister(RegisterManager regManager) : base(regManager, 0x28, 2, false) { }

                public int value { get; set; }

                public async Task<OutXRegister> read()
                {
                    await manager.read(this).ConfigureAwait(false);
                    return this;
                }
                internal override long getValue() { return ((value & 0xFFFF) << 0); }
                internal override void setValue(long _value)
                {
                    value = (int)(((_value >> 0) & 0xFFFF) << (32 - 16)) >> (32 - 16);
                }

                public override string ToString()
                {
                    string retVal = "";
                    retVal += $"Value: { value } (offset: 0, width: 16)\r\n";
                    return retVal;
                }
            }
            internal class OutYRegister : Register
            {
                internal OutYRegister(RegisterManager regManager) : base(regManager, 0x2A, 2, false) { }

                public int value { get; set; }

                public async Task<OutYRegister> read()
                {
                    await manager.read(this).ConfigureAwait(false);
                    return this;
                }
                internal override long getValue() { return ((value & 0xFFFF) << 0); }
                internal override void setValue(long _value)
                {
                    value = (int)(((_value >> 0) & 0xFFFF) << (32 - 16)) >> (32 - 16);
                }

                public override string ToString()
                {
                    string retVal = "";
                    retVal += $"Value: { value } (offset: 0, width: 16)\r\n";
                    return retVal;
                }
            }
            internal class OutZRegister : Register
            {
                internal OutZRegister(RegisterManager regManager) : base(regManager, 0x2C, 2, false) { }

                public int value { get; set; }

                public async Task<OutZRegister> read()
                {
                    await manager.read(this).ConfigureAwait(false);
                    return this;
                }
                internal override long getValue() { return ((value & 0xFFFF) << 0); }
                internal override void setValue(long _value)
                {
                    value = (int)(((_value >> 0) & 0xFFFF) << (32 - 16)) >> (32 - 16);
                }

                public override string ToString()
                {
                    string retVal = "";
                    retVal += $"Value: { value } (offset: 0, width: 16)\r\n";
                    return retVal;
                }
            }
            internal class FifoCtrlRegister : Register
            {
                internal FifoCtrlRegister(RegisterManager regManager) : base(regManager, 0x2e, 1, false) { }

                public int watermarkLevelSetting { get; set; }
                public int fifoMode { get; set; }
                public FifoModes getFifoMode() { return (FifoModes)fifoMode; }
                public void setFifoMode(FifoModes enumVal) { fifoMode = (int)enumVal; }

                public async Task<FifoCtrlRegister> read()
                {
                    await manager.read(this).ConfigureAwait(false);
                    return this;
                }
                internal override long getValue() { return ((watermarkLevelSetting & 0x1F) << 0) | ((fifoMode & 0x7) << 5); }
                internal override void setValue(long _value)
                {
                    watermarkLevelSetting = (int)((_value >> 0) & 0x1F);
                    fifoMode = (int)((_value >> 5) & 0x7);
                }

                public override string ToString()
                {
                    string retVal = "";
                    retVal += $"WatermarkLevelSetting: { watermarkLevelSetting } (offset: 0, width: 5)\r\n";
                    retVal += $"FifoMode: { fifoMode } (offset: 5, width: 3)\r\n";
                    return retVal;
                }
            }
            internal class FifoSrcRegister : Register
            {
                internal FifoSrcRegister(RegisterManager regManager) : base(regManager, 0x2f, 1, false) { }

                public int fifoStoredDataLevel { get; set; }
                public int empty { get; set; }
                public int overrun { get; set; }
                public int watermarkStatus { get; set; }

                public async Task<FifoSrcRegister> read()
                {
                    await manager.read(this).ConfigureAwait(false);
                    return this;
                }
                internal override long getValue() { return ((fifoStoredDataLevel & 0x1F) << 0) | ((empty & 0x1) << 5) | ((overrun & 0x1) << 6) | ((watermarkStatus & 0x1) << 7); }
                internal override void setValue(long _value)
                {
                    fifoStoredDataLevel = (int)((_value >> 0) & 0x1F);
                    empty = (int)((_value >> 5) & 0x1);
                    overrun = (int)((_value >> 6) & 0x1);
                    watermarkStatus = (int)((_value >> 7) & 0x1);
                }

                public override string ToString()
                {
                    string retVal = "";
                    retVal += $"FifoStoredDataLevel: { fifoStoredDataLevel } (offset: 0, width: 5)\r\n";
                    retVal += $"Empty: { empty } (offset: 5, width: 1)\r\n";
                    retVal += $"Overrun: { overrun } (offset: 6, width: 1)\r\n";
                    retVal += $"WatermarkStatus: { watermarkStatus } (offset: 7, width: 1)\r\n";
                    return retVal;
                }
            }
            internal class IntConfigRegister : Register
            {
                internal IntConfigRegister(RegisterManager regManager) : base(regManager, 0x30, 1, false) { }

                public int xLowInterruptEnable { get; set; }
                public int xHighInterruptEnable { get; set; }
                public int yLowInterruptEnable { get; set; }
                public int yHighInterruptEnable { get; set; }
                public int zLowInterruptEvent { get; set; }
                public int zHighInterruptEnable { get; set; }
                public int latchInterruptRequest { get; set; }
                public int andOr { get; set; }

                public async Task<IntConfigRegister> read()
                {
                    await manager.read(this).ConfigureAwait(false);
                    return this;
                }
                internal override long getValue() { return ((xLowInterruptEnable & 0x1) << 0) | ((xHighInterruptEnable & 0x1) << 1) | ((yLowInterruptEnable & 0x1) << 2) | ((yHighInterruptEnable & 0x1) << 3) | ((zLowInterruptEvent & 0x1) << 4) | ((zHighInterruptEnable & 0x1) << 5) | ((latchInterruptRequest & 0x1) << 6) | ((andOr & 0x1) << 7); }
                internal override void setValue(long _value)
                {
                    xLowInterruptEnable = (int)((_value >> 0) & 0x1);
                    xHighInterruptEnable = (int)((_value >> 1) & 0x1);
                    yLowInterruptEnable = (int)((_value >> 2) & 0x1);
                    yHighInterruptEnable = (int)((_value >> 3) & 0x1);
                    zLowInterruptEvent = (int)((_value >> 4) & 0x1);
                    zHighInterruptEnable = (int)((_value >> 5) & 0x1);
                    latchInterruptRequest = (int)((_value >> 6) & 0x1);
                    andOr = (int)((_value >> 7) & 0x1);
                }

                public override string ToString()
                {
                    string retVal = "";
                    retVal += $"XLowInterruptEnable: { xLowInterruptEnable } (offset: 0, width: 1)\r\n";
                    retVal += $"XHighInterruptEnable: { xHighInterruptEnable } (offset: 1, width: 1)\r\n";
                    retVal += $"YLowInterruptEnable: { yLowInterruptEnable } (offset: 2, width: 1)\r\n";
                    retVal += $"YHighInterruptEnable: { yHighInterruptEnable } (offset: 3, width: 1)\r\n";
                    retVal += $"ZLowInterruptEvent: { zLowInterruptEvent } (offset: 4, width: 1)\r\n";
                    retVal += $"ZHighInterruptEnable: { zHighInterruptEnable } (offset: 5, width: 1)\r\n";
                    retVal += $"LatchInterruptRequest: { latchInterruptRequest } (offset: 6, width: 1)\r\n";
                    retVal += $"AndOr: { andOr } (offset: 7, width: 1)\r\n";
                    return retVal;
                }
            }
            internal class Int1SrcRegister : Register
            {
                internal Int1SrcRegister(RegisterManager regManager) : base(regManager, 0x31, 1, false) { }

                public int xLow { get; set; }
                public int xHigh { get; set; }
                public int yLow { get; set; }
                public int yHigh { get; set; }
                public int zLow { get; set; }
                public int zHigh { get; set; }
                public int interruptActive { get; set; }

                public async Task<Int1SrcRegister> read()
                {
                    await manager.read(this).ConfigureAwait(false);
                    return this;
                }
                internal override long getValue() { return ((xLow & 0x1) << 0) | ((xHigh & 0x1) << 1) | ((yLow & 0x1) << 2) | ((yHigh & 0x1) << 3) | ((zLow & 0x1) << 4) | ((zHigh & 0x1) << 5) | ((interruptActive & 0x1) << 6); }
                internal override void setValue(long _value)
                {
                    xLow = (int)((_value >> 0) & 0x1);
                    xHigh = (int)((_value >> 1) & 0x1);
                    yLow = (int)((_value >> 2) & 0x1);
                    yHigh = (int)((_value >> 3) & 0x1);
                    zLow = (int)((_value >> 4) & 0x1);
                    zHigh = (int)((_value >> 5) & 0x1);
                    interruptActive = (int)((_value >> 6) & 0x1);
                }

                public override string ToString()
                {
                    string retVal = "";
                    retVal += $"XLow: { xLow } (offset: 0, width: 1)\r\n";
                    retVal += $"XHigh: { xHigh } (offset: 1, width: 1)\r\n";
                    retVal += $"YLow: { yLow } (offset: 2, width: 1)\r\n";
                    retVal += $"YHigh: { yHigh } (offset: 3, width: 1)\r\n";
                    retVal += $"ZLow: { zLow } (offset: 4, width: 1)\r\n";
                    retVal += $"ZHigh: { zHigh } (offset: 5, width: 1)\r\n";
                    retVal += $"InterruptActive: { interruptActive } (offset: 6, width: 1)\r\n";
                    return retVal;
                }
            }
            internal class Int1ThresholdXRegister : Register
            {
                internal Int1ThresholdXRegister(RegisterManager regManager) : base(regManager, 0x32, 2, true) { }

                public int value { get; set; }

                public async Task<Int1ThresholdXRegister> read()
                {
                    await manager.read(this).ConfigureAwait(false);
                    return this;
                }
                internal override long getValue() { return ((value & 0xFFFF) << 0); }
                internal override void setValue(long _value)
                {
                    value = (int)(((_value >> 0) & 0xFFFF) << (32 - 16)) >> (32 - 16);
                }

                public override string ToString()
                {
                    string retVal = "";
                    retVal += $"Value: { value } (offset: 0, width: 16)\r\n";
                    return retVal;
                }
            }
            internal class Int1ThresholdYRegister : Register
            {
                internal Int1ThresholdYRegister(RegisterManager regManager) : base(regManager, 0x34, 2, true) { }

                public int value { get; set; }

                public async Task<Int1ThresholdYRegister> read()
                {
                    await manager.read(this).ConfigureAwait(false);
                    return this;
                }
                internal override long getValue() { return ((value & 0xFFFF) << 0); }
                internal override void setValue(long _value)
                {
                    value = (int)(((_value >> 0) & 0xFFFF) << (32 - 16)) >> (32 - 16);
                }

                public override string ToString()
                {
                    string retVal = "";
                    retVal += $"Value: { value } (offset: 0, width: 16)\r\n";
                    return retVal;
                }
            }
            internal class Int1ThresholdZRegister : Register
            {
                internal Int1ThresholdZRegister(RegisterManager regManager) : base(regManager, 0x36, 2, true) { }

                public int value { get; set; }

                public async Task<Int1ThresholdZRegister> read()
                {
                    await manager.read(this).ConfigureAwait(false);
                    return this;
                }
                internal override long getValue() { return ((value & 0xFFFF) << 0); }
                internal override void setValue(long _value)
                {
                    value = (int)(((_value >> 0) & 0xFFFF) << (32 - 16)) >> (32 - 16);
                }

                public override string ToString()
                {
                    string retVal = "";
                    retVal += $"Value: { value } (offset: 0, width: 16)\r\n";
                    return retVal;
                }
            }
            internal class Int1DurationRegister : Register
            {
                internal Int1DurationRegister(RegisterManager regManager) : base(regManager, 0x38, 1, false) { }

                public int duration { get; set; }
                public int wait { get; set; }

                public async Task<Int1DurationRegister> read()
                {
                    await manager.read(this).ConfigureAwait(false);
                    return this;
                }
                internal override long getValue() { return ((duration & 0x7F) << 0) | ((wait & 0x1) << 7); }
                internal override void setValue(long _value)
                {
                    duration = (int)((_value >> 0) & 0x7F);
                    wait = (int)((_value >> 7) & 0x1);
                }

                public override string ToString()
                {
                    string retVal = "";
                    retVal += $"Duration: { duration } (offset: 0, width: 7)\r\n";
                    retVal += $"Wait: { wait } (offset: 7, width: 1)\r\n";
                    return retVal;
                }
            }
        }
    }
}