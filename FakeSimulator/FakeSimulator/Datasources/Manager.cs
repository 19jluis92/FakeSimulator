using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeSimulator.Datasources
{
    public class Manager : IDisposable
    {
        private static Manager Instance { get; set; }

        protected IDataSource DS { get; set; }

        private Manager(DataSourceType type)
        {
            if (type == DataSourceType.Memory)
            {
                DS = new Datasources.Memory.DataSource();
            }
           
        }

        public static Manager GetInstance()
        {
            if (Instance == null)
            {
                
               
                    string value = System.Configuration.ConfigurationManager.AppSettings["DataSource"];
                    DataSourceType type = DataSourceType.Memory;
                    if (!Enum.TryParse(value, out type))
                    {
                        type = DataSourceType.Memory;
                    }
                    Instance = new Manager(type);
                       
              
            }
            return Instance;
        }

        public IDataSource GetDataSource()
        {
            return DS;
        }

        public Entity.Factory.UserFactory GetUserFactory()
        {
            return new Entity.Factory.UserFactory();
        }

        public void Dispose()
        {
            DS.Dispose();
        }
    }
}
