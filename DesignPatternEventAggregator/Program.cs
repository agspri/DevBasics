using System;

namespace DesignPatternEventAggregator
{
    /// <summary>
    /// EventAggregator: Subscribe & Publish
    /// Abhängigkeiten von Komponenten auf ein Minimum reduziren.
    /// Die Komponenten müssen sich nicht gegenseitig kennen.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            EventAggregator eventAggregator = new EventAggregator();
            Component1 c1 = new Component1(eventAggregator);
            Component2 c2 = new Component2(eventAggregator);

            c1.FireEvent("Nachricht von C1");
            eventAggregator.Publish<MessageObject2>(new MessageObject2() { DemoValue = 42 });

            c1.Dispose();
            c2.Dispose();

            //using (Subscription sub = eventAggregator.Subscribe<MessageObject>((o) => Info(o)))
            //{
            //    // Hier wird die Subscription benutzt
            //    eventAggregator.Publish<MessageObject>(new MessageObject() { Data = "New Event" });
            //}

            Console.ReadKey();
        }

        //static void Info(MessageObject o)
        //{
        //    Console.WriteLine("Event received " + o.Data);
        //}
    }
}
