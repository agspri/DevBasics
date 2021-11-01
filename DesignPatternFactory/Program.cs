using System;

namespace DesignPatternFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            IVehicle bus = VehicleFactory.CreateVehicle(VehicleTypes.Bus);
            IVehicle car = VehicleFactory.CreateVehicle(VehicleTypes.Car);

            bus.Move("Berlin"); 
            car.Move("Paris");

            Console.ReadKey();
        }
    }
}
