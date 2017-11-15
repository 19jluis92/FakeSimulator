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

namespace FakeSimulator.Views.Model
{
    /// <summary>
    /// Interaction logic for ModelView.xaml
    /// </summary>
    public partial class ModelView : UserControl, IDisposable
    {
        public event Action GoBackEvent;
        UserControl CurrentControl;

        public ModelView(Datasources.Entity.BaseModelEntity model)
        {
            InitializeComponent();

            switch (model.GetModelType())
            {
                case Datasources.Entity.ModelTypeEnum.ContainerPressureModel:
                    CurrentControl = new PressureContainer.PressureContainerView(model as Datasources.Entity.ContainerPressureModelEntity);
                    ModelDetailView.Content = CurrentControl;
                    break;
                case Datasources.Entity.ModelTypeEnum.FanCapacityModel:
                    CurrentControl = new FanCapacity.FanCapacityView(model as Datasources.Entity.FanCapacityModelEntity);
                    ModelDetailView.Content = CurrentControl;
                    break;
                default:
                    MessageBox.Show("Unkown model type: " + model.GetModelType().ToString());
                    break;
            }
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

        public void Dispose()
        {
            ModelDetailView.Content = null;
        }
    }
}
