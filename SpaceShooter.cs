using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using spaceshooter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceShooter
{
    class SpaceShip : PhysicalObject
    {
        private int points;
        List<Bullet> bullets;
        Texture2D bulletSprite;
        double timeSinceLastBullet = 0;
        public int Points { get { return points; } set { points = value; } }

        public SpaceShip(Texture2D sprite, float X, float Y, float speedX, float speedY, Texture2D bulletSprite) : base(sprite, X, Y, speedX, speedY)
        {

            bullets = new List<Bullet>();
            this.bulletSprite = bulletSprite;

        }

        public void Update(GameWindow window, GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Space))
            {
                if (gameTime.TotalGameTime.TotalMilliseconds > timeSinceLastBullet + 200)
                {
                    Bullet temp = new Bullet(bulletSprite, position.X + sprite.Width / 2, position.Y);
                    bullets.Add(temp);
                    timeSinceLastBullet = gameTime.TotalGameTime.TotalMilliseconds;
                }

            }

            if (position.X <= window.ClientBounds.Width - sprite.Width && position.X >= 0)
            {
                if (keyboardState.IsKeyDown(Keys.Right))
                    position.X += speed.X;
                if (keyboardState.IsKeyDown(Keys.Left))
                    position.X -= speed.X;
            }
            if (position.Y <= window.ClientBounds.Height - sprite.Height && position.Y >= 0)
            {
                if (keyboardState.IsKeyDown(Keys.Down))
                    position.Y += speed.Y;
                if (keyboardState.IsKeyDown(Keys.Up))
                    position.Y -= speed.Y;
            }

            if (position.X < 0)
                position.X = 0;
            if (position.X > window.ClientBounds.Width - sprite.Width)
                position.X = window.ClientBounds.Width - sprite.Width;

            if (position.Y < 0)
                position.Y = 0;
            if (position.Y > window.ClientBounds.Height - sprite.Height)
                position.Y = window.ClientBounds.Height - sprite.Height;

            foreach (Bullet b in bullets.ToList())
            {
                b.Update();
                if (!b.IsAlive)
                    bullets.Remove(b);
            }
        }
        public override void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(sprite, position, Color.White);
            foreach (Bullet b in bullets)
            {
                b.Draw(_spriteBatch);
            }
        }


    }
}