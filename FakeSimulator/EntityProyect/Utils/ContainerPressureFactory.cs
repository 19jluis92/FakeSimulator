using System;
using EntityProject;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityProject.Utils
{
   public class ContainerPressureFactory
    {
        public static ContainerPressure create(bool hasExhaust,decimal height, decimal width)
        {
            return new ContainerPressure() {
                HasExhaust = hasExhaust,
                Height= height,
                Width= width,
                
            };
        }

      
    }
}
