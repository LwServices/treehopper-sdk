/// This file was auto-generated by RegisterGenerator. Any changes to it will be overwritten!
package io.treehopper.libraries.io.adc.ads1115;

 enum Muxes
{
    ain0_ain1 (0),
    ain0_ain3 (1),
    ain1_ain3 (2),
    ain2_ain3 (3),
    ain0_gnd (4),
    ain1_gnd (5),
    ain2_gnd (6),
    ain3_gnd (7);

int val;

Muxes(int val) { this.val = val; }
public int getVal() { return val; }
}
