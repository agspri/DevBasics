using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsCompositeB
{
    class Line : Shape
    {
        protected override void DoDraw() => Console.WriteLine("Line");
    }
}
