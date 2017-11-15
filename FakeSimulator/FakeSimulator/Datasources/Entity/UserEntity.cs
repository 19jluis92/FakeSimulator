using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeSimulator.Datasources.Entity
{
    public class UserEntity 
    {
        public  long Id { get; protected set; }
        public  string Username { get; protected set; }

        public UserEntity(long id, string username)
        {
            Id = id;
            Username = username;
        }

        public UserEntity(string username)
        {
            Username = username;
        }

        public void SetId(long id)
        {
            Id = id;
        }


    }
}
