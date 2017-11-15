using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeSimulator.Views.Home.ViewModel
{
    public class View
    {
        public ObservableCollection<ModelDataItem> Items { get; set; }
        public ObservableCollection<UserItem> Users { get; set; }
        public View()
        {
            Items = new ObservableCollection<ModelDataItem>();
            Users = new ObservableCollection<UserItem>();
        }

    }
}
