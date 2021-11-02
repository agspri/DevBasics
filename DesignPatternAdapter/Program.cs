using System;

namespace DesignPatternAdapter
{
    class Program
    {
        static void Main(string[] args)
        {
            Scene scene = new Scene();
            scene.ItemsInScene.Add(new Circle());
            scene.ItemsInScene.Add(new FractalDrawableAdapter(new MountainGenerator()));
            scene.ItemsInScene.Add(new PlayerDrawableAdapter(new Player()));
            scene.Draw();

            Console.ReadKey();
        }
    }
}
