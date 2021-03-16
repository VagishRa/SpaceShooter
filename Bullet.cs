using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace spaceshooter
{
    class Bullet : PhysicalObject
    {
        public Bullet(Texture2D sprite, float X, float Y) : base(sprite, X, Y, 0, 3f)
        {

        }

        public void Update()
        {
            position.Y -= speed.Y;
            if (position.Y < 0)
                isAlive = false;

        }

    }
}