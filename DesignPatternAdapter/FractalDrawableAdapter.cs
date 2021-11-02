using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternAdapter
{
    class FractalDrawableAdapter : IDrawableItem
    {
        IFractalGenerator source;

        public FractalDrawableAdapter(IFractalGenerator source)
        {
            this.source = source;
        }

        public void Draw()
        {
            this.source?.Generate();
        }
    }
}
