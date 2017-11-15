using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeSimulator.Utils
{
    public class EventObserver : IDisposable
    {
        bool IsDisposed = false;
        Action<object, ObsEventArgs> Action = null;

        ObservableEvent ObsEvent;

        public EventObserver(Action<object, ObsEventArgs> action)
        {
            if (action == null)
            {
                throw new ApplicationException("`action` cannot be null");
            }

            Action = action;
        }

        public void Notify(object Sender, ObsEventArgs args)
        {
            Action(Sender, args);
        }

        public void SetReference(ObservableEvent e)
        {
            if (IsDisposed)
            {
                throw new ApplicationException("Cannot reuse EventObserver. Must create a new instance");
            }
            ObsEvent = e;
        }
        public void RemoveReference()
        {
            ObsEvent = null;
        }

        public void Dispose()
        {
            IsDisposed = true;
            if (ObsEvent != null)
            {
                ObsEvent.Unsubscribe(this);
                ObsEvent = null;
                Action = null;
            }
        }
    }
}
