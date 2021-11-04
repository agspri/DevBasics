using System;

namespace InOutByValueByRefExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Beispiel ByValueAndByRef:");
            ExampleByValueAndByRef();

            Console.WriteLine("\nBeispiel Out:");
            ExampleOut();

            Console.ReadKey();
        }

        public static void ExampleOut()
        {
            FunctionOut_GetNameParts(out string firstName, out string lastName);
            Console.WriteLine($"{firstName} {lastName}");

            if (int.TryParse("2", out int result))
            {
                Console.WriteLine("int value von string 2 = " + result);
            }
        }

        public static void ExampleByValueAndByRef()
        {
            int y = 42;
            Console.WriteLine($"y={y}");

            FunctionByValue(y);
            Console.WriteLine($"y={y}");

            FunctionByRef(ref y);
            Console.WriteLine($"y={y}");
        }

        public static int FunctionByValue(int x) => x++;
        public static int FunctionByRef(ref int x) => x++;

        public static void FunctionOut_GetNameParts(out string firstName, out string lastName)
        {
            firstName = "VornameOK";
            lastName = "NachnameOK";
        }
    }
}
