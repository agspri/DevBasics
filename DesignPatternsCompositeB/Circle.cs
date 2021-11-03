using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsCompositeB
{
    class Circle : Shape
    {
        protected override void DoDraw() => Console.WriteLine("Circle");
    }
}
