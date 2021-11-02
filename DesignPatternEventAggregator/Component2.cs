using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternEventAggregator
{
    class Component2 : IDisposable
    {
        IEventAggregator aggregator;
        Subscription subscription;

        public Component2(EventAggregator eventAggregator)
        {
            aggregator = eventAggregator ?? throw new ArgumentNullException(nameof(eventAggregator));
            subscription = aggregator.Subscribe<MessageObject>((o) => EventReceived(o.Data));
        }

        public void Dispose()
        {
            subscription?.Dispose();
        }

        void EventReceived(string msg)
        {
            Console.WriteLine($"{nameof(Component2)} received {msg}");
        }
        //public void FireEvent(string msg)
        //{

        //}
    }
}
