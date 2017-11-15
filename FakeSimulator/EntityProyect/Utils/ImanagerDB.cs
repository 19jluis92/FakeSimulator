using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityProyect.Utils
{
    interface ImanagerDB <T>
    {
        void create(T t);

        void update(T t);

        void delete(T t);

        void all(List<T> t);

        void dispose();
    }
}
