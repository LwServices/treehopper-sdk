/// This file was auto-generated by RegisterGenerator. Any changes to it will be overwritten!
#pragma once
#include "SMBusDevice.h"
#include "Treehopper.Libraries.h"
#include "RegisterManager.h"
#include "Register.h"

using namespace Treehopper::Libraries;

namespace Treehopper { namespace Libraries { namespace Sensors { namespace Inertial { 

    enum class OperatingModes
    {
        ConfigMode = 0,
        AccelOnly = 1,
        MagOnly = 2,
        GyroOnly = 3,
        AccelMag = 4,
        AccelGyro = 5,
        MagGyro = 6,
        AccelMagGyro = 7,
        IMU = 8,
        Compass = 9,
        MagnetForGyroscope = 10,
        NdofFmcOff = 11,
        NineDegreesOfFreedom = 12
	};

    enum class PowerModes
    {
        Normal = 0,
        LowPower = 1,
        Suspend = 2
	};


    class Bno055Registers : public RegisterManager
    {
    public:
        class ChipIdRegister : public Register
        {
        public:
			ChipIdRegister(RegisterManager& regManager) : Register(regManager,0x00, 1, false) { }
            int value;

            long getValue() { return ((value & 0xFF) << 0); }
            void setValue(long val)
            {
                value = (int)((val >> 0) & 0xFF);
            }
        };

        class AccelChipIdRegister : public Register
        {
        public:
			AccelChipIdRegister(RegisterManager& regManager) : Register(regManager,0x01, 1, false) { }
            int value;

            long getValue() { return ((value & 0xFF) << 0); }
            void setValue(long val)
            {
                value = (int)((val >> 0) & 0xFF);
            }
        };

        class MagChipIdRegister : public Register
        {
        public:
			MagChipIdRegister(RegisterManager& regManager) : Register(regManager,0x02, 1, false) { }
            int value;

            long getValue() { return ((value & 0xFF) << 0); }
            void setValue(long val)
            {
                value = (int)((val >> 0) & 0xFF);
            }
        };

        class GyroChipIdRegister : public Register
        {
        public:
			GyroChipIdRegister(RegisterManager& regManager) : Register(regManager,0x03, 1, false) { }
            int value;

            long getValue() { return ((value & 0xFF) << 0); }
            void setValue(long val)
            {
                value = (int)((val >> 0) & 0xFF);
            }
        };

        class SwRevisionRegister : public Register
        {
        public:
			SwRevisionRegister(RegisterManager& regManager) : Register(regManager,0x04, 2, false) { }
            int value;

            long getValue() { return ((value & 0xFFFF) << 0); }
            void setValue(long val)
            {
                value = (int)((val >> 0) & 0xFFFF);
            }
        };

        class BootloaderVersionRegister : public Register
        {
        public:
			BootloaderVersionRegister(RegisterManager& regManager) : Register(regManager,0x06, 1, false) { }
            int value;

            long getValue() { return ((value & 0xFF) << 0); }
            void setValue(long val)
            {
                value = (int)((val >> 0) & 0xFF);
            }
        };

        class PageIdRegister : public Register
        {
        public:
			PageIdRegister(RegisterManager& regManager) : Register(regManager,0x07, 1, false) { }
            int value;

            long getValue() { return ((value & 0xFF) << 0); }
            void setValue(long val)
            {
                value = (int)((val >> 0) & 0xFF);
            }
        };

        class AccelXRegister : public Register
        {
        public:
			AccelXRegister(RegisterManager& regManager) : Register(regManager,0x08, 2, false) { }
            int value;

            long getValue() { return ((value & 0xFFFF) << 0); }
            void setValue(long val)
            {
                value = (int)(((val >> 0) & 0xFFFF) << (32 - 16)) >> (32 - 16);
            }
        };

        class AccelYRegister : public Register
        {
        public:
			AccelYRegister(RegisterManager& regManager) : Register(regManager,0x0A, 2, false) { }
            int value;

            long getValue() { return ((value & 0xFFFF) << 0); }
            void setValue(long val)
            {
                value = (int)(((val >> 0) & 0xFFFF) << (32 - 16)) >> (32 - 16);
            }
        };

        class AccelZRegister : public Register
        {
        public:
			AccelZRegister(RegisterManager& regManager) : Register(regManager,0x0C, 2, false) { }
            int value;

            long getValue() { return ((value & 0xFFFF) << 0); }
            void setValue(long val)
            {
                value = (int)(((val >> 0) & 0xFFFF) << (32 - 16)) >> (32 - 16);
            }
        };

        class MagnetometerXRegister : public Register
        {
        public:
			MagnetometerXRegister(RegisterManager& regManager) : Register(regManager,0x0E, 2, false) { }
            int value;

            long getValue() { return ((value & 0xFFFF) << 0); }
            void setValue(long val)
            {
                value = (int)(((val >> 0) & 0xFFFF) << (32 - 16)) >> (32 - 16);
            }
        };

        class MagnetometerYRegister : public Register
        {
        public:
			MagnetometerYRegister(RegisterManager& regManager) : Register(regManager,0x10, 2, false) { }
            int value;

            long getValue() { return ((value & 0xFFFF) << 0); }
            void setValue(long val)
            {
                value = (int)(((val >> 0) & 0xFFFF) << (32 - 16)) >> (32 - 16);
            }
        };

        class MagnetometerZRegister : public Register
        {
        public:
			MagnetometerZRegister(RegisterManager& regManager) : Register(regManager,0x12, 2, false) { }
            int value;

            long getValue() { return ((value & 0xFFFF) << 0); }
            void setValue(long val)
            {
                value = (int)(((val >> 0) & 0xFFFF) << (32 - 16)) >> (32 - 16);
            }
        };

        class GyroXRegister : public Register
        {
        public:
			GyroXRegister(RegisterManager& regManager) : Register(regManager,0x14, 2, false) { }
            int value;

            long getValue() { return ((value & 0xFFFF) << 0); }
            void setValue(long val)
            {
                value = (int)(((val >> 0) & 0xFFFF) << (32 - 16)) >> (32 - 16);
            }
        };

        class GyroYRegister : public Register
        {
        public:
			GyroYRegister(RegisterManager& regManager) : Register(regManager,0x16, 2, false) { }
            int value;

            long getValue() { return ((value & 0xFFFF) << 0); }
            void setValue(long val)
            {
                value = (int)(((val >> 0) & 0xFFFF) << (32 - 16)) >> (32 - 16);
            }
        };

        class GyroZRegister : public Register
        {
        public:
			GyroZRegister(RegisterManager& regManager) : Register(regManager,0x18, 2, false) { }
            int value;

            long getValue() { return ((value & 0xFFFF) << 0); }
            void setValue(long val)
            {
                value = (int)(((val >> 0) & 0xFFFF) << (32 - 16)) >> (32 - 16);
            }
        };

        class EulHeadingRegister : public Register
        {
        public:
			EulHeadingRegister(RegisterManager& regManager) : Register(regManager,0x1A, 2, false) { }
            int value;

            long getValue() { return ((value & 0xFFFF) << 0); }
            void setValue(long val)
            {
                value = (int)(((val >> 0) & 0xFFFF) << (32 - 16)) >> (32 - 16);
            }
        };

        class EulRollRegister : public Register
        {
        public:
			EulRollRegister(RegisterManager& regManager) : Register(regManager,0x1C, 2, false) { }
            int value;

            long getValue() { return ((value & 0xFFFF) << 0); }
            void setValue(long val)
            {
                value = (int)(((val >> 0) & 0xFFFF) << (32 - 16)) >> (32 - 16);
            }
        };

        class EulPitchRegister : public Register
        {
        public:
			EulPitchRegister(RegisterManager& regManager) : Register(regManager,0x1E, 2, false) { }
            int value;

            long getValue() { return ((value & 0xFFFF) << 0); }
            void setValue(long val)
            {
                value = (int)(((val >> 0) & 0xFFFF) << (32 - 16)) >> (32 - 16);
            }
        };

        class QuaWRegister : public Register
        {
        public:
			QuaWRegister(RegisterManager& regManager) : Register(regManager,0x20, 2, false) { }
            int value;

            long getValue() { return ((value & 0xFFFF) << 0); }
            void setValue(long val)
            {
                value = (int)(((val >> 0) & 0xFFFF) << (32 - 16)) >> (32 - 16);
            }
        };

        class QuaXRegister : public Register
        {
        public:
			QuaXRegister(RegisterManager& regManager) : Register(regManager,0x22, 2, false) { }
            int value;

            long getValue() { return ((value & 0xFFFF) << 0); }
            void setValue(long val)
            {
                value = (int)(((val >> 0) & 0xFFFF) << (32 - 16)) >> (32 - 16);
            }
        };

        class QuaYRegister : public Register
        {
        public:
			QuaYRegister(RegisterManager& regManager) : Register(regManager,0x24, 2, false) { }
            int value;

            long getValue() { return ((value & 0xFFFF) << 0); }
            void setValue(long val)
            {
                value = (int)(((val >> 0) & 0xFFFF) << (32 - 16)) >> (32 - 16);
            }
        };

        class QuaZRegister : public Register
        {
        public:
			QuaZRegister(RegisterManager& regManager) : Register(regManager,0x26, 2, false) { }
            int value;

            long getValue() { return ((value & 0xFFFF) << 0); }
            void setValue(long val)
            {
                value = (int)(((val >> 0) & 0xFFFF) << (32 - 16)) >> (32 - 16);
            }
        };

        class LinXRegister : public Register
        {
        public:
			LinXRegister(RegisterManager& regManager) : Register(regManager,0x28, 2, false) { }
            int value;

            long getValue() { return ((value & 0xFFFF) << 0); }
            void setValue(long val)
            {
                value = (int)(((val >> 0) & 0xFFFF) << (32 - 16)) >> (32 - 16);
            }
        };

        class LinYRegister : public Register
        {
        public:
			LinYRegister(RegisterManager& regManager) : Register(regManager,0x2A, 2, false) { }
            int value;

            long getValue() { return ((value & 0xFFFF) << 0); }
            void setValue(long val)
            {
                value = (int)(((val >> 0) & 0xFFFF) << (32 - 16)) >> (32 - 16);
            }
        };

        class LinZRegister : public Register
        {
        public:
			LinZRegister(RegisterManager& regManager) : Register(regManager,0x2C, 2, false) { }
            int value;

            long getValue() { return ((value & 0xFFFF) << 0); }
            void setValue(long val)
            {
                value = (int)(((val >> 0) & 0xFFFF) << (32 - 16)) >> (32 - 16);
            }
        };

        class GravXRegister : public Register
        {
        public:
			GravXRegister(RegisterManager& regManager) : Register(regManager,0x2E, 2, false) { }
            int value;

            long getValue() { return ((value & 0xFFFF) << 0); }
            void setValue(long val)
            {
                value = (int)(((val >> 0) & 0xFFFF) << (32 - 16)) >> (32 - 16);
            }
        };

        class GravYRegister : public Register
        {
        public:
			GravYRegister(RegisterManager& regManager) : Register(regManager,0x30, 2, false) { }
            int value;

            long getValue() { return ((value & 0xFFFF) << 0); }
            void setValue(long val)
            {
                value = (int)(((val >> 0) & 0xFFFF) << (32 - 16)) >> (32 - 16);
            }
        };

        class GravZRegister : public Register
        {
        public:
			GravZRegister(RegisterManager& regManager) : Register(regManager,0x32, 2, false) { }
            int value;

            long getValue() { return ((value & 0xFFFF) << 0); }
            void setValue(long val)
            {
                value = (int)(((val >> 0) & 0xFFFF) << (32 - 16)) >> (32 - 16);
            }
        };

        class TempRegister : public Register
        {
        public:
			TempRegister(RegisterManager& regManager) : Register(regManager,0x34, 1, false) { }
            int value;

            long getValue() { return ((value & 0xFF) << 0); }
            void setValue(long val)
            {
                value = (int)((val >> 0) & 0xFF);
            }
        };

        class CalibStatRegister : public Register
        {
        public:
			CalibStatRegister(RegisterManager& regManager) : Register(regManager,0x35, 1, false) { }
            int magCalibStatus;
            int accelCalibStatus;
            int gyroCalibStatus;
            int sysCalibStatus;

            long getValue() { return ((magCalibStatus & 0x3) << 0) | ((accelCalibStatus & 0x3) << 2) | ((gyroCalibStatus & 0x3) << 4) | ((sysCalibStatus & 0x3) << 6); }
            void setValue(long val)
            {
                magCalibStatus = (int)((val >> 0) & 0x3);
                accelCalibStatus = (int)((val >> 2) & 0x3);
                gyroCalibStatus = (int)((val >> 4) & 0x3);
                sysCalibStatus = (int)((val >> 6) & 0x3);
            }
        };

        class SelfTestResultRegister : public Register
        {
        public:
			SelfTestResultRegister(RegisterManager& regManager) : Register(regManager,0x36, 1, false) { }
            int accel;
            int mag;
            int gyro;
            int mcu;

            long getValue() { return ((accel & 0x1) << 0) | ((mag & 0x1) << 1) | ((gyro & 0x1) << 2) | ((mcu & 0x1) << 3); }
            void setValue(long val)
            {
                accel = (int)((val >> 0) & 0x1);
                mag = (int)((val >> 1) & 0x1);
                gyro = (int)((val >> 2) & 0x1);
                mcu = (int)((val >> 3) & 0x1);
            }
        };

        class InterruptStatusRegister : public Register
        {
        public:
			InterruptStatusRegister(RegisterManager& regManager) : Register(regManager,0x37, 1, false) { }
            int gyroAnyMotion;
            int gyroHighRate;
            int accelHighG;
            int accelAnyMotion;
            int accelNoMotion;

            long getValue() { return ((gyroAnyMotion & 0x1) << 2) | ((gyroHighRate & 0x1) << 3) | ((accelHighG & 0x1) << 5) | ((accelAnyMotion & 0x1) << 6) | ((accelNoMotion & 0x1) << 7); }
            void setValue(long val)
            {
                gyroAnyMotion = (int)((val >> 2) & 0x1);
                gyroHighRate = (int)((val >> 3) & 0x1);
                accelHighG = (int)((val >> 5) & 0x1);
                accelAnyMotion = (int)((val >> 6) & 0x1);
                accelNoMotion = (int)((val >> 7) & 0x1);
            }
        };

        class SysClockStatusRegister : public Register
        {
        public:
			SysClockStatusRegister(RegisterManager& regManager) : Register(regManager,0x38, 1, false) { }
            int mainClock;

            long getValue() { return ((mainClock & 0x1) << 0); }
            void setValue(long val)
            {
                mainClock = (int)((val >> 0) & 0x1);
            }
        };

        class SysStatusRegister : public Register
        {
        public:
			SysStatusRegister(RegisterManager& regManager) : Register(regManager,0x39, 1, false) { }
            int value;

            long getValue() { return ((value & 0xFF) << 0); }
            void setValue(long val)
            {
                value = (int)((val >> 0) & 0xFF);
            }
        };

        class SysErrRegister : public Register
        {
        public:
			SysErrRegister(RegisterManager& regManager) : Register(regManager,0x3a, 1, false) { }
            int value;

            long getValue() { return ((value & 0xFF) << 0); }
            void setValue(long val)
            {
                value = (int)((val >> 0) & 0xFF);
            }
        };

        class UnitSelRegister : public Register
        {
        public:
			UnitSelRegister(RegisterManager& regManager) : Register(regManager,0x3b, 1, false) { }
            int accel;
            int gyro;
            int eular;
            int temp;
            int orientationMode;

            long getValue() { return ((accel & 0x1) << 0) | ((gyro & 0x1) << 1) | ((eular & 0x1) << 2) | ((temp & 0x1) << 4) | ((orientationMode & 0x1) << 7); }
            void setValue(long val)
            {
                accel = (int)((val >> 0) & 0x1);
                gyro = (int)((val >> 1) & 0x1);
                eular = (int)((val >> 2) & 0x1);
                temp = (int)((val >> 4) & 0x1);
                orientationMode = (int)((val >> 7) & 0x1);
            }
        };

        class OperatingModeRegister : public Register
        {
        public:
			OperatingModeRegister(RegisterManager& regManager) : Register(regManager,0x3d, 1, false) { }
            int operatingMode;
            OperatingModes getOperatingMode() { return (OperatingModes)operatingMode; }
            void setOperatingMode(OperatingModes enumVal) { operatingMode = (int)enumVal; }

            long getValue() { return ((operatingMode & 0xF) << 0); }
            void setValue(long val)
            {
                operatingMode = (int)((val >> 0) & 0xF);
            }
        };

        class PowerModeRegister : public Register
        {
        public:
			PowerModeRegister(RegisterManager& regManager) : Register(regManager,0x3e, 1, false) { }
            int powerMode;
            PowerModes getPowerMode() { return (PowerModes)powerMode; }
            void setPowerMode(PowerModes enumVal) { powerMode = (int)enumVal; }

            long getValue() { return ((powerMode & 0x3) << 0); }
            void setValue(long val)
            {
                powerMode = (int)((val >> 0) & 0x3);
            }
        };

        class SysTriggerRegister : public Register
        {
        public:
			SysTriggerRegister(RegisterManager& regManager) : Register(regManager,0x3f, 1, false) { }
            int selfTest;
            int resetSys;
            int resetInt;
            int clockSel;

            long getValue() { return ((selfTest & 0x1) << 0) | ((resetSys & 0x1) << 5) | ((resetInt & 0x1) << 6) | ((clockSel & 0x1) << 7); }
            void setValue(long val)
            {
                selfTest = (int)((val >> 0) & 0x1);
                resetSys = (int)((val >> 5) & 0x1);
                resetInt = (int)((val >> 6) & 0x1);
                clockSel = (int)((val >> 7) & 0x1);
            }
        };

        class TempSourceRegister : public Register
        {
        public:
			TempSourceRegister(RegisterManager& regManager) : Register(regManager,0x40, 1, false) { }
            int source;

            long getValue() { return ((source & 0x3) << 0); }
            void setValue(long val)
            {
                source = (int)((val >> 0) & 0x3);
            }
        };

        class AxisMapConfigRegister : public Register
        {
        public:
			AxisMapConfigRegister(RegisterManager& regManager) : Register(regManager,0x41, 1, false) { }
            int x;
            int y;
            int z;

            long getValue() { return ((x & 0x3) << 0) | ((y & 0x3) << 2) | ((z & 0x3) << 4); }
            void setValue(long val)
            {
                x = (int)((val >> 0) & 0x3);
                y = (int)((val >> 2) & 0x3);
                z = (int)((val >> 4) & 0x3);
            }
        };

        class AxisMapSignRegister : public Register
        {
        public:
			AxisMapSignRegister(RegisterManager& regManager) : Register(regManager,0x41, 1, false) { }
            int x;
            int y;
            int z;

            long getValue() { return ((x & 0x1) << 0) | ((y & 0x1) << 1) | ((z & 0x1) << 2); }
            void setValue(long val)
            {
                x = (int)((val >> 0) & 0x1);
                y = (int)((val >> 1) & 0x1);
                z = (int)((val >> 2) & 0x1);
            }
        };

        class AccelOffsetXRegister : public Register
        {
        public:
			AccelOffsetXRegister(RegisterManager& regManager) : Register(regManager,0x55, 2, false) { }
            int value;

            long getValue() { return ((value & 0xFFFF) << 0); }
            void setValue(long val)
            {
                value = (int)(((val >> 0) & 0xFFFF) << (32 - 16)) >> (32 - 16);
            }
        };

        class AccelOffsetYRegister : public Register
        {
        public:
			AccelOffsetYRegister(RegisterManager& regManager) : Register(regManager,0x57, 2, false) { }
            int value;

            long getValue() { return ((value & 0xFFFF) << 0); }
            void setValue(long val)
            {
                value = (int)(((val >> 0) & 0xFFFF) << (32 - 16)) >> (32 - 16);
            }
        };

        class AccelOffsetZRegister : public Register
        {
        public:
			AccelOffsetZRegister(RegisterManager& regManager) : Register(regManager,0x59, 2, false) { }
            int value;

            long getValue() { return ((value & 0xFFFF) << 0); }
            void setValue(long val)
            {
                value = (int)(((val >> 0) & 0xFFFF) << (32 - 16)) >> (32 - 16);
            }
        };

        class MagnetometerOffsetXRegister : public Register
        {
        public:
			MagnetometerOffsetXRegister(RegisterManager& regManager) : Register(regManager,0x5B, 2, false) { }
            int value;

            long getValue() { return ((value & 0xFFFF) << 0); }
            void setValue(long val)
            {
                value = (int)(((val >> 0) & 0xFFFF) << (32 - 16)) >> (32 - 16);
            }
        };

        class MagnetometerOffsetYRegister : public Register
        {
        public:
			MagnetometerOffsetYRegister(RegisterManager& regManager) : Register(regManager,0x5D, 2, false) { }
            int value;

            long getValue() { return ((value & 0xFFFF) << 0); }
            void setValue(long val)
            {
                value = (int)(((val >> 0) & 0xFFFF) << (32 - 16)) >> (32 - 16);
            }
        };

        class MagnetometerOffsetZRegister : public Register
        {
        public:
			MagnetometerOffsetZRegister(RegisterManager& regManager) : Register(regManager,0x5F, 2, false) { }
            int value;

            long getValue() { return ((value & 0xFFFF) << 0); }
            void setValue(long val)
            {
                value = (int)(((val >> 0) & 0xFFFF) << (32 - 16)) >> (32 - 16);
            }
        };

        class GyroOffsetXRegister : public Register
        {
        public:
			GyroOffsetXRegister(RegisterManager& regManager) : Register(regManager,0x61, 2, false) { }
            int value;

            long getValue() { return ((value & 0xFFFF) << 0); }
            void setValue(long val)
            {
                value = (int)(((val >> 0) & 0xFFFF) << (32 - 16)) >> (32 - 16);
            }
        };

        class GyroOffsetYRegister : public Register
        {
        public:
			GyroOffsetYRegister(RegisterManager& regManager) : Register(regManager,0x63, 2, false) { }
            int value;

            long getValue() { return ((value & 0xFFFF) << 0); }
            void setValue(long val)
            {
                value = (int)(((val >> 0) & 0xFFFF) << (32 - 16)) >> (32 - 16);
            }
        };

        class GyroOffsetZRegister : public Register
        {
        public:
			GyroOffsetZRegister(RegisterManager& regManager) : Register(regManager,0x65, 2, false) { }
            int value;

            long getValue() { return ((value & 0xFFFF) << 0); }
            void setValue(long val)
            {
                value = (int)(((val >> 0) & 0xFFFF) << (32 - 16)) >> (32 - 16);
            }
        };

        class AccelRadiusRegister : public Register
        {
        public:
			AccelRadiusRegister(RegisterManager& regManager) : Register(regManager,0x67, 2, false) { }
            int value;

            long getValue() { return ((value & 0xFFFF) << 0); }
            void setValue(long val)
            {
                value = (int)(((val >> 0) & 0xFFFF) << (32 - 16)) >> (32 - 16);
            }
        };

        class MagRadiusRegister : public Register
        {
        public:
			MagRadiusRegister(RegisterManager& regManager) : Register(regManager,0x69, 2, false) { }
            int value;

            long getValue() { return ((value & 0xFFFF) << 0); }
            void setValue(long val)
            {
                value = (int)(((val >> 0) & 0xFFFF) << (32 - 16)) >> (32 - 16);
            }
        };

            ChipIdRegister chipId;
            AccelChipIdRegister accelChipId;
            MagChipIdRegister magChipId;
            GyroChipIdRegister gyroChipId;
            SwRevisionRegister swRevision;
            BootloaderVersionRegister bootloaderVersion;
            PageIdRegister pageId;
            AccelXRegister accelX;
            AccelYRegister accelY;
            AccelZRegister accelZ;
            MagnetometerXRegister magnetometerX;
            MagnetometerYRegister magnetometerY;
            MagnetometerZRegister magnetometerZ;
            GyroXRegister gyroX;
            GyroYRegister gyroY;
            GyroZRegister gyroZ;
            EulHeadingRegister eulHeading;
            EulRollRegister eulRoll;
            EulPitchRegister eulPitch;
            QuaWRegister quaW;
            QuaXRegister quaX;
            QuaYRegister quaY;
            QuaZRegister quaZ;
            LinXRegister linX;
            LinYRegister linY;
            LinZRegister linZ;
            GravXRegister gravX;
            GravYRegister gravY;
            GravZRegister gravZ;
            TempRegister temp;
            CalibStatRegister calibStat;
            SelfTestResultRegister selfTestResult;
            InterruptStatusRegister interruptStatus;
            SysClockStatusRegister sysClockStatus;
            SysStatusRegister sysStatus;
            SysErrRegister sysErr;
            UnitSelRegister unitSel;
            OperatingModeRegister operatingMode;
            PowerModeRegister powerMode;
            SysTriggerRegister sysTrigger;
            TempSourceRegister tempSource;
            AxisMapConfigRegister axisMapConfig;
            AxisMapSignRegister axisMapSign;
            AccelOffsetXRegister accelOffsetX;
            AccelOffsetYRegister accelOffsetY;
            AccelOffsetZRegister accelOffsetZ;
            MagnetometerOffsetXRegister magnetometerOffsetX;
            MagnetometerOffsetYRegister magnetometerOffsetY;
            MagnetometerOffsetZRegister magnetometerOffsetZ;
            GyroOffsetXRegister gyroOffsetX;
            GyroOffsetYRegister gyroOffsetY;
            GyroOffsetZRegister gyroOffsetZ;
            AccelRadiusRegister accelRadius;
            MagRadiusRegister magRadius;

		Bno055Registers(SMBusDevice& device) : RegisterManager(device, true), chipId(*this), accelChipId(*this), magChipId(*this), gyroChipId(*this), swRevision(*this), bootloaderVersion(*this), pageId(*this), accelX(*this), accelY(*this), accelZ(*this), magnetometerX(*this), magnetometerY(*this), magnetometerZ(*this), gyroX(*this), gyroY(*this), gyroZ(*this), eulHeading(*this), eulRoll(*this), eulPitch(*this), quaW(*this), quaX(*this), quaY(*this), quaZ(*this), linX(*this), linY(*this), linZ(*this), gravX(*this), gravY(*this), gravZ(*this), temp(*this), calibStat(*this), selfTestResult(*this), interruptStatus(*this), sysClockStatus(*this), sysStatus(*this), sysErr(*this), unitSel(*this), operatingMode(*this), powerMode(*this), sysTrigger(*this), tempSource(*this), axisMapConfig(*this), axisMapSign(*this), accelOffsetX(*this), accelOffsetY(*this), accelOffsetZ(*this), magnetometerOffsetX(*this), magnetometerOffsetY(*this), magnetometerOffsetZ(*this), gyroOffsetX(*this), gyroOffsetY(*this), gyroOffsetZ(*this), accelRadius(*this), magRadius(*this)
		{ 
			registers.push_back(&chipId);
			registers.push_back(&accelChipId);
			registers.push_back(&magChipId);
			registers.push_back(&gyroChipId);
			registers.push_back(&swRevision);
			registers.push_back(&bootloaderVersion);
			registers.push_back(&pageId);
			registers.push_back(&accelX);
			registers.push_back(&accelY);
			registers.push_back(&accelZ);
			registers.push_back(&magnetometerX);
			registers.push_back(&magnetometerY);
			registers.push_back(&magnetometerZ);
			registers.push_back(&gyroX);
			registers.push_back(&gyroY);
			registers.push_back(&gyroZ);
			registers.push_back(&eulHeading);
			registers.push_back(&eulRoll);
			registers.push_back(&eulPitch);
			registers.push_back(&quaW);
			registers.push_back(&quaX);
			registers.push_back(&quaY);
			registers.push_back(&quaZ);
			registers.push_back(&linX);
			registers.push_back(&linY);
			registers.push_back(&linZ);
			registers.push_back(&gravX);
			registers.push_back(&gravY);
			registers.push_back(&gravZ);
			registers.push_back(&temp);
			registers.push_back(&calibStat);
			registers.push_back(&selfTestResult);
			registers.push_back(&interruptStatus);
			registers.push_back(&sysClockStatus);
			registers.push_back(&sysStatus);
			registers.push_back(&sysErr);
			registers.push_back(&unitSel);
			registers.push_back(&operatingMode);
			registers.push_back(&powerMode);
			registers.push_back(&sysTrigger);
			registers.push_back(&tempSource);
			registers.push_back(&axisMapConfig);
			registers.push_back(&axisMapSign);
			registers.push_back(&accelOffsetX);
			registers.push_back(&accelOffsetY);
			registers.push_back(&accelOffsetZ);
			registers.push_back(&magnetometerOffsetX);
			registers.push_back(&magnetometerOffsetY);
			registers.push_back(&magnetometerOffsetZ);
			registers.push_back(&gyroOffsetX);
			registers.push_back(&gyroOffsetY);
			registers.push_back(&gyroOffsetZ);
			registers.push_back(&accelRadius);
			registers.push_back(&magRadius);
		}
    };
 }  }  } }