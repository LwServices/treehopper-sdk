﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Treehopper.Libraries.Sensors.Humidity
{
    interface IHumiditySensor : IPollable
    {
        double RelativeHumidity { get; }
    }
}