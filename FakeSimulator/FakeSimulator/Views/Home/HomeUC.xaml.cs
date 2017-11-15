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

namespace FakeSimulator.Views.Home
{
    /// <summary>
    /// Interaction logic for HomeUC.xaml
    /// </summary>
    public partial class HomeUC : UserControl, IDisposable
    {
        Datasources.Manager Manager;
        ViewModel.View View;

        Utils.EventObserver UserUpdateEvent;
        Utils.EventObserver ModelUpdateEvent;

        Model.ModelView CurrentModelView;

        public HomeUC()
        {
            InitializeComponent();
            View = new ViewModel.View();
            Manager = Datasources.Manager.GetInstance();

            //TODO: do not update if control is not being shown
            UserUpdateEvent = new Utils.EventObserver((sender, args) =>
            {
                if (args != null)
                {
                    try
                    {
                        var o_args = (Datasources.UserAddedEventArgs)args;
                        ReloadCombo(o_args.User.Id);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error while retrieving back user in event", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    ReloadCombo();
                }
            });
            ModelUpdateEvent = new Utils.EventObserver((sender, args) =>
            {
                ReloadDataGrid();
            });

            Manager.GetDataSource().UserUpdateEvent.Subscribe(UserUpdateEvent);
            Manager.GetDataSource().ModelUpdateEvent.Subscribe(ModelUpdateEvent);
        }

        public void Init()
        {
            MainDataGrid.ItemsSource = View.Items;
            ComboBox_Users.ItemsSource = View.Users;

            ReloadCombo();
        }

        private void ReloadCombo(long selectId = 0)
        {
            View.Users.Clear();
            View.Users.Add(new ViewModel.UserItem() { Id = 0, User = null, Username = "All" });
            Manager.GetDataSource().GetAllUsers().ForEach(x => View.Users.Add(new ViewModel.UserItem()
            {
                Id = x.Id,
                User = x,
                Username = x.Username
            }));

            if (selectId == 0)
            {
                ComboBox_Users.SelectedIndex = 0;
            }
            else
            {
                var obj_find = View.Users.Where(x => x.Id == selectId).FirstOrDefault();
                if (obj_find != null)
                {
                    ComboBox_Users.SelectedIndex = ComboBox_Users.Items.IndexOf(obj_find);
                }
                else
                {
                    ComboBox_Users.SelectedIndex = 0;
                }
            }
            
            //ReloadDataGrid();
        }

        private void ReloadDataGrid()
        {
            View.Items.Clear();
            object selected = ComboBox_Users.SelectedItem;

            List<Datasources.Entity.BaseModelEntity> list = null;

            if (selected != null)
            {
                var o_selected = (ViewModel.UserItem)selected;
                if (o_selected.Id == 0)
                {
                    list = Manager.GetDataSource().GetAllModels();
                }
                else
                {
                    list = Manager.GetDataSource().GetAllModelsByUser(o_selected.User);
                }
            }
            else
            {
                list = Manager.GetDataSource().GetAllModels();
            }

            list.ForEach(x => View.Items.Add(new ViewModel.ModelDataItem()
            {
                Id = x.Id,
                Data = x.GetData(),
                Username = x.UserEntity.Username,
                Description = x.Description,
                Model = x,
                Title = x.Title,
                TypeName = x.GetModelType().ToString()
            }));
        }

        private void ComboBox_Users_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ReloadDataGrid();
        }

        private void ViewDetails_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ViewModel.ModelDataItem obj = ((FrameworkElement)sender).DataContext as ViewModel.ModelDataItem;
                //MessageBox.Show("Click id: " + obj.Id);

                if (CurrentModelView == null)
                {
                    CurrentModelView = new Model.ModelView(obj.Model);
                    CurrentModelView.GoBackEvent += GoBackContentEvent;

                    MainGrid.Visibility = System.Windows.Visibility.Hidden;
                    MainCC.Content = CurrentModelView;
                    MainCC.Visibility = System.Windows.Visibility.Visible;
                }
                else
                {
                    throw new ApplicationException("ModelView is not null");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception in `ViewDetails_Click`", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        public void Dispose()
        {
            UserUpdateEvent.Dispose();
            ModelUpdateEvent.Dispose();
        }

        public void GoBackContentEvent()
        {
            MainGrid.Visibility = System.Windows.Visibility.Visible;
            MainCC.Content = null;
            MainCC.Visibility = System.Windows.Visibility.Hidden;
            CurrentModelView.GoBackEvent -= GoBackContentEvent;
            CurrentModelView.Dispose();
            CurrentModelView = null;
        }
    }
}
