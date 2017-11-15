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
        private EntityProject.Entities  context;
     

        public DataSource() : base()
        {
            context = new EntityProject.Entities();

            var userfactory = new Entity.Factory.UserFactory();

            context.User.Add(EntityProject.Utils.UserFactoryDB.create("User1"));
            context.User.Add(EntityProject.Utils.UserFactoryDB.create("User3"));
            context.User.Add(EntityProject.Utils.UserFactoryDB.create("User3"));

            if (!Boolean.Parse(System.Configuration.ConfigurationManager.AppSettings["test"]))
                context.SaveChanges();


            context.Material.Add(new EntityProject.Material() {
                Id = 1,
                Name = "Iron",
                Resistence = 2 
            });
            context.Material.Add(new EntityProject.Material()
            {
                Id = 2,
                Name = "Copper",
                Resistence = new Decimal(1.5d)
            });
            context.Material.Add(new EntityProject.Material()
            {
                Id = 3,
                Name = "Titanium",
                Resistence = 2
            });

            if (!Boolean.Parse(System.Configuration.ConfigurationManager.AppSettings["test"]))
                context.SaveChanges();


            Models = new List<Entity.BaseModelEntity>();

            var director = new Entity.Builder.ModelDirector();
            //var builder1 = new Entity.Builder.ContainerPressureModelBuilder("Iron Cont. XF3", "FR Client", GetUserById(1), GetMaterialByName("Iron"), 30, 30, true, 1);
            //var builder12 = new Entity.Builder.FanCapacityModelBuilder("Iron Fan XF3", "FR Client", GetUserById(1), GetMaterialByName("Iron"), 5, 15, true, 2);
            //var builder2 = new Entity.Builder.ContainerPressureModelBuilder("Copper Cont. XF4", "RBEI Client", GetUserById(2), GetMaterialByName("Copper"), 10, 40, false, 3);
            //var builder22 = new Entity.Builder.FanCapacityModelBuilder("Copper Fan XF4", "RBEI Client", GetUserById(2), GetMaterialByName("Copper"), 10, 20, false, 4);
            //var builder3 = new Entity.Builder.ContainerPressureModelBuilder("Titanium Model XF5", "US Client", GetUserById(3), GetMaterialByName("Titanium"), 20, 10, false, 5);

            context.Model.Add(new EntityProject.Model() {
                Title = "Iron Cont. XF3",
                Description = "FR Client",
                IdUsuario = 1,
                IdMaterial = 1,
                ContainerPressure =new List<ContainerPressure>() { EntityProject.Utils.ContainerPressureFactory.create(true, new Decimal(30.0d), new Decimal(30.0d)) },
                // FanCapacity = 
            });
            context.Model.Add(new EntityProject.Model()
            {
                Title = "Iron Cont. XF3",
                Description = "FR Client",
                IdUsuario = 1,
                IdMaterial = 1,
                //ContainerPressure = new List<ContainerPressure>() { EntityProject.Utils.ContainerPressureFactory.create(true, new Decimal(30.0d), new Decimal(30.0d)) },
                 FanCapacity = new List<FanCapacity>() { EntityProject.Utils.FanCapacityFactory.create( new Decimal(5.0d), new Decimal(15.0d),true) },
            });

            context.Model.Add(new EntityProject.Model()
            {
                Title = "Copper Cont. XF4",
                Description = "RBEI Client",
                IdUsuario = 2,
                IdMaterial = 2,
                ContainerPressure = new List<ContainerPressure>() { EntityProject.Utils.ContainerPressureFactory.create(false, new Decimal(10.0d), new Decimal(40.0d)) },
                // FanCapacity = 
            });
            context.Model.Add(new EntityProject.Model()
            {
                Title = "Copper Cont. XF4",
                Description = "RBEI Client",
                IdUsuario = 2,
                IdMaterial = 2,
                //ContainerPressure = new List<ContainerPressure>() { EntityProject.Utils.ContainerPressureFactory.create(true, new Decimal(30.0d), new Decimal(30.0d)) },
                FanCapacity = new List<FanCapacity>() { EntityProject.Utils.FanCapacityFactory.create(new Decimal(10.0d), new Decimal(20.0d), false) },
            });
            context.Model.Add(new EntityProject.Model()
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
                context.SaveChanges();
        }

        
        public override List<Entity.UserEntity> GetAllUsers()
        {
    
            return context.User.Select(x => new Entity.UserEntity(x.Id,x.Username)).ToList();
        }

        public override Entity.UserEntity GetUserById(long id)
        {
            return context.User.Where(x=>x.Id == id).Select(x => new Entity.UserEntity(x.Id, x.Username)).FirstOrDefault();
        }

        public override Entity.BaseModelEntity GetModelById(long id)
        {
            return Models.Where(x => x.Id == id).FirstOrDefault();
        }

        public override List<Entity.BaseModelEntity> GetAllModels()
        {
            return Models;
        }

        public override List<Entity.BaseModelEntity> GetAllModelsByUser(Entity.UserEntity user)
        {
            return Models.Where(x => x.UserEntity.Id == user.Id).ToList();
        }

        public override long _AddUser(Entity.UserEntity user)
        {
           
            context.User.Add(EntityProject.Utils.UserFactoryDB.create(user.Username));
            //Users[Users.Count - 1].SetId(Users.Count);
            context.SaveChanges();
            return context.User.Count();
        }

        public override long _AddModel(Entity.BaseModelEntity model)
        {
            Models.Add(model);
            Models[Models.Count - 1].SetId(Models.Count);
            return Models.Count;
        }

        public override List<Entity.MaterialEntity> GetAllMaterials()
        {
            return Materials;
        }

        public override Entity.MaterialEntity GetMaterialByName(string name)
        {
            return Materials.Where(x => x.Name == name).FirstOrDefault();
        }
    }
}
