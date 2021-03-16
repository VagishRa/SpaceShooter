using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace spaceshooter
{
    abstract class Enemy : PhysicalObject
    {
        public Enemy(Texture2D sprite, float X, float Y, float speedX, float speedY) : base(sprite, X, Y, speedX, speedY)
        {

        }
        public abstract void Update(GameWindow window);
    }
}

      