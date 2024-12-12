using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace GameDevProject
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Player player;
        PlayerShoot playerShoot;
        EnemySpawner enemySpawner;

        Texture2D playerSpriteSheet;
        int counter;
        int activeFrame;
        int numFrames;

        public List<Enemy> enemies = new List<Enemy>();

        Texture2D bulletSprite;
        Texture2D enemySprite;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.IsFullScreen = true;

            _graphics.PreferredBackBufferWidth = 1920;   
            _graphics.PreferredBackBufferHeight = 1080;   
        }


        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Laad de sprite sheet eerst
            playerSpriteSheet = Content.Load<Texture2D>("PngItem_6602144");
            bulletSprite = Content.Load<Texture2D>("98948-200");
            enemySprite = Content.Load<Texture2D>("pngkey.com-spaceship-png-280173");

            // Maak de speler aan nadat de sprite is geladen
            player = new Player(playerSpriteSheet, new Vector2(100, 100), bulletSprite);
            enemySpawner = new EnemySpawner(this, player);
            playerShoot = new PlayerShoot(bulletSprite, player.pos);

            activeFrame = 0;
            numFrames = 3;
            counter = 0;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            player.Update();
            enemySpawner.Update(gameTime);
            playerShoot.Update(player.pos, gameTime);


            counter++;
            if (counter > 29)
            {
                counter = 0;
                activeFrame++;

                if (activeFrame == numFrames)
                {
                    activeFrame = 0;
                }
            }

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            _spriteBatch.Begin();

            playerShoot.Draw(_spriteBatch);

            int frameWidth = 150;
            int frameHeight = 381;
            int frameX = (activeFrame + 1) * frameWidth;

            Vector2 origin = new Vector2(frameWidth / 2f, frameHeight / 2f);

            _spriteBatch.Draw(
                playerSpriteSheet,
                player.pos,
                new Rectangle(frameX, 0, frameWidth, frameHeight),
                Color.White,
                player.rotation,
                origin,
                .25f,
                SpriteEffects.None,
                0f
            );

            foreach(Enemy e in enemies)
            {
                e.Draw(enemySprite, _spriteBatch);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
