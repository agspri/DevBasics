using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternAdapter
{
    class Scene : IDrawableItem
    {
        public List<IDrawableItem> ItemsInScene { get; set; } = new List<IDrawableItem>();

        public void Draw()
        {
            foreach(var item in ItemsInScene)
            {
                item.Draw();
            }
        }
    }
}
