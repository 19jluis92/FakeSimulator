using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FakeSimulator.Views.Home.ViewModel
{
    public class ViewSimulationModel :INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string member = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(member));
        }
    }
}