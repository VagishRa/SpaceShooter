using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace spaceshooter
{
    class Tripod : Enemy
    {
        public Tripod(Texture2D sprite, float X, float Y, float speedX, float speedY) : base(sprite, X, Y, 0, 3f) { }
        public override void Update(GameWindow window)
        {

            position.Y += speed.Y;
            if (position.Y > window.ClientBounds.Height)
                isAlive = false;
        }
    }
}