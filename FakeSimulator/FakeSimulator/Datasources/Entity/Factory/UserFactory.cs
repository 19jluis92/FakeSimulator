using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeSimulator.Datasources.Entity.Factory
{
    public class UserFactory
    {
        public Entity.UserEntity Create(string username)
        {
            return new UserEntity(username);
        }

        public Entity.UserEntity Create(long id, string username)
        {
            return new UserEntity(id, username);
        }
    }
}
