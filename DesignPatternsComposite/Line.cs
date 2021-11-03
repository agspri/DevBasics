using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsCompositeA
{
    class Line : IShape
    {
        public void Draw() => Console.WriteLine("Drawing Line");       
    }
}
