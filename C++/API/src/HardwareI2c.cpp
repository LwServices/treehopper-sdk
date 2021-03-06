#include "TreehopperUsb.h"
#include "HardwareI2c.h"
#include "Utility.h"
#include "I2cTransferException.h"
#include <math.h>
#include <algorithm>


using namespace std;

namespace Treehopper {
    HardwareI2c::HardwareI2c(TreehopperUsb &board) : board(board), _speed(100) {
    }


    HardwareI2c::~HardwareI2c() {

    }

    void HardwareI2c::speed(double value) {
        this->_speed = value;
        sendConfig();
    }

    double HardwareI2c::speed() {
        return this->_speed;
    }

    void HardwareI2c::enabled(bool value) {
        if (this->_enabled == value) return;

        this->_enabled = value;

        sendConfig();

        if (_enabled) {
            board.pins[3].mode(PinMode::Reserved);
            board.pins[4].mode(PinMode::Reserved);
        } else {
            board.pins[3].mode(PinMode::Unassigned);
            board.pins[4].mode(PinMode::Unassigned);
        }
    }

    bool HardwareI2c::enabled() {
        return false;
    }

    std::vector<uint8_t> HardwareI2c::sendReceive(uint8_t address, std::vector<uint8_t> data, size_t numBytesToRead) {
        int numBytesToWrite = data.size();
        std::vector<uint8_t> receivedData(numBytesToRead + 1);

        std::vector<uint8_t> dataToSend(4);
        dataToSend.reserve(4 + numBytesToWrite);
        dataToSend[0] = (uint8_t) TreehopperUsb::DeviceCommands::I2cTransaction;
        dataToSend[1] = address;
        dataToSend[2] = (uint8_t) numBytesToWrite; // total length (0-255)
        dataToSend[3] = (uint8_t) numBytesToRead;

        dataToSend.insert(dataToSend.end(), data.begin(), data.end());

        int offset = 0;
        size_t bytesRemaining = 4 + numBytesToWrite;

        while (bytesRemaining > 0) {
            size_t transferLength = bytesRemaining > 64 ? 64 : bytesRemaining;
            board.sendPeripheralConfigPacket(&dataToSend[offset], transferLength);
            offset += transferLength;
            bytesRemaining -= transferLength;
        }

        if (numBytesToRead == 0) {
            uint8_t responseCode;
            board.receivePeripheralConfigPacket(&responseCode, 1);
            if (responseCode != 255) {
                I2cTransferException ex((I2cTransferError) responseCode);
                Utility::error(ex);
            }
        } else {
            bytesRemaining = numBytesToRead + 1; // received data length + status byte
            int offset = 0;

            while (bytesRemaining > 0) {
                size_t numBytesToTransfer = bytesRemaining > 64 ? 64 : bytesRemaining;
                board.receivePeripheralConfigPacket(&receivedData[offset], numBytesToTransfer);
                offset += numBytesToTransfer;
                bytesRemaining -= numBytesToTransfer;
            }

            if (receivedData[0] != 255) {
                I2cTransferException ex((I2cTransferError) receivedData[0]);
                Utility::error(ex);
            } else {
                receivedData.erase(receivedData.begin()); // remove the response code
            }
        }

        return receivedData;
    }

    void HardwareI2c::sendConfig() {
        double th0 = round(256.0 - (4000.0 / (3.0 * _speed)));
        if (th0 < 0 || th0 > 255.0) {
            throw "Rate out of limits. Valid rate is 62.5 kHz - 16000 kHz (16 MHz)";
        }

        uint8_t dataToSend[3];
        dataToSend[0] = (uint8_t) TreehopperUsb::DeviceCommands::I2cConfig;
        dataToSend[1] = _enabled;
        dataToSend[2] = (uint8_t) th0;
        board.sendPeripheralConfigPacket(dataToSend, 3);
    }
}