using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using spaceshooter;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpaceShooter
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        SpaceShip player;
        List<Enemy> enemies;
        PrintText printText;
        List<GoldCoin> goldCoins;
        Texture2D goldCoinSprite;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            goldCoins = new List<GoldCoin>();
            goldCoinSprite = Content.Load<Texture2D>("images/powerups/coin");

            base.Initialize();
        }

        protected override void LoadContent()
        {

            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            printText = new PrintText(Content.Load<SpriteFont>("minFont"));

            player = new SpaceShip(Content.Load<Texture2D>("images/ship"), 400, 400, 10f, 10f, Content.Load<Texture2D>("images/bullet"));
            enemies = new List<Enemy>();
            Random random = new Random();
            Texture2D tmpSprite = Content.Load<Texture2D>("images/enemies/mine");
            for (int i = 0; i < 10; i++)
            {
                int rndX = random.Next(0, Window.ClientBounds.Width - tmpSprite.Width);
                int rndY = random.Next(0, Window.ClientBounds.Height / 2);
                Mine temp = new Mine(tmpSprite, rndX, rndY);
                enemies.Add(temp);
            }
            tmpSprite = Content.Load<Texture2D>("images/enemies/tripod");
            for (int i = 0; i < 5; i++)
            {
                int rndX = random.Next(0, Window.ClientBounds.Width - tmpSprite.Width);
                int rndY = random.Next(0, Window.ClientBounds.Height / 2);
                Mine temp = new Mine(tmpSprite, rndX, rndY);
                enemies.Add(temp);
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            Random random = new Random();
            int newCoin = random.Next(1, 200);
            if (newCoin == 1)
            {
                int rndX = random.Next(0, Window.ClientBounds.Width);
                int rndY = random.Next(0, Window.ClientBounds.Height);
                goldCoins.Add(new GoldCoin(goldCoinSprite, rndX, rndY, gameTime));
            }
            foreach (GoldCoin gc in goldCoins.ToList())
            {
                if (gc.IsAlive)
                {
                    gc.Update(gameTime);
                    if (gc.CheckCollision(player))
                    {
                        goldCoins.Remove(gc);
                        player.Points++;
                    }
                }
                else
                    goldCoins.Remove(gc);

            }
            player.Update(Window, gameTime);
            foreach (Enemy e in enemies.ToList())
            {
                if (e.IsAlive)
                {
                    if (e.CheckCollision(player))
                        this.Exit();

                    e.Update(Window);
                }


                else
                    enemies.Remove(e);
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            player.Draw(_spriteBatch);
            foreach (Enemy e in enemies)
            {
                e.Draw(_spriteBatch);
            }
            foreach (GoldCoin gc in goldCoins)
            {
                gc.Draw(_spriteBatch);
            }

            printText.Print("Points:" + player.Points, _spriteBatch, 0, 0);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}