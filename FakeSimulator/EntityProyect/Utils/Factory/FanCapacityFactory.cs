using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityProject.Utils
{
    public class FanCapacityFactory
    {
        public static FanCapacity create(decimal radius, decimal length, bool complexDesign)
        {
            return new FanCapacity()
            {
                Radius = radius,
                BladeLength = length,
                ComplexDesign = complexDesign,
        };
        }
    }
}
