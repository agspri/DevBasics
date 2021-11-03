using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsCompositeB
{
    abstract class Shape
    {
        public List<Shape> Childs { get; } = new List<Shape>();

        protected abstract void DoDraw();

        public void Draw()
        {
            DoDraw();
            foreach (var child in Childs)
                child.Draw();
        }
    }
}
