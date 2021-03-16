using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;


namespace spaceshooter
{
    class GameObject
    {
        protected Texture2D sprite;
        protected Vector2 position;
        public GameObject(Texture2D sprite, float X, float Y)
        {
            this.sprite = sprite;
            this.position.X = X;
            this.position.Y = Y;
        }



        public virtual void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(sprite, position, Color.White);
        }

        public float X { get { return position.X; } }
        public float Y { get { return position.Y; } }
        public float Width { get { return sprite.Width; } }
        public float Height { get { return sprite.Height; } }
    }
}