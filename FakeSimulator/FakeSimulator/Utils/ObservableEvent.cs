using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeSimulator.Utils
{
    public class ObservableEvent : IDisposable
    {
        List<EventObserver> Observers = new List<EventObserver>();

        public void Subscribe(EventObserver iobs)
        {
            Observers.Add(iobs);
            iobs.SetReference(this);
        }

        public void Unsubscribe(EventObserver iobs)
        {
            iobs.RemoveReference();
            Observers.Remove(iobs);
        }

        public void Notify(object sender, ObsEventArgs args)
        {
            Observers.ForEach(x =>
            {
                if (x != null) { x.Notify(sender, args); }
            });
        }

        public void Dispose()
        {
            Observers.ForEach(x =>
            {
                if (x != null)
                {
                    x.RemoveReference();
                }
            });
            Observers.Clear();
        }
    }
}
