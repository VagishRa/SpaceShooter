using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace spaceshooter
{
    class MovingObject : GameObject
    {
        protected Vector2 speed;
        public MovingObject(Texture2D sprite, float X, float Y, float speedX, float speedY) : base(sprite, X, Y)
        {
            speed.X = speedX;
            speed.Y = speedY;
        }

    }
}
