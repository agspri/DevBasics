using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternAdapter
{
    class PlayerDrawableAdapter : IDrawableItem
    {
        Player player;

        public PlayerDrawableAdapter(Player player)
        {
            this.player = player;
        }

        public void Draw()
        {
            this.player.Render();
        }
    }
}
