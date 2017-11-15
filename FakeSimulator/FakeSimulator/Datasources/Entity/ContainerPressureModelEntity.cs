using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeSimulator.Datasources.Entity
{
    public class ContainerPressureModelEntity : BaseModelEntity
    {
        public double Width { get; protected set; }
        public double Height { get; protected set; }
        public bool HasExhaust { get; protected set; }

        public ContainerPressureModelEntity(string title, string description, double width, double height, bool hasExhaust, long id = 0)
            : base(id, title, description)
        {
            this.Width = width;
            this.Height = height;
            this.HasExhaust = hasExhaust;
        }

        public override string GetData()
        {
            return String.Format("[ Width={0}, Height={1}, HasExhaust={2}, Material={3} ]", Width, Height, HasExhaust, base.MaterialEntity.Name);
        }

        public override ModelTypeEnum GetModelType()
        {
            return ModelTypeEnum.ContainerPressureModel;
        }
    }
}
