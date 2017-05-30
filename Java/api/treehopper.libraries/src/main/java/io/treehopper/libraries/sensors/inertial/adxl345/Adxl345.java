package io.treehopper.libraries.sensors.inertial.adxl345;

import com.badlogic.gdx.math.Vector3;
import io.treehopper.SMBusDevice;
import io.treehopper.interfaces.I2c;
import io.treehopper.libraries.sensors.inertial.adxl345.Adxl345Registers;
import io.treehopper.libraries.sensors.inertial.IAccelerometer;

/**
 * Created by JayLocal on 4/29/2017.
 */
public class Adxl345 implements IAccelerometer {
    private SMBusDevice _dev;
    private Adxl345Registers registers;

    public Adxl345(I2c i2c, boolean altAddress, int rate)
    {
        _dev = new SMBusDevice((byte)(!altAddress ? 0x53 : 0x1D), i2c, rate);
        registers = new Adxl345Registers(_dev);
        registers.PowerCtl.Sleep = 0;
        registers.PowerCtl.Measure = 1;
        registers.DataFormat.Range = 0x03;
        registers.PowerCtl.write();
        registers.DataFormat.write();
    }

    @Override
    public Vector3 getAccelerometer() {
        registers.readRange(registers.DataX, registers.DataZ);

        Vector3 _accelerometer = new Vector3();
        _accelerometer.x = registers.DataX.Value * 0.04f;
        _accelerometer.y = registers.DataY.Value * 0.04f;
        _accelerometer.z = registers.DataZ.Value * 0.04f;

        return _accelerometer;
    }
}