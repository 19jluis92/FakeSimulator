using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityProject.Utils.Factory
{
    public class ContextFactory
    {
        EntitiesContext context;
        public ContextFactory() {
            context = new EntitiesContext();
        }

        public object GetRepository(Type t)
        {
            Type repoType = typeof(Repository<>).MakeGenericType(t);
            var repository = Activator.CreateInstance(repoType);
            return repository ;
        }


    }
}
