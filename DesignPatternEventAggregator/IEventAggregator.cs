using System;

namespace DesignPatternEventAggregator
{
    interface IEventAggregator
    {
        void Publish<T>(T data);
        Subscription Subscribe<T>(Action<T> action);
    }
}