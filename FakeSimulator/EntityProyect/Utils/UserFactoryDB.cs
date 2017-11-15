using EntityProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityProject.Utils
{
   public  class UserFactoryDB 
    {

        public static User create(string username)
        {
            return new User() { Username= username};
        }

        public static User create(long id, string username)
        {
            return new User() { Id = id , Username = username };
        }

        
    }
}
