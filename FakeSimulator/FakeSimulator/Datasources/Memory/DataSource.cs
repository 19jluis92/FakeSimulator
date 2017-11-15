using EntityProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeSimulator.Datasources.Memory
{
    public class DataSource : IDataSource
    {
        List<Entity.UserEntity> Users;
        List<Entity.BaseModelEntity> Models;
        List<Entity.MaterialEntity> Materials;
        private string v;
        //private EntityProject.Utils.Repository  context;
       private EntityProject.Utils.Factory.ContextFactory context = new EntityProject.Utils.Factory.ContextFactory();

        public DataSource() : base()
        {
           

            var userfactory = new Entity.Factory.UserFactory();


           var contextUser =( (EntityProject.Utils.Repository<User>) context.GetRepository(typeof(User)));
            contextUser.Insert(EntityProject.Utils.UserFactoryDB.create("nuevo1"));
            contextUser.Insert(EntityProject.Utils.UserFactoryDB.create("nuevo3"));
            contextUser.Insert(EntityProject.Utils.UserFactoryDB.create("nuevo2"));

            

            if (!Boolean.Parse(System.Configuration.ConfigurationManager.AppSettings["test"]))
                contextUser.SubmitChanges();

            var contextMaterial = ((EntityProject.Utils.Repository<Material>)context.GetRepository(typeof(Material)));
            contextMaterial.Insert(new EntityProject.Material()
            {
                Id = 1,
                Name = "Iron",
                Resistence = 2
            });
            contextMaterial.Insert(new EntityProject.Material()
            {
                Id = 2,
                Name = "Copper",
                Resistence = new Decimal(1.5d)
            });
            contextMaterial.Insert(new EntityProject.Material()
            {
                Id = 3,
                Name = "Titanium",
                Resistence = 2
            });

            if (!Boolean.Parse(System.Configuration.ConfigurationManager.AppSettings["test"]))
                contextMaterial.SubmitChanges();


            //Models = new List<Entity.BaseModelEntity>();

            //var director = new Entity.Builder.ModelDirector();
            //var builder1 = new Entity.Builder.ContainerPressureModelBuilder("Iron Cont. XF3", "FR Client", GetUserById(1), GetMaterialByName("Iron"), 30, 30, true, 1);
            //var builder12 = new Entity.Builder.FanCapacityModelBuilder("Iron Fan XF3", "FR Client", GetUserById(1), GetMaterialByName("Iron"), 5, 15, true, 2);
            //var builder2 = new Entity.Builder.ContainerPressureModelBuilder("Copper Cont. XF4", "RBEI Client", GetUserById(2), GetMaterialByName("Copper"), 10, 40, false, 3);
            //var builder22 = new Entity.Builder.FanCapacityModelBuilder("Copper Fan XF4", "RBEI Client", GetUserById(2), GetMaterialByName("Copper"), 10, 20, false, 4);
            //var builder3 = new Entity.Builder.ContainerPressureModelBuilder("Titanium Model XF5", "US Client", GetUserById(3), GetMaterialByName("Titanium"), 20, 10, false, 5);
            var contextModel = ((EntityProject.Utils.Repository<Model>)context.GetRepository(typeof(Model)));
            contextModel.Insert(new EntityProject.Model()
            {
                Title = "Iron Cont. XF3",
                Description = "FR Client",
                IdUsuario = 1,
                IdMaterial = 1,
                ContainerPressure = new List<ContainerPressure>() { EntityProject.Utils.ContainerPressureFactory.create(true, new Decimal(30.0d), new Decimal(30.0d)) },
                // FanCapacity = 
            });
            contextModel.Insert(new EntityProject.Model()
            {
                Title = "Iron Cont. XF3",
                Description = "FR Client",
                IdUsuario = 1,
                IdMaterial = 1,
                //ContainerPressure = new List<ContainerPressure>() { EntityProject.Utils.ContainerPressureFactory.create(true, new Decimal(30.0d), new Decimal(30.0d)) },
                FanCapacity = new List<FanCapacity>() { EntityProject.Utils.FanCapacityFactory.create(new Decimal(5.0d), new Decimal(15.0d), true) },
            });

            contextModel.Insert(new EntityProject.Model()
            {
                Title = "Copper Cont. XF4",
                Description = "RBEI Client",
                IdUsuario = 2,
                IdMaterial = 2,
                ContainerPressure = new List<ContainerPressure>() { EntityProject.Utils.ContainerPressureFactory.create(false, new Decimal(10.0d), new Decimal(40.0d)) },
                // FanCapacity = 
            });
            contextModel.Insert(new EntityProject.Model()
            {
                Title = "Copper Cont. XF4",
                Description = "RBEI Client",
                IdUsuario = 2,
                IdMaterial = 2,
                //ContainerPressure = new List<ContainerPressure>() { EntityProject.Utils.ContainerPressureFactory.create(true, new Decimal(30.0d), new Decimal(30.0d)) },
                FanCapacity = new List<FanCapacity>() { EntityProject.Utils.FanCapacityFactory.create(new Decimal(10.0d), new Decimal(20.0d), false) },
            });
            contextModel.Insert(new EntityProject.Model()
            {
                Title = "Titanium Model XF5",
                Description = "US Client",
                IdUsuario = 3,
                IdMaterial = 3,
                ContainerPressure = new List<ContainerPressure>() { EntityProject.Utils.ContainerPressureFactory.create(false, new Decimal(20.0d), new Decimal(10.0d)) },
                // FanCapacity = 
            });
            //Models.Add(director.ConstructModel(builder1));
            //Models.Add(director.ConstructModel(builder12));
            //Models.Add(director.ConstructModel(builder2));
            //Models.Add(director.ConstructModel(builder22));
            //Models.Add(director.ConstructModel(builder3));
            //director.ConstructModel();
            if (!Boolean.Parse(System.Configuration.ConfigurationManager.AppSettings["test"]))
                contextModel.SubmitChanges();
        }


        public override List<Entity.UserEntity> GetAllUsers()
        {
            var contextUser =   ((EntityProject.Utils.Repository<User>)context.GetRepository(typeof(User)));
            return contextUser.GetAll().ToList().Select(x => new Entity.UserEntity((x as User).Id,(x as User).Username)).ToList();
        }

        public override Entity.UserEntity GetUserById(long id)
        {
            var contextUser =   ((EntityProject.Utils.Repository<User>)context.GetRepository(typeof(User)));
            var temp =  contextUser.Get(id);
            return new Entity.UserEntity((temp as User).Id, (temp as User).Username);
        }

        public override Entity.BaseModelEntity GetModelById(long id)
        {
            var contextModel = ((EntityProject.Utils.Repository<Model>)context.GetRepository(typeof(Model)));
            var temp= contextModel.Get(id);
            return null;//? TODO no se que regresarte aqui
        }

        public override List<Entity.BaseModelEntity> GetAllModels()
        {
            return Models;//? TODO no se que regresarte aqui
        }

        public override List<Entity.BaseModelEntity> GetAllModelsByUser(Entity.UserEntity user)
        {
            return Models.Where(x => x.UserEntity.Id == user.Id).ToList();//? TODO no se que regresarte aqui
        }

        public override long _AddUser(Entity.UserEntity user)
        {
            var contextUser = ((EntityProject.Utils.Repository<User>)context.GetRepository(typeof(User)));
            contextUser.Insert(EntityProject.Utils.UserFactoryDB.create(user.Username));
            //Users[Users.Count - 1].SetId(Users.Count);
            contextUser.SubmitChanges();
            return contextUser.GetAll().Count();
        }

        public override long _AddModel(Entity.BaseModelEntity model)
        {
            Models.Add(model);
            Models[Models.Count - 1].SetId(Models.Count);
            return Models.Count;
        }

        public override List<Entity.MaterialEntity> GetAllMaterials()
        {
            var contextMaterial = ((EntityProject.Utils.Repository<Material>)context.GetRepository(typeof(Material)));
          
            return contextMaterial.GetAll().ToList().Select(x => new Entity.MaterialEntity()
            {
                Id = (x as Material).Id,
                Name = (x as Material).Name,
                Resistance = double.Parse((x as Material).Resistence.ToString())
            }).ToList();
        }

        public override Entity.MaterialEntity GetMaterialByName(string name)
        {
            var contextMaterial = ((EntityProject.Utils.Repository<Material>)context.GetRepository(typeof(Material)));

            return contextMaterial.GetAll().Where(y => y.Name.Equals(name)).ToList().Select(x => new Entity.MaterialEntity()
            {
                Id = (x as Material).Id,
                Name = (x as Material).Name,
                Resistance = double.Parse((x as Material).Resistence.ToString())
            }).FirstOrDefault();
        }
    }
}
