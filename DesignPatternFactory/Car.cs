using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternFactory
{
    class Car : IVehicle
    {
        public void Move(string to)
        {
            Console.WriteLine("Car is moving to " + to);
        }
    }
}
