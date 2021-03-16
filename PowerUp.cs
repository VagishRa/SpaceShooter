using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace spaceshooter
{
    class GoldCoin : PhysicalObject
    {
        double timeToDie;
        public GoldCoin(Texture2D sprite, float X, float Y, GameTime gameTime) : base(sprite, X, Y, 0, 2f)
        {
            timeToDie = gameTime.TotalGameTime.TotalMilliseconds + 5000;
        }

        public void Update(GameTime gameTime)
        {
            if (timeToDie < gameTime.TotalGameTime.TotalMilliseconds)
            {
                isAlive = false;
            }
        }

    }
}