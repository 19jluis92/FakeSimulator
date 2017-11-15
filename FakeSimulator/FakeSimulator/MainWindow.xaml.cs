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

namespace FakeSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Views.Help.HelpUC Help = new Views.Help.HelpUC();
        Views.Home.HomeUC Home = new Views.Home.HomeUC();

        public MainWindow()
        {
            InitializeComponent();

            Home.Init();

            Help.GoBackEvent += Help_GoBackEvent;
            this.MainCC.Content = Home;
        }

        private void Help_GoBackEvent()
        {
            this.MainCC.Content = Home;
        }
        
        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Made by Jonathan Villalobos - hallonavi -at- gmail -dot- com", "About Fake Simulator 3000", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ViewHelp_Click(object sender, RoutedEventArgs e)
        {
            this.MainCC.Content = Help;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Home.Dispose();
        }

        private void Test_AddUser_Click(object sender, RoutedEventArgs e)
        {
            Datasources.Manager.GetInstance().GetDataSource().AddUser(Datasources.Manager.GetInstance().GetUserFactory().Create("Test user"));
        }

        private void Test_AddModel_Click(object sender, RoutedEventArgs e)
        {
            bool success = false;
            var model = Datasources.Manager.GetInstance().GetDataSource().GetAllModels().FirstOrDefault();
            if (model != null)
            {
                var user = Datasources.Manager.GetInstance().GetDataSource().GetAllUsers().LastOrDefault();
                if (user != null)
                {
                    var material = Datasources.Manager.GetInstance().GetDataSource().GetAllMaterials().FirstOrDefault();
                    if (material != null)
                    {
                        var director = new Datasources.Entity.Builder.ModelDirector();
                        var builder = new Datasources.Entity.Builder.ContainerPressureModelBuilder("Test Model", "Test Client", user, material, 45, 35, false);

                        Datasources.Manager.GetInstance().GetDataSource().AddModel(director.ConstructModel(builder));

                        success = true;
                    }
                }
            }

            if (!success)
            {
                MessageBox.Show("There are no models to copy from", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        
    }
}
