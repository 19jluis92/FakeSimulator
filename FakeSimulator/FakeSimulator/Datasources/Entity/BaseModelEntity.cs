using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeSimulator.Datasources.Entity
{
    public abstract class BaseModelEntity
    {
        public long Id { get; protected set; }
        public string Title { get; protected set; }
        public string Description { get; protected set; }

        public MaterialEntity MaterialEntity { get; protected set; }
        public UserEntity UserEntity { get; protected set; }

        public abstract string GetData();
        public abstract ModelTypeEnum GetModelType();

        public BaseModelEntity(long id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
        }

        public void SetUser(UserEntity user)
        {
            UserEntity = user;
        }

        public void SetMaterial(MaterialEntity material)
        {
            MaterialEntity = material;
        }

        public void SetId(long id)
        {
            Id = id;
        }
    }
}
