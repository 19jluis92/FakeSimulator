using System;
using System.Windows.Input;

namespace FakeSimulator.Views.Home.ViewModel
{
    internal class ActionCommand : ICommand
    {
        private Action startLoop;

        public ActionCommand(Action startLoop)
        {
            this.startLoop = startLoop;
        }

        public Action Action { get => startLoop; set { startLoop = value; CanExecuteChanged?.Invoke(this, new EventArgs()); } }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return startLoop != null;
        }

        public void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                startLoop.Invoke();
            }
        }
    }
}