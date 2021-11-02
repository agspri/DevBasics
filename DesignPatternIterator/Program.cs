using System;

namespace DesignPatternIterator
{
    class Program
    {
        static void Main(string[] args)
        {
            executeVariante1();
            executeVariante2();

            Console.ReadKey();
        }

        /// <summary>
        ///  Variante 1 ohne yield
        /// </summary>
        static void executeVariante1() {
           
            //MyClassicCollection<int> myColl = new MyClassicCollection<int>(1, 2, 3, 4, 5);
            //var enumerator = myColl.GetEnumerator();

            //while (enumerator.MoveNext())
            //{
            //    Console.WriteLine("item: " + enumerator.Current);
            //}

            //foreach (int item in myColl)
            //{
            //    Console.WriteLine("item: " + item);
            //}
        }

        /// <summary>
        /// Variante 2 mit yield
        /// </summary>
        static void executeVariante2()
        {
            MyCollection<int> myColl = new MyCollection<int>(1, 2, 3, 4, 5);

            foreach (int item in myColl)
            {
                Console.WriteLine("item: " + item);
            }

        }

    }
}
