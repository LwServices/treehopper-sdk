#pragma once

#include "Libraries/Treehopper.Libraries.h"
#include "Libraries/Pollable.h"

using namespace Treehopper::Libraries;

namespace Treehopper {
    namespace Libraries {
        namespace Sensors {
            class LIBRARIES_API ProximitySensor : virtual public Pollable {
            public:
                double centimeters();

                double millimeters();

                double inches();

                double feet();

                double meters();

            protected:
                double _meters;
            };
        }
    }
}
