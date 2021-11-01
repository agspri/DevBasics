using System;

namespace DesignPatternSingleton
{
    class Program
    {
        static void Main(string[] args)
        {
            UserContext userContext1 = UserContext.Instance;
            UserContext userContext2 = UserContext.Instance;
            Console.WriteLine("Are userContext1 and UserContext.Instance equal? " + (userContext1 == UserContext.Instance));
            Console.WriteLine("Are userContext1 and userContext2 equal? " + (userContext1 == UserContext.Instance));

            Console.WriteLine("Press any key");
        }
    }
}
