/// This file was auto-generated by RegisterGenerator. Any changes to it will be overwritten!
#pragma once
#include "SMBusDevice.h"
#include "Treehopper.Libraries.h"
#include "RegisterManager.h"
#include "Register.h"

using namespace Treehopper::Libraries;

namespace Treehopper { namespace Libraries { namespace IO { namespace Adc { 

    enum class ComparatorQueues
    {
        AssertAfterOneConversion = 0,
        AssertAfterTwoConversions = 1,
        AssertAfterFourConversions = 2,
        DisableComparator = 3
	};

    enum class DataRates
    {
        Sps_8 = 0,
        Sps_16 = 1,
        Sps_32 = 2,
        Sps_64 = 3,
        Sps_128 = 4,
        Sps_250 = 5,
        Sps_475 = 6,
        Sps_860 = 7
	};

    enum class Pgas
    {
        Fsr_6144 = 0,
        Fsr_4096 = 1,
        Fsr_2048 = 2,
        Fsr_1024 = 3,
        Fsr_512 = 4,
        Fsr_256 = 5
	};

    enum class Muxes
    {
        ain0_ain1 = 0,
        ain0_ain3 = 1,
        ain1_ain3 = 2,
        ain2_ain3 = 3,
        ain0_gnd = 4,
        ain1_gnd = 5,
        ain2_gnd = 6,
        ain3_gnd = 7
	};


    class Ads1115Registers : public RegisterManager
    {
    public:
        class ConversionRegister : public Register
        {
        public:
			ConversionRegister(RegisterManager& regManager) : Register(regManager,0x00, 2, true) { }
            int value;

            long getValue() { return ((value & 0xFFFF) << 0); }
            void setValue(long val)
            {
                value = (int)(((val >> 0) & 0xFFFF) << (32 - 16)) >> (32 - 16);
            }
        };

        class ConfigRegister : public Register
        {
        public:
			ConfigRegister(RegisterManager& regManager) : Register(regManager,0x01, 2, false) { }
            int comparatorQueue;
            int latchingComparator;
            int comparatorPolarity;
            int comparatorMode;
            int dataRate;
            int operatingMode;
            int pga;
            int mux;
            int operationalStatus;
            ComparatorQueues getComparatorQueue() { return (ComparatorQueues)comparatorQueue; }
            void setComparatorQueue(ComparatorQueues enumVal) { comparatorQueue = (int)enumVal; }
            DataRates getDataRate() { return (DataRates)dataRate; }
            void setDataRate(DataRates enumVal) { dataRate = (int)enumVal; }
            Pgas getPga() { return (Pgas)pga; }
            void setPga(Pgas enumVal) { pga = (int)enumVal; }
            Muxes getMux() { return (Muxes)mux; }
            void setMux(Muxes enumVal) { mux = (int)enumVal; }

            long getValue() { return ((comparatorQueue & 0x3) << 0) | ((latchingComparator & 0x1) << 2) | ((comparatorPolarity & 0x1) << 3) | ((comparatorMode & 0x1) << 4) | ((dataRate & 0x7) << 5) | ((operatingMode & 0x1) << 8) | ((pga & 0x7) << 9) | ((mux & 0x7) << 12) | ((operationalStatus & 0x1) << 15); }
            void setValue(long val)
            {
                comparatorQueue = (int)((val >> 0) & 0x3);
                latchingComparator = (int)((val >> 2) & 0x1);
                comparatorPolarity = (int)((val >> 3) & 0x1);
                comparatorMode = (int)((val >> 4) & 0x1);
                dataRate = (int)((val >> 5) & 0x7);
                operatingMode = (int)((val >> 8) & 0x1);
                pga = (int)((val >> 9) & 0x7);
                mux = (int)((val >> 12) & 0x7);
                operationalStatus = (int)((val >> 15) & 0x1);
            }
        };

        class LowThresholdRegister : public Register
        {
        public:
			LowThresholdRegister(RegisterManager& regManager) : Register(regManager,0x02, 2, true) { }
            int value;

            long getValue() { return ((value & 0xFFFF) << 0); }
            void setValue(long val)
            {
                value = (int)(((val >> 0) & 0xFFFF) << (32 - 16)) >> (32 - 16);
            }
        };

        class HighThresholdRegister : public Register
        {
        public:
			HighThresholdRegister(RegisterManager& regManager) : Register(regManager,0x03, 2, true) { }
            int value;

            long getValue() { return ((value & 0xFFFF) << 0); }
            void setValue(long val)
            {
                value = (int)(((val >> 0) & 0xFFFF) << (32 - 16)) >> (32 - 16);
            }
        };

            ConversionRegister conversion;
            ConfigRegister config;
            LowThresholdRegister lowThreshold;
            HighThresholdRegister highThreshold;

		Ads1115Registers(SMBusDevice& device) : RegisterManager(device, true), conversion(*this), config(*this), lowThreshold(*this), highThreshold(*this)
		{ 
			registers.push_back(&conversion);
			registers.push_back(&config);
			registers.push_back(&lowThreshold);
			registers.push_back(&highThreshold);
		}
    };
 }  }  } }