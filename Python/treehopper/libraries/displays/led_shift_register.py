from treehopper.libraries.displays import LedDriver
from treehopper.libraries.io.expander.shift_register import ChainableShiftRegisterOutput


class LedShiftRegister(ChainableShiftRegisterOutput, LedDriver):
    def __init__(self):
        super().__init__()
