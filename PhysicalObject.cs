using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace spaceshooter
{
    abstract class PhysicalObject : MovingObject
    {
        protected bool isAlive = true;
        public PhysicalObject(Texture2D sprite, float X, float Y, float speedX, float speedY) : base(sprite, X, Y, speedX, speedY)
        {

        }
        public bool CheckCollision(PhysicalObject other)
        {
            Rectangle myRect = new Rectangle(Convert.ToInt32(X), Convert.ToInt32(Y), Convert.ToInt32(Width), Convert.ToInt32(Height));
            Rectangle otherRect = new Rectangle(Convert.ToInt32(other.X), Convert.ToInt32(other.Y), Convert.ToInt32(other.Width), Convert.ToInt32(other.Height));

            return myRect.Intersects(otherRect);
        }

        public bool IsAlive { get { return isAlive; } set { isAlive = value; } }
    }



}