using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeSimulator.Datasources.Entity.Builder
{
    public class ContainerPressureModelBuilder : ModelBuilder
    {
        
        public ContainerPressureModelBuilder(string title, string description, Entity.UserEntity user, Entity.MaterialEntity material, double width, double height, bool hasExhaust, long id = 0)
            : base(id, title, description, user, material)
        {
            Model = new ContainerPressureModelEntity(title, description, width, height, hasExhaust, id);
        }

    }
}
