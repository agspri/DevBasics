using System;
using System.Dynamic;

namespace DynamicVsVarVsObject
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "Hello";
            string u = s.ToUpper();   // funzt

            var sv = "Hello";         // Compiler ermittelt automatisch welcher Datentyp gemeint ist.
            string uv = sv.ToUpper(); // funzt

            object so = "Hello";
            //string uo = so.ToUpper();  // funzt net!!!  Keine Vorschläge von Intellisense.
            string uo = ((string)so).ToUpper();   // Mit Casting funzt es.

            dynamic sd = "Hello";      // Compiler ist sozusagen ausgeschaltet.
                                       // Mit dynamic geht der Compiler davon aus, dass alles koreeckt sein wird
                                       // zur Laufzeit. Zur Laufzeit muss alles vorhanden sein und passen.
            string ud = sd.ToUpper();  // Keine Vorschläge von Intellisense.
                                       //string udXYZ = sd.ToUpperXYZ();  // Keine Fehlermeldung vor Laufzeit. Wird aber zur Laufzeit
                                       // mit RunTimeBinderException abstuerzen!

            // dynamic objects können um Eigenschaften und Methoden verändert/erweitert werden.
            dynamic myObj = new ExpandoObject();   // using System.Dynamic;  erforderlich.
            myObj.Name = "Sepp";
            Console.WriteLine("myObj.Name = " + myObj.Name);

            myObj.Value = 1;
            myObj.Increment = (Action)(() => myObj.Value++);
            Console.WriteLine("myObj.Value = " + myObj.Value);
            myObj.Increment();
            Console.WriteLine("myObj.Value = " + myObj.Value);

            Console.WriteLine("Press key");
        }
    }
}
