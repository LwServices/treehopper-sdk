/// This file was auto-generated by RegisterGenerator. Any changes to it will be overwritten!
package io.treehopper.libraries.sensors.inertial.lsm303d;

 enum MagDataRates
{
    Hz_3_125 (0),
    Hz_6_25 (1),
    Hz_12_5 (2),
    Hz_25 (3),
    Hz_50 (4),
    Hz_100 (5);

int val;

MagDataRates(int val) { this.val = val; }
public int getVal() { return val; }
}
