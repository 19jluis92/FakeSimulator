using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeSimulator.Datasources
{
    public class UserAddedEventArgs : Utils.ObsEventArgs
    {
        public Entity.UserEntity User { get; set; }
    }
}
