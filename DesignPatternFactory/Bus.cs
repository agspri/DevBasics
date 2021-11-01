using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternFactory
{
    class Bus : IVehicle
    {
        public void Move(string to)
        {
            Console.WriteLine("Bus is moving to " + to);
        }
    }
}
