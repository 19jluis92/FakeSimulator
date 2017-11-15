using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeSimulator.Views.Home.ViewModel
{
    public class ModelDataItem
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TypeName { get; set; }
        public string Username { get; set; }
        
        public string Data { get; set; }

        public Datasources.Entity.BaseModelEntity Model { get; set; }
    }
}
