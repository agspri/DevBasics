using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternEventAggregator
{
    class EventAggregator : IEventAggregator
    {
        object locker = new object();

        List<(Type eventType, Delegate methodToCall)> eventRegistrations =
            new List<(Type eventType, Delegate methodToCall)>();

        //public void Subscribe<T>(string message, Action<T> action)
        public Subscription Subscribe<T>(Action<T> action)
        {
            if (action != null)
            {
                lock (locker)
                {
                    this.eventRegistrations.Add((typeof(T), action));
                    return new Subscription(() =>
                    {
                        this.eventRegistrations.Remove((typeof(T), action));
                    });
                }
            }

            return new Subscription(() => { });
        }

        //public void Publish<T>(string message, T data)
        public void Publish<T>(T data)
        {
            List<(Type type, Delegate methodToCall)> regs = null;
            lock (locker)
            {
                regs = new List<(Type eventType, Delegate methodToCall)>(eventRegistrations);
            }

            foreach (var item in regs)
            {
                if (item.type == typeof(T))
                    ((Action<T>)item.methodToCall)(data);
            }
        }
    }
}
