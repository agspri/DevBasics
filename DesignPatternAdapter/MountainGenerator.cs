using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternAdapter
{
    class MountainGenerator : IFractalGenerator
    {
        public void Generate()
        {
            Console.WriteLine("Generating Mountains...");
        }
    }
}
