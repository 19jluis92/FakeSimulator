using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeSimulator.Datasources.Entity
{
    public class FanCapacityModelEntity : BaseModelEntity
    {
        public double Radius { get; protected set; }
        public double BladeLength { get; protected set; }
        public bool ComplexDesign { get; protected set; }

        public FanCapacityModelEntity(string title, string description, double radius, double length, bool complexDesign, long id = 0)
            : base(id, title, description)
        {
            this.Radius = radius;
            this.BladeLength = length;
            this.ComplexDesign = complexDesign;
        }

        public override string GetData()
        {
            return String.Format("[ Radius={0}, BladeLength={1}, ComplexDesign={2}, Material={3} ]", Radius, BladeLength, ComplexDesign, base.MaterialEntity.Name);
        }

        public override ModelTypeEnum GetModelType()
        {
            return ModelTypeEnum.FanCapacityModel;
        }
    }
}
