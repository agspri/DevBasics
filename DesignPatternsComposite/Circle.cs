using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsCompositeA
{
    class Circle : IShape
    {
        public void Draw() => Console.WriteLine("Drawing Circle");
    }
}
