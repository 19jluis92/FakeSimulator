using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeSimulator.Datasources
{
    public class ModelAddedEventArgs : Utils.ObsEventArgs
    {
        public Entity.BaseModelEntity Model { get; set; }
    }
}
