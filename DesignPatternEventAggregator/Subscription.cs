using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternEventAggregator
{
    public class Subscription : IDisposable
    {
        Action removeMethod;

        public Subscription(Action removeMethod)
        {
            this.removeMethod = removeMethod;
        }

        public void Dispose()
        {
            if (this.removeMethod != null)
                removeMethod();
        }
    }
}
