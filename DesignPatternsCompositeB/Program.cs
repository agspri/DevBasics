using System;

namespace DesignPatternsCompositeB
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle myRect = new Rectangle();
            myRect.Childs.Add(new Circle());
            myRect.Childs.Add(new Line());

            Rectangle myRect2 = new Rectangle();
            myRect.Childs.Add(myRect2);
            myRect2.Childs.Add(new Circle());

            myRect.Draw();

            Console.ReadKey();
        }
    }
}
