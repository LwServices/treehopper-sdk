/// This file was auto-generated by RegisterGenerator. Any changes to it will be overwritten!
package io.treehopper.libraries.io.adc.nau7802;

public enum CalMods
{
    OffsetCalibrationInternal (0),
    Reserved (1),
    OffsetCalibrationSystem (2),
    GainCalibrationSystem (3);

int val;

CalMods(int val) { this.val = val; }
public int getVal() { return val; }
}
