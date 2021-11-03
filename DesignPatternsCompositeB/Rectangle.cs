using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsCompositeB
{
    class Rectangle : Shape
    {
        protected override void DoDraw() => Console.WriteLine("Rectangle");
    }
}
