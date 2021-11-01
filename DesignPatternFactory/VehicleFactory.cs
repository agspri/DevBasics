using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternFactory
{
    public enum VehicleTypes
    {
        Car,
        Bus
    }

    class VehicleFactory
    {
        public static IVehicle CreateVehicle(VehicleTypes type)
        {
            switch(type)
            {
                case VehicleTypes.Car:
                    return new Car();
                case VehicleTypes.Bus:
                    return new Bus();
                default:
                    throw new NotSupportedException("Invalid vehicle type " + type);
            }
        }
    }
}
