using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeSimulator.Datasources
{
    /// <summary>
    /// TODO: change name (it is not an interface)
    /// </summary>
    public abstract class IDataSource : IDisposable
    {
        public Utils.ObservableEvent UserUpdateEvent { get; protected set; }
        public Utils.ObservableEvent ModelUpdateEvent { get; protected set; }

        public IDataSource()
        {
            UserUpdateEvent = new Utils.ObservableEvent();
            ModelUpdateEvent = new Utils.ObservableEvent();
        }

        public abstract List<Entity.UserEntity> GetAllUsers();
        public abstract Entity.UserEntity GetUserById(long id);
        public abstract Entity.BaseModelEntity GetModelById(long id);
        public abstract List<Entity.BaseModelEntity> GetAllModels();
        public abstract List<Entity.BaseModelEntity> GetAllModelsByUser(Entity.UserEntity user);

        public abstract List<Entity.MaterialEntity> GetAllMaterials();
        public abstract Entity.MaterialEntity GetMaterialByName(string name);

        public void AddUser(Entity.UserEntity user)
        {
            long id = _AddUser(user);
            UserUpdateEvent.Notify(this, new UserAddedEventArgs() { User = GetUserById(id) });
        }
        public abstract long _AddUser(Entity.UserEntity user);

        public void AddModel(Entity.BaseModelEntity model)
        {
            long id = _AddModel(model);
            ModelUpdateEvent.Notify(this, new ModelAddedEventArgs() { Model = GetModelById(id) });
        }
        public abstract long _AddModel(Entity.BaseModelEntity model);

        public void Dispose()
        {
            UserUpdateEvent.Dispose();
            ModelUpdateEvent.Dispose();
        }
    }
}
