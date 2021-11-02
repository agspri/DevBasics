using System;
using System.Collections.Generic;

namespace Delegates
{
    class Program
    {
        static string TMP_FILE = @"D:\tmp\Logs\log.txt";

        static Action<string> logMethod;  // Delegate

        delegate float MyMethodDelegate(int number, bool isSuccess, string name, char symbol);
        static void Main(string[] args)
        {
            executePart1();
            executePart2();
            executePart3();
        }

        static void executePart3()
        {
            logMethod = LogToConsole;

            int[] data = { 14, 1, 7, 9, 4, 20 };
            int[] filtered = Filter(data, (elem) => elem % 2 == 0);        // Anonymous Method
            logMethod("     Filtered: " + String.Join(' ', filtered));

            Func<int, int, double> myCalculation1 = Devide;
            logMethod("Ergebnis: " + myCalculation1(3, 2));
            myCalculation1 = Zero;
            logMethod("Ergebnis: " + myCalculation1(1, 2));

            Func<int, bool, string, char, float> myMethod = (i, b, s, c) => 0.1f;

            MyMethodDelegate myMethod2 = (i, b, s, c) => 0.1f;

            logMethod("---Ende---");
        }

        static double Devide(int a, int b) => (double)a / (double)b;
        static double Zero(int a, int b) => 0.0;

        static void executePart2()
        {
            logMethod = LogToConsole;
            //logMethod = LogToFile;

            int[] data = { 14, 1, 7, 9, 4, 20 };
            //int[] filtered = Filter(data, IsBiggerThan5);
            int[] filtered = Filter(data, (elem) => elem <= 5);        // Anonymous Method
            logMethod("     Filtered: " + String.Join(' ', filtered));
        }

        //static bool IsBiggerThan5(int item)
        //{
        //    return item > 5;
        //}
        static bool IsBiggerThan5(int item) => item > 5;

        //static bool IsEvenNumber(int item)
        //{
        //    return item % 2 == 0;
        //}
        static bool IsEvenNumber(int item) => item % 2 == 0;

        static int[] Filter(int[] data, Predicate<int> filterCriteria)
        {
            List<int> result = new List<int>();
            foreach (int item in data)
            {
                if (filterCriteria(item) == true)
                    result.Add(item);
            }

            return result.ToArray();
        }

        static void executePart1()
        {
            logMethod = LogToConsole;
            //logMethod = LogToFile;

            int[] data = { 14, 7, 9, 20 };

            logMethod("        Input: " + String.Join(' ', data));
            QuickSort(data);
            logMethod("Sorted output: " + String.Join(' ', data));
        }

        static void LogToConsole(string text)
        {
            Console.WriteLine(text);
        }

        static void LogToFile(string text)
        {
            System.IO.File.AppendAllLines(TMP_FILE, new string[] { text });
        }
        private static void QuickSort(Span<int> data)
        {
            if (data.Length <= 1)
                return;

            int i = 0;
            int j = data.Length - 1;

            int pivot = data[0];
            int temp;
            int split = 0;

            while (true)
            {
                while (data[i] < pivot)
                    i++;
                while (data[j] > pivot)
                    j--;

                if (i < j && data[i] != data[j])
                {
                    temp = data[i];
                    data[i] = data[j];
                    data[j] = temp;
                    logMethod($"SW {i}, {j}: {String.Join(' ', data.ToArray())}");
                }
                else
                {
                    split = j;
                    break;
                }
            }

            logMethod($"SPLIT AT {split}: {String.Join(' ', data.ToArray())}");

            if (split > 1)
            {
                QuickSort(data[..split]);
            }

            if (split + 1 < data.Length)
            {
                QuickSort(data[(split + 1)..]);
            }
        }
    }
}
