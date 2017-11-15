using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FakeSimulator.TestWPF
{
    public class ActionCommand : ICommand
    {
        private Action action;

        public ActionCommand(Action action) {
            this.Action = action;
        }

        public Action Action { get => action; set {action = value; CanExecuteChanged?.Invoke(this, new EventArgs()); } }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return action != null;
        }

        public void Execute(object parameter)
        {
            if (CanExecute(parameter)) {
                action.Invoke();
            }
        }
    }
}
