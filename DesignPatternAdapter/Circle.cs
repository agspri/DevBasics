using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternAdapter
{
    class Circle : IDrawableItem
    {
        public void Draw()
        {
            Console.WriteLine("Drawing circle... ");
        }
    }
}
