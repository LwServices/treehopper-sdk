### This file was auto-generated by RegisterGenerator. Any changes to it will be overwritten!
from treehopper.libraries.smbus_device import SMBusDevice
from treehopper.libraries.register_manager import RegisterManager, Register, sign_extend


class OutputDataRates:
    powerDown = 0
    Hz_1 = 1
    Hz_10 = 2
    Hz_25 = 3
    Hz_50 = 4
    Hz_100 = 5
    Hz_200 = 6
    Hz_400 = 7
    Lp_1620Hz = 8
    Hz_1344_LP_5376Hz = 9
    
class AccelhighPassModes:
    Reset = 0
    ReferenceSignal = 1
    Normal = 2
    AutoResetOnInterrupt = 3
    
class FullScaleSelections:
    Fs_2g = 0
    Fs_4g = 1
    Fs_6g = 2
    Fs_8g = 3
    Fs_16g = 4
    
class FifoModes:
    Bypass = 0
    Fifo = 1
    Stream = 2
    StreamToFifo = 3
    BypassToStream = 4
    
class Lsm303dlhcAccelRegisters(RegisterManager):
    def __init__(self, dev: SMBusDevice):
        RegisterManager.__init__(self, dev, True)
        self.ctrl1 = self.Ctrl1Register(self)
        self.registers.append(self.ctrl1)
        self.ctrl2 = self.Ctrl2Register(self)
        self.registers.append(self.ctrl2)
        self.ctrl3 = self.Ctrl3Register(self)
        self.registers.append(self.ctrl3)
        self.ctrl4 = self.Ctrl4Register(self)
        self.registers.append(self.ctrl4)
        self.ctrl5 = self.Ctrl5Register(self)
        self.registers.append(self.ctrl5)
        self.ctrl6 = self.Ctrl6Register(self)
        self.registers.append(self.ctrl6)
        self.reference = self.ReferenceRegister(self)
        self.registers.append(self.reference)
        self.status = self.StatusRegister(self)
        self.registers.append(self.status)
        self.fifoControl = self.FifoControlRegister(self)
        self.registers.append(self.fifoControl)
        self.fifoSource = self.FifoSourceRegister(self)
        self.registers.append(self.fifoSource)
        self.inertialIntGen1Config = self.InertialIntGen1ConfigRegister(self)
        self.registers.append(self.inertialIntGen1Config)
        self.inertialIntGen1Status = self.InertialIntGen1StatusRegister(self)
        self.registers.append(self.inertialIntGen1Status)
        self.inertialIntGen1Threshold = self.InertialIntGen1ThresholdRegister(self)
        self.registers.append(self.inertialIntGen1Threshold)
        self.inertialIntGen1Duration = self.InertialIntGen1DurationRegister(self)
        self.registers.append(self.inertialIntGen1Duration)
        self.inertialIntGen2Config = self.InertialIntGen2ConfigRegister(self)
        self.registers.append(self.inertialIntGen2Config)
        self.inertialIntGen2Status = self.InertialIntGen2StatusRegister(self)
        self.registers.append(self.inertialIntGen2Status)
        self.inertialIntGen2Threshold = self.InertialIntGen2ThresholdRegister(self)
        self.registers.append(self.inertialIntGen2Threshold)
        self.inertialIntGen2Duration = self.InertialIntGen2DurationRegister(self)
        self.registers.append(self.inertialIntGen2Duration)
        self.clickConfig = self.ClickConfigRegister(self)
        self.registers.append(self.clickConfig)
        self.clickSource = self.ClickSourceRegister(self)
        self.registers.append(self.clickSource)
        self.clickThreshold = self.ClickThresholdRegister(self)
        self.registers.append(self.clickThreshold)
        self.timeLimit = self.TimeLimitRegister(self)
        self.registers.append(self.timeLimit)
        self.timeLatency = self.TimeLatencyRegister(self)
        self.registers.append(self.timeLatency)
        self.timeWindow = self.TimeWindowRegister(self)
        self.registers.append(self.timeWindow)
        self.outAccelX = self.OutAccelXRegister(self)
        self.registers.append(self.outAccelX)
        self.outAccelY = self.OutAccelYRegister(self)
        self.registers.append(self.outAccelY)
        self.outAccelZ = self.OutAccelZRegister(self)
        self.registers.append(self.outAccelZ)

    class Ctrl1Register(Register):
        def __init__(self, reg_manager: RegisterManager):
            Register.__init__(self, reg_manager, 0x20, 1, False)
            self.xEnable = 0
            self.yEnable = 0
            self.zEnable = 0
            self.lowPowerEnable = 0
            self.outputDataRate = 0


        def read(self):
            self._manager.read(self)
            return self
            
        def getValue(self):
            return ((self.xEnable & 0x1) << 0) | ((self.yEnable & 0x1) << 1) | ((self.zEnable & 0x1) << 2) | ((self.lowPowerEnable & 0x1) << 3) | ((self.outputDataRate & 0xF) << 4)

        def setValue(self, value: int):
            self.xEnable = ((value >> 0) & 0x1)
            self.yEnable = ((value >> 1) & 0x1)
            self.zEnable = ((value >> 2) & 0x1)
            self.lowPowerEnable = ((value >> 3) & 0x1)
            self.outputDataRate = ((value >> 4) & 0xF)

        def __str__(self):
            retVal = ""
            retVal += "XEnable: {} (offset: 0, width: 1)\r\n".format(self.xEnable)
            retVal += "YEnable: {} (offset: 1, width: 1)\r\n".format(self.yEnable)
            retVal += "ZEnable: {} (offset: 2, width: 1)\r\n".format(self.zEnable)
            retVal += "LowPowerEnable: {} (offset: 3, width: 1)\r\n".format(self.lowPowerEnable)
            retVal += "OutputDataRate: {} (offset: 4, width: 4)\r\n".format(self.outputDataRate)
            return retVal

    class Ctrl2Register(Register):
        def __init__(self, reg_manager: RegisterManager):
            Register.__init__(self, reg_manager, 0x21, 1, False)
            self.hpis = 0
            self.hpClick = 0
            self.filterDataSelection = 0
            self.hpcf = 0
            self.accelhighPassMode = 0


        def read(self):
            self._manager.read(self)
            return self
            
        def getValue(self):
            return ((self.hpis & 0x3) << 0) | ((self.hpClick & 0x1) << 2) | ((self.filterDataSelection & 0x1) << 3) | ((self.hpcf & 0x3) << 4) | ((self.accelhighPassMode & 0x3) << 6)

        def setValue(self, value: int):
            self.hpis = ((value >> 0) & 0x3)
            self.hpClick = ((value >> 2) & 0x1)
            self.filterDataSelection = ((value >> 3) & 0x1)
            self.hpcf = ((value >> 4) & 0x3)
            self.accelhighPassMode = ((value >> 6) & 0x3)

        def __str__(self):
            retVal = ""
            retVal += "Hpis: {} (offset: 0, width: 2)\r\n".format(self.hpis)
            retVal += "HpClick: {} (offset: 2, width: 1)\r\n".format(self.hpClick)
            retVal += "FilterDataSelection: {} (offset: 3, width: 1)\r\n".format(self.filterDataSelection)
            retVal += "Hpcf: {} (offset: 4, width: 2)\r\n".format(self.hpcf)
            retVal += "AccelhighPassMode: {} (offset: 6, width: 2)\r\n".format(self.accelhighPassMode)
            return retVal

    class Ctrl3Register(Register):
        def __init__(self, reg_manager: RegisterManager):
            Register.__init__(self, reg_manager, 0x22, 1, False)
            self.fifoOverrunOnInt1 = 0
            self.fifoWatermarkOnInt1 = 0
            self.drdy2OnInt1 = 0
            self.drdy1OnInt1 = 0
            self.aoi2OnInt1 = 0
            self.aoi1OnInt1 = 0
            self.clickOnInt2 = 0


        def read(self):
            self._manager.read(self)
            return self
            
        def getValue(self):
            return ((self.fifoOverrunOnInt1 & 0x1) << 1) | ((self.fifoWatermarkOnInt1 & 0x1) << 2) | ((self.drdy2OnInt1 & 0x1) << 3) | ((self.drdy1OnInt1 & 0x1) << 4) | ((self.aoi2OnInt1 & 0x1) << 5) | ((self.aoi1OnInt1 & 0x1) << 6) | ((self.clickOnInt2 & 0x1) << 7)

        def setValue(self, value: int):
            self.fifoOverrunOnInt1 = ((value >> 1) & 0x1)
            self.fifoWatermarkOnInt1 = ((value >> 2) & 0x1)
            self.drdy2OnInt1 = ((value >> 3) & 0x1)
            self.drdy1OnInt1 = ((value >> 4) & 0x1)
            self.aoi2OnInt1 = ((value >> 5) & 0x1)
            self.aoi1OnInt1 = ((value >> 6) & 0x1)
            self.clickOnInt2 = ((value >> 7) & 0x1)

        def __str__(self):
            retVal = ""
            retVal += "FifoOverrunOnInt1: {} (offset: 1, width: 1)\r\n".format(self.fifoOverrunOnInt1)
            retVal += "FifoWatermarkOnInt1: {} (offset: 2, width: 1)\r\n".format(self.fifoWatermarkOnInt1)
            retVal += "Drdy2OnInt1: {} (offset: 3, width: 1)\r\n".format(self.drdy2OnInt1)
            retVal += "Drdy1OnInt1: {} (offset: 4, width: 1)\r\n".format(self.drdy1OnInt1)
            retVal += "Aoi2OnInt1: {} (offset: 5, width: 1)\r\n".format(self.aoi2OnInt1)
            retVal += "Aoi1OnInt1: {} (offset: 6, width: 1)\r\n".format(self.aoi1OnInt1)
            retVal += "ClickOnInt2: {} (offset: 7, width: 1)\r\n".format(self.clickOnInt2)
            return retVal

    class Ctrl4Register(Register):
        def __init__(self, reg_manager: RegisterManager):
            Register.__init__(self, reg_manager, 0x23, 1, False)
            self.spiModeSelection = 0
            self.highResolution = 0
            self.fullScaleSelection = 0
            self.ble = 0
            self.bdu = 0


        def read(self):
            self._manager.read(self)
            return self
            
        def getValue(self):
            return ((self.spiModeSelection & 0x1) << 0) | ((self.highResolution & 0x1) << 3) | ((self.fullScaleSelection & 0x7) << 3) | ((self.ble & 0x1) << 6) | ((self.bdu & 0x1) << 7)

        def setValue(self, value: int):
            self.spiModeSelection = ((value >> 0) & 0x1)
            self.highResolution = ((value >> 3) & 0x1)
            self.fullScaleSelection = ((value >> 3) & 0x7)
            self.ble = ((value >> 6) & 0x1)
            self.bdu = ((value >> 7) & 0x1)

        def __str__(self):
            retVal = ""
            retVal += "SpiModeSelection: {} (offset: 0, width: 1)\r\n".format(self.spiModeSelection)
            retVal += "HighResolution: {} (offset: 3, width: 1)\r\n".format(self.highResolution)
            retVal += "FullScaleSelection: {} (offset: 3, width: 3)\r\n".format(self.fullScaleSelection)
            retVal += "Ble: {} (offset: 6, width: 1)\r\n".format(self.ble)
            retVal += "Bdu: {} (offset: 7, width: 1)\r\n".format(self.bdu)
            return retVal

    class Ctrl5Register(Register):
        def __init__(self, reg_manager: RegisterManager):
            Register.__init__(self, reg_manager, 0x24, 1, False)
            self.d4dInt2 = 0
            self.lirInt2 = 0
            self.d4dInt1 = 0
            self.lirInt1 = 0
            self.fifoEnable = 0
            self.boot = 0


        def read(self):
            self._manager.read(self)
            return self
            
        def getValue(self):
            return ((self.d4dInt2 & 0x1) << 0) | ((self.lirInt2 & 0x1) << 1) | ((self.d4dInt1 & 0x1) << 2) | ((self.lirInt1 & 0x1) << 3) | ((self.fifoEnable & 0x1) << 6) | ((self.boot & 0x1) << 7)

        def setValue(self, value: int):
            self.d4dInt2 = ((value >> 0) & 0x1)
            self.lirInt2 = ((value >> 1) & 0x1)
            self.d4dInt1 = ((value >> 2) & 0x1)
            self.lirInt1 = ((value >> 3) & 0x1)
            self.fifoEnable = ((value >> 6) & 0x1)
            self.boot = ((value >> 7) & 0x1)

        def __str__(self):
            retVal = ""
            retVal += "D4dInt2: {} (offset: 0, width: 1)\r\n".format(self.d4dInt2)
            retVal += "LirInt2: {} (offset: 1, width: 1)\r\n".format(self.lirInt2)
            retVal += "D4dInt1: {} (offset: 2, width: 1)\r\n".format(self.d4dInt1)
            retVal += "LirInt1: {} (offset: 3, width: 1)\r\n".format(self.lirInt1)
            retVal += "FifoEnable: {} (offset: 6, width: 1)\r\n".format(self.fifoEnable)
            retVal += "Boot: {} (offset: 7, width: 1)\r\n".format(self.boot)
            return retVal

    class Ctrl6Register(Register):
        def __init__(self, reg_manager: RegisterManager):
            Register.__init__(self, reg_manager, 0x25, 1, False)
            self.interruptActiveHigh = 0
            self.p2Act = 0
            self.bootI1 = 0
            self.i2Int2 = 0
            self.i2Int1 = 0
            self.i2ClickEnable = 0


        def read(self):
            self._manager.read(self)
            return self
            
        def getValue(self):
            return ((self.interruptActiveHigh & 0x1) << 1) | ((self.p2Act & 0x1) << 3) | ((self.bootI1 & 0x1) << 4) | ((self.i2Int2 & 0x1) << 5) | ((self.i2Int1 & 0x1) << 6) | ((self.i2ClickEnable & 0x1) << 7)

        def setValue(self, value: int):
            self.interruptActiveHigh = ((value >> 1) & 0x1)
            self.p2Act = ((value >> 3) & 0x1)
            self.bootI1 = ((value >> 4) & 0x1)
            self.i2Int2 = ((value >> 5) & 0x1)
            self.i2Int1 = ((value >> 6) & 0x1)
            self.i2ClickEnable = ((value >> 7) & 0x1)

        def __str__(self):
            retVal = ""
            retVal += "InterruptActiveHigh: {} (offset: 1, width: 1)\r\n".format(self.interruptActiveHigh)
            retVal += "P2Act: {} (offset: 3, width: 1)\r\n".format(self.p2Act)
            retVal += "BootI1: {} (offset: 4, width: 1)\r\n".format(self.bootI1)
            retVal += "I2Int2: {} (offset: 5, width: 1)\r\n".format(self.i2Int2)
            retVal += "I2Int1: {} (offset: 6, width: 1)\r\n".format(self.i2Int1)
            retVal += "I2ClickEnable: {} (offset: 7, width: 1)\r\n".format(self.i2ClickEnable)
            return retVal

    class ReferenceRegister(Register):
        def __init__(self, reg_manager: RegisterManager):
            Register.__init__(self, reg_manager, 0x26, 1, False)
            self.value = 0


        def read(self):
            self._manager.read(self)
            return self
            
        def getValue(self):
            return ((self.value & 0xFF) << 0)

        def setValue(self, value: int):
            self.value = ((value >> 0) & 0xFF)

        def __str__(self):
            retVal = ""
            retVal += "Value: {} (offset: 0, width: 8)\r\n".format(self.value)
            return retVal

    class StatusRegister(Register):
        def __init__(self, reg_manager: RegisterManager):
            Register.__init__(self, reg_manager, 0x27, 1, False)
            self.xDataAvailable = 0
            self.yDataAvailable = 0
            self.zDataAvailable = 0
            self.zyxDataAvailable = 0
            self.xDataOverrun = 0
            self.yDataOverrun = 0
            self.zDataOverrun = 0
            self.zyxDataOverrun = 0


        def read(self):
            self._manager.read(self)
            return self
            
        def getValue(self):
            return ((self.xDataAvailable & 0x1) << 0) | ((self.yDataAvailable & 0x1) << 1) | ((self.zDataAvailable & 0x1) << 2) | ((self.zyxDataAvailable & 0x1) << 3) | ((self.xDataOverrun & 0x1) << 4) | ((self.yDataOverrun & 0x1) << 5) | ((self.zDataOverrun & 0x1) << 6) | ((self.zyxDataOverrun & 0x1) << 7)

        def setValue(self, value: int):
            self.xDataAvailable = ((value >> 0) & 0x1)
            self.yDataAvailable = ((value >> 1) & 0x1)
            self.zDataAvailable = ((value >> 2) & 0x1)
            self.zyxDataAvailable = ((value >> 3) & 0x1)
            self.xDataOverrun = ((value >> 4) & 0x1)
            self.yDataOverrun = ((value >> 5) & 0x1)
            self.zDataOverrun = ((value >> 6) & 0x1)
            self.zyxDataOverrun = ((value >> 7) & 0x1)

        def __str__(self):
            retVal = ""
            retVal += "XDataAvailable: {} (offset: 0, width: 1)\r\n".format(self.xDataAvailable)
            retVal += "YDataAvailable: {} (offset: 1, width: 1)\r\n".format(self.yDataAvailable)
            retVal += "ZDataAvailable: {} (offset: 2, width: 1)\r\n".format(self.zDataAvailable)
            retVal += "ZyxDataAvailable: {} (offset: 3, width: 1)\r\n".format(self.zyxDataAvailable)
            retVal += "XDataOverrun: {} (offset: 4, width: 1)\r\n".format(self.xDataOverrun)
            retVal += "YDataOverrun: {} (offset: 5, width: 1)\r\n".format(self.yDataOverrun)
            retVal += "ZDataOverrun: {} (offset: 6, width: 1)\r\n".format(self.zDataOverrun)
            retVal += "ZyxDataOverrun: {} (offset: 7, width: 1)\r\n".format(self.zyxDataOverrun)
            return retVal

    class FifoControlRegister(Register):
        def __init__(self, reg_manager: RegisterManager):
            Register.__init__(self, reg_manager, 0x2E, 1, False)
            self.fifoThreshold = 0
            self.fifoMode = 0


        def read(self):
            self._manager.read(self)
            return self
            
        def getValue(self):
            return ((self.fifoThreshold & 0x1F) << 0) | ((self.fifoMode & 0x7) << 5)

        def setValue(self, value: int):
            self.fifoThreshold = ((value >> 0) & 0x1F)
            self.fifoMode = ((value >> 5) & 0x7)

        def __str__(self):
            retVal = ""
            retVal += "FifoThreshold: {} (offset: 0, width: 5)\r\n".format(self.fifoThreshold)
            retVal += "FifoMode: {} (offset: 5, width: 3)\r\n".format(self.fifoMode)
            return retVal

    class FifoSourceRegister(Register):
        def __init__(self, reg_manager: RegisterManager):
            Register.__init__(self, reg_manager, 0x2f, 1, False)
            self.fifoStoredLevel = 0
            self.empty = 0
            self.overrun = 0
            self.fifoThreshold = 0


        def read(self):
            self._manager.read(self)
            return self
            
        def getValue(self):
            return ((self.fifoStoredLevel & 0x1F) << 0) | ((self.empty & 0x1) << 5) | ((self.overrun & 0x1) << 6) | ((self.fifoThreshold & 0x1) << 7)

        def setValue(self, value: int):
            self.fifoStoredLevel = ((value >> 0) & 0x1F)
            self.empty = ((value >> 5) & 0x1)
            self.overrun = ((value >> 6) & 0x1)
            self.fifoThreshold = ((value >> 7) & 0x1)

        def __str__(self):
            retVal = ""
            retVal += "FifoStoredLevel: {} (offset: 0, width: 5)\r\n".format(self.fifoStoredLevel)
            retVal += "Empty: {} (offset: 5, width: 1)\r\n".format(self.empty)
            retVal += "Overrun: {} (offset: 6, width: 1)\r\n".format(self.overrun)
            retVal += "FifoThreshold: {} (offset: 7, width: 1)\r\n".format(self.fifoThreshold)
            return retVal

    class InertialIntGen1ConfigRegister(Register):
        def __init__(self, reg_manager: RegisterManager):
            Register.__init__(self, reg_manager, 0x30, 1, False)
            self.xLowInterruptEnable = 0
            self.xHighInterruptEnable = 0
            self.yLowInterruptEnable = 0
            self.yHighInterruptEnable = 0
            self.zLowInterruptEvent = 0
            self.zHighInterruptEnable = 0
            self.detect6D = 0
            self.andOrInterruptEvents = 0


        def read(self):
            self._manager.read(self)
            return self
            
        def getValue(self):
            return ((self.xLowInterruptEnable & 0x1) << 0) | ((self.xHighInterruptEnable & 0x1) << 1) | ((self.yLowInterruptEnable & 0x1) << 2) | ((self.yHighInterruptEnable & 0x1) << 3) | ((self.zLowInterruptEvent & 0x1) << 4) | ((self.zHighInterruptEnable & 0x1) << 5) | ((self.detect6D & 0x1) << 6) | ((self.andOrInterruptEvents & 0x1) << 7)

        def setValue(self, value: int):
            self.xLowInterruptEnable = ((value >> 0) & 0x1)
            self.xHighInterruptEnable = ((value >> 1) & 0x1)
            self.yLowInterruptEnable = ((value >> 2) & 0x1)
            self.yHighInterruptEnable = ((value >> 3) & 0x1)
            self.zLowInterruptEvent = ((value >> 4) & 0x1)
            self.zHighInterruptEnable = ((value >> 5) & 0x1)
            self.detect6D = ((value >> 6) & 0x1)
            self.andOrInterruptEvents = ((value >> 7) & 0x1)

        def __str__(self):
            retVal = ""
            retVal += "XLowInterruptEnable: {} (offset: 0, width: 1)\r\n".format(self.xLowInterruptEnable)
            retVal += "XHighInterruptEnable: {} (offset: 1, width: 1)\r\n".format(self.xHighInterruptEnable)
            retVal += "YLowInterruptEnable: {} (offset: 2, width: 1)\r\n".format(self.yLowInterruptEnable)
            retVal += "YHighInterruptEnable: {} (offset: 3, width: 1)\r\n".format(self.yHighInterruptEnable)
            retVal += "ZLowInterruptEvent: {} (offset: 4, width: 1)\r\n".format(self.zLowInterruptEvent)
            retVal += "ZHighInterruptEnable: {} (offset: 5, width: 1)\r\n".format(self.zHighInterruptEnable)
            retVal += "Detect6D: {} (offset: 6, width: 1)\r\n".format(self.detect6D)
            retVal += "AndOrInterruptEvents: {} (offset: 7, width: 1)\r\n".format(self.andOrInterruptEvents)
            return retVal

    class InertialIntGen1StatusRegister(Register):
        def __init__(self, reg_manager: RegisterManager):
            Register.__init__(self, reg_manager, 0x31, 1, False)
            self.xLow = 0
            self.xHigh = 0
            self.yLow = 0
            self.yHigh = 0
            self.zLow = 0
            self.zHigh = 0
            self.intStatus = 0


        def read(self):
            self._manager.read(self)
            return self
            
        def getValue(self):
            return ((self.xLow & 0x1) << 0) | ((self.xHigh & 0x1) << 1) | ((self.yLow & 0x1) << 2) | ((self.yHigh & 0x1) << 3) | ((self.zLow & 0x1) << 4) | ((self.zHigh & 0x1) << 5) | ((self.intStatus & 0x1) << 6)

        def setValue(self, value: int):
            self.xLow = ((value >> 0) & 0x1)
            self.xHigh = ((value >> 1) & 0x1)
            self.yLow = ((value >> 2) & 0x1)
            self.yHigh = ((value >> 3) & 0x1)
            self.zLow = ((value >> 4) & 0x1)
            self.zHigh = ((value >> 5) & 0x1)
            self.intStatus = ((value >> 6) & 0x1)

        def __str__(self):
            retVal = ""
            retVal += "XLow: {} (offset: 0, width: 1)\r\n".format(self.xLow)
            retVal += "XHigh: {} (offset: 1, width: 1)\r\n".format(self.xHigh)
            retVal += "YLow: {} (offset: 2, width: 1)\r\n".format(self.yLow)
            retVal += "YHigh: {} (offset: 3, width: 1)\r\n".format(self.yHigh)
            retVal += "ZLow: {} (offset: 4, width: 1)\r\n".format(self.zLow)
            retVal += "ZHigh: {} (offset: 5, width: 1)\r\n".format(self.zHigh)
            retVal += "IntStatus: {} (offset: 6, width: 1)\r\n".format(self.intStatus)
            return retVal

    class InertialIntGen1ThresholdRegister(Register):
        def __init__(self, reg_manager: RegisterManager):
            Register.__init__(self, reg_manager, 0x32, 1, False)
            self.value = 0


        def read(self):
            self._manager.read(self)
            return self
            
        def getValue(self):
            return ((self.value & 0x7F) << 0)

        def setValue(self, value: int):
            self.value = ((value >> 0) & 0x7F)

        def __str__(self):
            retVal = ""
            retVal += "Value: {} (offset: 0, width: 7)\r\n".format(self.value)
            return retVal

    class InertialIntGen1DurationRegister(Register):
        def __init__(self, reg_manager: RegisterManager):
            Register.__init__(self, reg_manager, 0x33, 1, False)
            self.value = 0


        def read(self):
            self._manager.read(self)
            return self
            
        def getValue(self):
            return ((self.value & 0x7F) << 0)

        def setValue(self, value: int):
            self.value = ((value >> 0) & 0x7F)

        def __str__(self):
            retVal = ""
            retVal += "Value: {} (offset: 0, width: 7)\r\n".format(self.value)
            return retVal

    class InertialIntGen2ConfigRegister(Register):
        def __init__(self, reg_manager: RegisterManager):
            Register.__init__(self, reg_manager, 0x34, 1, False)
            self.xLowInterruptEnable = 0
            self.xHighInterruptEnable = 0
            self.yLowInterruptEnable = 0
            self.yHighInterruptEnable = 0
            self.zLowInterruptEvent = 0
            self.zHighInterruptEnable = 0
            self.detect6D = 0
            self.andOrInterruptEvents = 0


        def read(self):
            self._manager.read(self)
            return self
            
        def getValue(self):
            return ((self.xLowInterruptEnable & 0x1) << 0) | ((self.xHighInterruptEnable & 0x1) << 1) | ((self.yLowInterruptEnable & 0x1) << 2) | ((self.yHighInterruptEnable & 0x1) << 3) | ((self.zLowInterruptEvent & 0x1) << 4) | ((self.zHighInterruptEnable & 0x1) << 5) | ((self.detect6D & 0x1) << 6) | ((self.andOrInterruptEvents & 0x1) << 7)

        def setValue(self, value: int):
            self.xLowInterruptEnable = ((value >> 0) & 0x1)
            self.xHighInterruptEnable = ((value >> 1) & 0x1)
            self.yLowInterruptEnable = ((value >> 2) & 0x1)
            self.yHighInterruptEnable = ((value >> 3) & 0x1)
            self.zLowInterruptEvent = ((value >> 4) & 0x1)
            self.zHighInterruptEnable = ((value >> 5) & 0x1)
            self.detect6D = ((value >> 6) & 0x1)
            self.andOrInterruptEvents = ((value >> 7) & 0x1)

        def __str__(self):
            retVal = ""
            retVal += "XLowInterruptEnable: {} (offset: 0, width: 1)\r\n".format(self.xLowInterruptEnable)
            retVal += "XHighInterruptEnable: {} (offset: 1, width: 1)\r\n".format(self.xHighInterruptEnable)
            retVal += "YLowInterruptEnable: {} (offset: 2, width: 1)\r\n".format(self.yLowInterruptEnable)
            retVal += "YHighInterruptEnable: {} (offset: 3, width: 1)\r\n".format(self.yHighInterruptEnable)
            retVal += "ZLowInterruptEvent: {} (offset: 4, width: 1)\r\n".format(self.zLowInterruptEvent)
            retVal += "ZHighInterruptEnable: {} (offset: 5, width: 1)\r\n".format(self.zHighInterruptEnable)
            retVal += "Detect6D: {} (offset: 6, width: 1)\r\n".format(self.detect6D)
            retVal += "AndOrInterruptEvents: {} (offset: 7, width: 1)\r\n".format(self.andOrInterruptEvents)
            return retVal

    class InertialIntGen2StatusRegister(Register):
        def __init__(self, reg_manager: RegisterManager):
            Register.__init__(self, reg_manager, 0x35, 1, False)
            self.xLow = 0
            self.xHigh = 0
            self.yLow = 0
            self.yHigh = 0
            self.zLow = 0
            self.zHigh = 0
            self.intStatus = 0


        def read(self):
            self._manager.read(self)
            return self
            
        def getValue(self):
            return ((self.xLow & 0x1) << 0) | ((self.xHigh & 0x1) << 1) | ((self.yLow & 0x1) << 2) | ((self.yHigh & 0x1) << 3) | ((self.zLow & 0x1) << 4) | ((self.zHigh & 0x1) << 5) | ((self.intStatus & 0x1) << 6)

        def setValue(self, value: int):
            self.xLow = ((value >> 0) & 0x1)
            self.xHigh = ((value >> 1) & 0x1)
            self.yLow = ((value >> 2) & 0x1)
            self.yHigh = ((value >> 3) & 0x1)
            self.zLow = ((value >> 4) & 0x1)
            self.zHigh = ((value >> 5) & 0x1)
            self.intStatus = ((value >> 6) & 0x1)

        def __str__(self):
            retVal = ""
            retVal += "XLow: {} (offset: 0, width: 1)\r\n".format(self.xLow)
            retVal += "XHigh: {} (offset: 1, width: 1)\r\n".format(self.xHigh)
            retVal += "YLow: {} (offset: 2, width: 1)\r\n".format(self.yLow)
            retVal += "YHigh: {} (offset: 3, width: 1)\r\n".format(self.yHigh)
            retVal += "ZLow: {} (offset: 4, width: 1)\r\n".format(self.zLow)
            retVal += "ZHigh: {} (offset: 5, width: 1)\r\n".format(self.zHigh)
            retVal += "IntStatus: {} (offset: 6, width: 1)\r\n".format(self.intStatus)
            return retVal

    class InertialIntGen2ThresholdRegister(Register):
        def __init__(self, reg_manager: RegisterManager):
            Register.__init__(self, reg_manager, 0x36, 1, False)
            self.value = 0


        def read(self):
            self._manager.read(self)
            return self
            
        def getValue(self):
            return ((self.value & 0x7F) << 0)

        def setValue(self, value: int):
            self.value = ((value >> 0) & 0x7F)

        def __str__(self):
            retVal = ""
            retVal += "Value: {} (offset: 0, width: 7)\r\n".format(self.value)
            return retVal

    class InertialIntGen2DurationRegister(Register):
        def __init__(self, reg_manager: RegisterManager):
            Register.__init__(self, reg_manager, 0x37, 1, False)
            self.value = 0


        def read(self):
            self._manager.read(self)
            return self
            
        def getValue(self):
            return ((self.value & 0x7F) << 0)

        def setValue(self, value: int):
            self.value = ((value >> 0) & 0x7F)

        def __str__(self):
            retVal = ""
            retVal += "Value: {} (offset: 0, width: 7)\r\n".format(self.value)
            return retVal

    class ClickConfigRegister(Register):
        def __init__(self, reg_manager: RegisterManager):
            Register.__init__(self, reg_manager, 0x38, 1, False)
            self.xSingleClick = 0
            self.xDoubleClick = 0
            self.ySingleClick = 0
            self.yDoubleClick = 0
            self.zSingleClick = 0
            self.zDoubleClick = 0


        def read(self):
            self._manager.read(self)
            return self
            
        def getValue(self):
            return ((self.xSingleClick & 0x1) << 0) | ((self.xDoubleClick & 0x1) << 1) | ((self.ySingleClick & 0x1) << 2) | ((self.yDoubleClick & 0x1) << 3) | ((self.zSingleClick & 0x1) << 4) | ((self.zDoubleClick & 0x1) << 5)

        def setValue(self, value: int):
            self.xSingleClick = ((value >> 0) & 0x1)
            self.xDoubleClick = ((value >> 1) & 0x1)
            self.ySingleClick = ((value >> 2) & 0x1)
            self.yDoubleClick = ((value >> 3) & 0x1)
            self.zSingleClick = ((value >> 4) & 0x1)
            self.zDoubleClick = ((value >> 5) & 0x1)

        def __str__(self):
            retVal = ""
            retVal += "XSingleClick: {} (offset: 0, width: 1)\r\n".format(self.xSingleClick)
            retVal += "XDoubleClick: {} (offset: 1, width: 1)\r\n".format(self.xDoubleClick)
            retVal += "YSingleClick: {} (offset: 2, width: 1)\r\n".format(self.ySingleClick)
            retVal += "YDoubleClick: {} (offset: 3, width: 1)\r\n".format(self.yDoubleClick)
            retVal += "ZSingleClick: {} (offset: 4, width: 1)\r\n".format(self.zSingleClick)
            retVal += "ZDoubleClick: {} (offset: 5, width: 1)\r\n".format(self.zDoubleClick)
            return retVal

    class ClickSourceRegister(Register):
        def __init__(self, reg_manager: RegisterManager):
            Register.__init__(self, reg_manager, 0x39, 1, False)
            self.x = 0
            self.y = 0
            self.z = 0
            self.sign = 0
            self.singleClickEn = 0
            self.doubleClickEn = 0
            self.interruptActive = 0


        def read(self):
            self._manager.read(self)
            return self
            
        def getValue(self):
            return ((self.x & 0x1) << 0) | ((self.y & 0x1) << 1) | ((self.z & 0x1) << 2) | ((self.sign & 0x1) << 3) | ((self.singleClickEn & 0x1) << 4) | ((self.doubleClickEn & 0x1) << 5) | ((self.interruptActive & 0x1) << 6)

        def setValue(self, value: int):
            self.x = ((value >> 0) & 0x1)
            self.y = ((value >> 1) & 0x1)
            self.z = ((value >> 2) & 0x1)
            self.sign = ((value >> 3) & 0x1)
            self.singleClickEn = ((value >> 4) & 0x1)
            self.doubleClickEn = ((value >> 5) & 0x1)
            self.interruptActive = ((value >> 6) & 0x1)

        def __str__(self):
            retVal = ""
            retVal += "X: {} (offset: 0, width: 1)\r\n".format(self.x)
            retVal += "Y: {} (offset: 1, width: 1)\r\n".format(self.y)
            retVal += "Z: {} (offset: 2, width: 1)\r\n".format(self.z)
            retVal += "Sign: {} (offset: 3, width: 1)\r\n".format(self.sign)
            retVal += "SingleClickEn: {} (offset: 4, width: 1)\r\n".format(self.singleClickEn)
            retVal += "DoubleClickEn: {} (offset: 5, width: 1)\r\n".format(self.doubleClickEn)
            retVal += "InterruptActive: {} (offset: 6, width: 1)\r\n".format(self.interruptActive)
            return retVal

    class ClickThresholdRegister(Register):
        def __init__(self, reg_manager: RegisterManager):
            Register.__init__(self, reg_manager, 0x3A, 1, False)
            self.value = 0


        def read(self):
            self._manager.read(self)
            return self
            
        def getValue(self):
            return ((self.value & 0x7F) << 0)

        def setValue(self, value: int):
            self.value = ((value >> 0) & 0x7F)

        def __str__(self):
            retVal = ""
            retVal += "Value: {} (offset: 0, width: 7)\r\n".format(self.value)
            return retVal

    class TimeLimitRegister(Register):
        def __init__(self, reg_manager: RegisterManager):
            Register.__init__(self, reg_manager, 0x3b, 1, False)
            self.value = 0


        def read(self):
            self._manager.read(self)
            return self
            
        def getValue(self):
            return ((self.value & 0x7F) << 0)

        def setValue(self, value: int):
            self.value = ((value >> 0) & 0x7F)

        def __str__(self):
            retVal = ""
            retVal += "Value: {} (offset: 0, width: 7)\r\n".format(self.value)
            return retVal

    class TimeLatencyRegister(Register):
        def __init__(self, reg_manager: RegisterManager):
            Register.__init__(self, reg_manager, 0x3c, 1, False)
            self.value = 0


        def read(self):
            self._manager.read(self)
            return self
            
        def getValue(self):
            return ((self.value & 0xFF) << 0)

        def setValue(self, value: int):
            self.value = ((value >> 0) & 0xFF)

        def __str__(self):
            retVal = ""
            retVal += "Value: {} (offset: 0, width: 8)\r\n".format(self.value)
            return retVal

    class TimeWindowRegister(Register):
        def __init__(self, reg_manager: RegisterManager):
            Register.__init__(self, reg_manager, 0x3d, 1, False)
            self.value = 0


        def read(self):
            self._manager.read(self)
            return self
            
        def getValue(self):
            return ((self.value & 0xFF) << 0)

        def setValue(self, value: int):
            self.value = ((value >> 0) & 0xFF)

        def __str__(self):
            retVal = ""
            retVal += "Value: {} (offset: 0, width: 8)\r\n".format(self.value)
            return retVal

    class OutAccelXRegister(Register):
        def __init__(self, reg_manager: RegisterManager):
            Register.__init__(self, reg_manager, 0xa8, 2, False)
            self.value = 0


        def read(self):
            self._manager.read(self)
            return self
            
        def getValue(self):
            return ((self.value & 0xFFFF) << 0)

        def setValue(self, value: int):
            self.value = sign_extend((value >> 0) & 0xFFFF, 16)

        def __str__(self):
            retVal = ""
            retVal += "Value: {} (offset: 0, width: 16)\r\n".format(self.value)
            return retVal

    class OutAccelYRegister(Register):
        def __init__(self, reg_manager: RegisterManager):
            Register.__init__(self, reg_manager, 0xaA, 2, False)
            self.value = 0


        def read(self):
            self._manager.read(self)
            return self
            
        def getValue(self):
            return ((self.value & 0xFFFF) << 0)

        def setValue(self, value: int):
            self.value = sign_extend((value >> 0) & 0xFFFF, 16)

        def __str__(self):
            retVal = ""
            retVal += "Value: {} (offset: 0, width: 16)\r\n".format(self.value)
            return retVal

    class OutAccelZRegister(Register):
        def __init__(self, reg_manager: RegisterManager):
            Register.__init__(self, reg_manager, 0xaC, 2, False)
            self.value = 0


        def read(self):
            self._manager.read(self)
            return self
            
        def getValue(self):
            return ((self.value & 0xFFFF) << 0)

        def setValue(self, value: int):
            self.value = sign_extend((value >> 0) & 0xFFFF, 16)

        def __str__(self):
            retVal = ""
            retVal += "Value: {} (offset: 0, width: 16)\r\n".format(self.value)
            return retVal
