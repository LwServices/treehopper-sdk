/// This file was auto-generated by RegisterGenerator. Any changes to it will be overwritten!
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Treehopper;
using Treehopper.Libraries.Utilities;

namespace Treehopper.Libraries.Sensors.Magnetic
{
    public partial class Ak8975
    {
        protected class Ak8975Registers : RegisterManager
        {
            internal Ak8975Registers(SMBusDevice dev = null) : base(dev, true)
            {
                Wia = new WiaRegister(this);
                _registers.Add(Wia);
                Info = new InfoRegister(this);
                _registers.Add(Info);
                Status1 = new Status1Register(this);
                _registers.Add(Status1);
                Hx = new HxRegister(this);
                _registers.Add(Hx);
                Hy = new HyRegister(this);
                _registers.Add(Hy);
                Hz = new HzRegister(this);
                _registers.Add(Hz);
                Status2 = new Status2Register(this);
                _registers.Add(Status2);
                Control = new ControlRegister(this);
                _registers.Add(Control);
                SensitivityX = new SensitivityXRegister(this);
                _registers.Add(SensitivityX);
                SensitivityY = new SensitivityYRegister(this);
                _registers.Add(SensitivityY);
                SensitivityZ = new SensitivityZRegister(this);
                _registers.Add(SensitivityZ);
            }

            internal WiaRegister Wia;
            internal InfoRegister Info;
            internal Status1Register Status1;
            internal HxRegister Hx;
            internal HyRegister Hy;
            internal HzRegister Hz;
            internal Status2Register Status2;
            internal ControlRegister Control;
            internal SensitivityXRegister SensitivityX;
            internal SensitivityYRegister SensitivityY;
            internal SensitivityZRegister SensitivityZ;

            internal class WiaRegister : Register
            {
                internal WiaRegister(RegisterManager regManager) : base(regManager, 0x00, 1, false) { }

                public int Value { get; set; }

                public async Task<WiaRegister> Read()
                {
                    await manager.Read(this).ConfigureAwait(false);
                    return this;
                }
                internal override long GetValue() { return ((Value & 0xFF) << 0); }
                internal override void SetValue(long value)
                {
                    Value = (int)((value >> 0) & 0xFF);
                }

                public override string ToString()
                {
                    string retVal = "";
                    retVal += $"Value: { Value } (offset: 0, width: 8)\r\n";
                    return retVal;
                }
            }
            internal class InfoRegister : Register
            {
                internal InfoRegister(RegisterManager regManager) : base(regManager, 0x01, 1, false) { }

                public int Value { get; set; }

                public async Task<InfoRegister> Read()
                {
                    await manager.Read(this).ConfigureAwait(false);
                    return this;
                }
                internal override long GetValue() { return ((Value & 0xFF) << 0); }
                internal override void SetValue(long value)
                {
                    Value = (int)((value >> 0) & 0xFF);
                }

                public override string ToString()
                {
                    string retVal = "";
                    retVal += $"Value: { Value } (offset: 0, width: 8)\r\n";
                    return retVal;
                }
            }
            internal class Status1Register : Register
            {
                internal Status1Register(RegisterManager regManager) : base(regManager, 0x02, 1, false) { }

                public int Drdy { get; set; }

                public async Task<Status1Register> Read()
                {
                    await manager.Read(this).ConfigureAwait(false);
                    return this;
                }
                internal override long GetValue() { return ((Drdy & 0x1) << 0); }
                internal override void SetValue(long value)
                {
                    Drdy = (int)((value >> 0) & 0x1);
                }

                public override string ToString()
                {
                    string retVal = "";
                    retVal += $"Drdy: { Drdy } (offset: 0, width: 1)\r\n";
                    return retVal;
                }
            }
            internal class HxRegister : Register
            {
                internal HxRegister(RegisterManager regManager) : base(regManager, 0x03, 2, false) { }

                public int Value { get; set; }

                public async Task<HxRegister> Read()
                {
                    await manager.Read(this).ConfigureAwait(false);
                    return this;
                }
                internal override long GetValue() { return ((Value & 0xFFFF) << 0); }
                internal override void SetValue(long value)
                {
                    Value = (int)(((value >> 0) & 0xFFFF) << (32 - 16)) >> (32 - 16);
                }

                public override string ToString()
                {
                    string retVal = "";
                    retVal += $"Value: { Value } (offset: 0, width: 16)\r\n";
                    return retVal;
                }
            }
            internal class HyRegister : Register
            {
                internal HyRegister(RegisterManager regManager) : base(regManager, 0x05, 2, false) { }

                public int Value { get; set; }

                public async Task<HyRegister> Read()
                {
                    await manager.Read(this).ConfigureAwait(false);
                    return this;
                }
                internal override long GetValue() { return ((Value & 0xFFFF) << 0); }
                internal override void SetValue(long value)
                {
                    Value = (int)(((value >> 0) & 0xFFFF) << (32 - 16)) >> (32 - 16);
                }

                public override string ToString()
                {
                    string retVal = "";
                    retVal += $"Value: { Value } (offset: 0, width: 16)\r\n";
                    return retVal;
                }
            }
            internal class HzRegister : Register
            {
                internal HzRegister(RegisterManager regManager) : base(regManager, 0x07, 2, false) { }

                public int Value { get; set; }

                public async Task<HzRegister> Read()
                {
                    await manager.Read(this).ConfigureAwait(false);
                    return this;
                }
                internal override long GetValue() { return ((Value & 0xFFFF) << 0); }
                internal override void SetValue(long value)
                {
                    Value = (int)(((value >> 0) & 0xFFFF) << (32 - 16)) >> (32 - 16);
                }

                public override string ToString()
                {
                    string retVal = "";
                    retVal += $"Value: { Value } (offset: 0, width: 16)\r\n";
                    return retVal;
                }
            }
            internal class Status2Register : Register
            {
                internal Status2Register(RegisterManager regManager) : base(regManager, 0x09, 1, false) { }

                public int Derr { get; set; }
                public int Hofl { get; set; }

                public async Task<Status2Register> Read()
                {
                    await manager.Read(this).ConfigureAwait(false);
                    return this;
                }
                internal override long GetValue() { return ((Derr & 0x1) << 2) | ((Hofl & 0x1) << 3); }
                internal override void SetValue(long value)
                {
                    Derr = (int)((value >> 2) & 0x1);
                    Hofl = (int)((value >> 3) & 0x1);
                }

                public override string ToString()
                {
                    string retVal = "";
                    retVal += $"Derr: { Derr } (offset: 2, width: 1)\r\n";
                    retVal += $"Hofl: { Hofl } (offset: 3, width: 1)\r\n";
                    return retVal;
                }
            }
            internal class ControlRegister : Register
            {
                internal ControlRegister(RegisterManager regManager) : base(regManager, 0x0a, 1, false) { }

                public int Mode { get; set; }

                public async Task<ControlRegister> Read()
                {
                    await manager.Read(this).ConfigureAwait(false);
                    return this;
                }
                internal override long GetValue() { return ((Mode & 0xF) << 0); }
                internal override void SetValue(long value)
                {
                    Mode = (int)((value >> 0) & 0xF);
                }

                public override string ToString()
                {
                    string retVal = "";
                    retVal += $"Mode: { Mode } (offset: 0, width: 4)\r\n";
                    return retVal;
                }
            }
            internal class SensitivityXRegister : Register
            {
                internal SensitivityXRegister(RegisterManager regManager) : base(regManager, 0x10, 1, false) { }

                public int Value { get; set; }

                public async Task<SensitivityXRegister> Read()
                {
                    await manager.Read(this).ConfigureAwait(false);
                    return this;
                }
                internal override long GetValue() { return ((Value & 0xFF) << 0); }
                internal override void SetValue(long value)
                {
                    Value = (int)((value >> 0) & 0xFF);
                }

                public override string ToString()
                {
                    string retVal = "";
                    retVal += $"Value: { Value } (offset: 0, width: 8)\r\n";
                    return retVal;
                }
            }
            internal class SensitivityYRegister : Register
            {
                internal SensitivityYRegister(RegisterManager regManager) : base(regManager, 0x11, 1, false) { }

                public int Value { get; set; }

                public async Task<SensitivityYRegister> Read()
                {
                    await manager.Read(this).ConfigureAwait(false);
                    return this;
                }
                internal override long GetValue() { return ((Value & 0xFF) << 0); }
                internal override void SetValue(long value)
                {
                    Value = (int)((value >> 0) & 0xFF);
                }

                public override string ToString()
                {
                    string retVal = "";
                    retVal += $"Value: { Value } (offset: 0, width: 8)\r\n";
                    return retVal;
                }
            }
            internal class SensitivityZRegister : Register
            {
                internal SensitivityZRegister(RegisterManager regManager) : base(regManager, 0x12, 1, false) { }

                public int Value { get; set; }

                public async Task<SensitivityZRegister> Read()
                {
                    await manager.Read(this).ConfigureAwait(false);
                    return this;
                }
                internal override long GetValue() { return ((Value & 0xFF) << 0); }
                internal override void SetValue(long value)
                {
                    Value = (int)((value >> 0) & 0xFF);
                }

                public override string ToString()
                {
                    string retVal = "";
                    retVal += $"Value: { Value } (offset: 0, width: 8)\r\n";
                    return retVal;
                }
            }
        }
    }
}