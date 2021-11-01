using System;
using System.Collections.Generic;
using System.Linq;  // <--- extension methods

namespace ExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            // using Linq extension
            string[] arr = new string[2] { "elem 1", "elem 2" };
            IEnumerable<string> list =  arr.Append("appended elem 3");  // Append is a Extension Method

            foreach(var s in list)
            {
                Console.WriteLine("arr item: " + s);
            }

            // use self implemented extension for class DateTime
            DateTime myDateTime = DateTime.Now;            
            string dateStr1 = DateTimeExtensions.ToFormatYYYYMMdd(myDateTime);
            string dateStr2 = myDateTime.ToFormatYYYYMMdd();
            string dateStr3 = myDateTime.ToFormatYYYYMMddSep(".");

            Console.WriteLine("dateStr1: " + dateStr1);
            Console.WriteLine("dateStr2: " + dateStr2);
            Console.WriteLine("dateStr3: " + dateStr3);
            Console.ReadLine();
        }
    }
}
