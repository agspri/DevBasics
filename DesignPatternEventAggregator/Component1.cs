using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternEventAggregator
{
    class Component1 : IDisposable
    {
        IEventAggregator aggregator;
        Subscription eventSubscription;

        public Component1(IEventAggregator eventAggregator)
        {
            aggregator = eventAggregator;
            eventSubscription = aggregator.Subscribe<MessageObject2>(m => MessageReceived(m.DemoValue));
        }

        public void Dispose()
        {
            eventSubscription?.Dispose();
        }

        public void FireEvent(string msg)
        {
            // Fancy Code
            aggregator.Publish(new MessageObject() { Data = msg });
        }

        void MessageReceived(int val)
        {
            Console.WriteLine("Received: " + val.ToString());
        }
    }
}
