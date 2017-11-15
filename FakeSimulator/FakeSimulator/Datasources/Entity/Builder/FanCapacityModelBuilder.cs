using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeSimulator.Datasources.Entity.Builder
{
    public class FanCapacityModelBuilder : ModelBuilder
    {
        public FanCapacityModelBuilder(string title, string description, Entity.UserEntity user, Entity.MaterialEntity material, double radius, double length, bool complexDesign, long id = 0)
            : base(id, title, description, user, material)
        {
            Model = new FanCapacityModelEntity(title, description, radius, length, complexDesign, id);
        }
    }
}
