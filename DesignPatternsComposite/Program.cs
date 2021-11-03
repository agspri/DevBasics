using System;

namespace DesignPatternsCompositeA
{
    class Program
    {
        static void Main(string[] args)
        {
            Group myGroup = new Group();
            myGroup.Add(new Rectangle());
            myGroup.Add(new Circle());
            Group myGroup2 = new Group();
            myGroup.Add(myGroup2);

            IShape[] myShapes = new IShape[]
            {
                new Rectangle(),
                new Circle(),
                new Line(),
                myGroup
            };

            foreach(var shape in myShapes)
            {
                shape.Draw();
            }

            Console.ReadKey();
        }
    }
}
