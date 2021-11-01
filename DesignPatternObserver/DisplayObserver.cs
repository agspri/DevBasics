using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternObserver
{
    class DisplayObserver : IObserver
    {
        public void Update(float value)
        {
            Console.WriteLine("DisplayObserver: Update Display. Value " + value);
        }
    }
}
