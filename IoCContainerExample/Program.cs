using System;

namespace IoCContainerExample
{
    class Program
    {
        static void Main(string[] args)
        {
            IoCContainer container = new IoCContainer(); // Todo: besser als Singleton

            container.Register<IMyInterface, MyImplementation>(Lifetimes.Singleton);

            IMyInterface myImpl = container.Resolve<IMyInterface>();

            Console.ReadKey();
        }
    }
}
