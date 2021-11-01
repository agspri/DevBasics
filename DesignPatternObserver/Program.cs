using System;

namespace DesignPatternObserver
{
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            TemperatureSubject sensor = new TemperatureSubject();
            IObserver observer1 = new NotificationObserver();
            IObserver observer2 = new DisplayObserver();

            sensor.Register(observer1);
            sensor.Register(observer2);

            sensor.Temperature = 10.0F;
            sensor.Temperature = 20.0F;


            Console.ReadKey();
        }
    }
}
