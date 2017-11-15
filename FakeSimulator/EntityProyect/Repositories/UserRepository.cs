using EntityProject.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityProject.Repositories
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(EntitiesContext context) : base(context)
        {
        }
    }
}
