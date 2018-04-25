#include "WinUsbConnection.h"
#include "Utility.h"
#include <iostream>

using namespace std;

namespace Treehopper 
{
	void debugPrintLastError();

	WinUsbConnection::WinUsbConnection(wstring devicePath, wstring friendlyName, wstring serialNumber, int rev)
	{
		_devicePath = devicePath;
		_serialNumber = serialNumber;
		_name = friendlyName;
		_rev = rev;
	}

	WinUsbConnection::~WinUsbConnection()
	{
	}

	bool WinUsbConnection::open()
	{
		deviceData.DeviceHandle = CreateFile(_devicePath.c_str(),
			GENERIC_WRITE | GENERIC_READ,
			FILE_SHARE_WRITE | FILE_SHARE_READ,
			NULL,
			OPEN_EXISTING,
			FILE_ATTRIBUTE_NORMAL | FILE_FLAG_OVERLAPPED,
			NULL);

		if (deviceData.DeviceHandle == INVALID_HANDLE_VALUE)
		{
			debugPrintLastError();
			return false;
		}

		if (WinUsb_Initialize(deviceData.DeviceHandle, &deviceData.WinusbHandle) == FALSE)
		{
			debugPrintLastError();
			return false;
		}

		deviceData.HandlesOpen = true;

		OutputDebugString(L"Device Opened");

		return true;
	}

	void WinUsbConnection::close()
	{
		if (!deviceData.HandlesOpen)
			return;

		WinUsb_Free(deviceData.WinusbHandle);
		CloseHandle(deviceData.DeviceHandle);
		deviceData.HandlesOpen = false;
		OutputDebugString(L"Device Closed");
	}

	void WinUsbConnection::sendDataPinConfigChannel(uint8_t* data, size_t len)
	{
		ULONG sent = 0;
		WinUsb_WritePipe(deviceData.WinusbHandle, pinConfigEndpoint, data, len, &sent, 0);
		if (sent != len)
			throw - 1;
	}

	void WinUsbConnection::sendDataPeripheralChannel(uint8_t* data, size_t len)
	{
		ULONG sent = 0;
		WinUsb_WritePipe(deviceData.WinusbHandle, peripheralConfigEndpoint, data, len, &sent, 0);
		if (sent != len)
			throw - 1;
	}

	wstring WinUsbConnection::serialNumber()
	{
		int offset = 26;
		wstring result = _devicePath.substr(offset, _devicePath.length() - offset);
		offset = result.find('#', 0);
		return result.substr(0, offset);
	}

	wstring WinUsbConnection::name()
	{
		return _name;
	}

	wstring WinUsbConnection::devicePath()
	{
		return _devicePath;
	}

	bool WinUsbConnection::receivePinReportPacket(uint8_t* data)
	{
		ULONG transferred;
		WinUsb_ReadPipe(deviceData.WinusbHandle, pinReportEndpoint, data, 64, &transferred, 0);
		if (transferred > 0) return true;

		return false;
	}

	bool WinUsbConnection::receiveDataPeripheralChannel(uint8_t * data, size_t len)
	{
		ULONG transferred;
		WinUsb_ReadPipe(deviceData.WinusbHandle, peripheralResponseEndpoint, data, len, &transferred, 0);
		if (transferred > 0) return true;

		return false;
	}

	void WinUsbConnection::debugPrintLastError()
	{
		wchar_t buf[256];
		FormatMessageW(FORMAT_MESSAGE_FROM_SYSTEM, NULL, GetLastError(),
			MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT), buf, 256, NULL);
		OutputDebugString(buf);
		OutputDebugString(L"\n");
	}
}