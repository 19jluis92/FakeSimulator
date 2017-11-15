using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeSimulator.Engine.Models
{
    public abstract class Model
    {
        public ModelTypes Type { get; protected set; }

        public Model(ModelTypes type)
        {
            Type = type;
        }
    }
}
