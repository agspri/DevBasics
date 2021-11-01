using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternObserver
{
    class NotificationObserver : IObserver
    {
        public void Update(float value)
        {
            Console.WriteLine("NotificationObserver: Sending Notification: " + value);
        }
    }
}
