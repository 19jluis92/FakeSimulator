using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeSimulator.Datasources.Entity.Builder
{
    public class ModelDirector
    {
        public Entity.BaseModelEntity ConstructModel(ModelBuilder builder)
        {
            builder.SetMaterial();
            builder.SetUser();
            
            return builder.GetModel();
        }
    }
}
