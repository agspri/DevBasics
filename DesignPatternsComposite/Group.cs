using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsCompositeA
{
    class Group : IShape
    {
        List<IShape> shapes = new List<IShape>();

        public void Add(IShape shape) => shapes.Add(shape);
        public void Remove(IShape shape) => shapes.Remove(shape);

        public void Draw()
        {
            Console.WriteLine("Drawing Group");
            foreach (var shape in shapes)
                shape.Draw();
        }

        public IShape this[int idx] => shapes[idx];
    }
}
