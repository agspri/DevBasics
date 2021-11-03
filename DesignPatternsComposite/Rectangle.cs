using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsCompositeA
{
    class Rectangle : IShape
    {
        public void Draw() => Console.WriteLine("Drawing Rectangle");
    }
}
