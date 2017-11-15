using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FakeSimulator.Views.Help
{
    /// <summary>
    /// Interaction logic for HelpUC.xaml
    /// </summary>
    public partial class HelpUC : UserControl
    {
        public event Action GoBackEvent;

        public HelpUC()
        {
            InitializeComponent();
        }

        private void RaiseGoBackEvent()
        {
            var e = GoBackEvent;
            if (e != null)
            {
                GoBackEvent();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RaiseGoBackEvent();
        }
    }
}
