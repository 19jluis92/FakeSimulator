using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeSimulator.Datasources.Entity
{
    public class MaterialEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public double Resistance { get; set; }
    }
}
