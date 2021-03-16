using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace spaceshooter
{
    class Mine : Enemy
    {
        public Mine(Texture2D sprite, float X, float Y) : base(sprite, X, Y, 6f, 0.3f)
        {
        }
        public override void Update(GameWindow window)
        {
            position.X += speed.X;
            if (position.X > window.ClientBounds.Width - sprite.Width || position.X < 0)
            {
                speed.X *= -1;
            }
            position.Y += speed.Y;
            if (position.Y > window.ClientBounds.Height)
            {
                isAlive = false;
            }
        }
    }
}