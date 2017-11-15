using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace FakeSimulator.TestWPF
{
    public class MainViewModel : ViewModel
    {
        DispatcherTimer timer = new DispatcherTimer();
        public MainViewModel()
        {
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
        }


        private int angle;

        public int Angle
        {
            get { return angle; }
            set { angle = value; OnPropertyChanged(); }
        }


        public ICommand Rotate { get { return new ActionCommand(RotateAngle); } }

        public ICommand Start { get { return new ActionCommand(StartLoop); } }

        private void StartLoop()
        {
            timer.Start();

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            RotateAngle();
        }

        public void RotateAngle()
        {
            Angle += 10;
        }

    }
}
