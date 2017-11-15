using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeSimulator.Datasources.Entity.Builder
{
    public abstract class ModelBuilder
    {
        protected Entity.BaseModelEntity Model;
        protected Entity.UserEntity User;
        protected Entity.MaterialEntity Material;

        public ModelBuilder(string title, string description, Entity.UserEntity user, Entity.MaterialEntity material)
        {
            User = user;
            Material = material;
        }

        public ModelBuilder(long id, string title, string description, Entity.UserEntity user, Entity.MaterialEntity material)
        {
            User = user;
            Material = material;
        }

        public virtual void SetMaterial()
        {
            Model.SetMaterial(Material);
        }

        public virtual void SetUser()
        {
            Model.SetUser(User);
        }

        public virtual BaseModelEntity GetModel()
        {
            return Model;
        }
        
    }
}
