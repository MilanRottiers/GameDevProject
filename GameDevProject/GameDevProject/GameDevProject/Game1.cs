using GameDevProject.enemies;
using GameDevProject.player;
using GameDevProject.scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace GameDevProject
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;

        public float CurrentScene = 0; //0 = menu, 1-3 = levels, 4 = death screen, 5 = win screen
        Menu menu;
        Scene1 scene1;
        List<Scene> scenes = new List<Scene>();


        Player player;

        Texture2D playerSpriteSheet;
        int counter;
        public int activeFrame;
        int numFrames;

        public List<Enemy> enemies = new List<Enemy>();

        Texture2D bulletSprite;
        Texture2D enemySprite;
         
        KeyboardState keyboardState = Keyboard.GetState();

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
            bulletSprite = Content.Load<Texture2D>("bullet");

            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Initialiseer objecten
            player = new Player(playerSpriteSheet, new Vector2(100, 100), bulletSprite, this);

            activeFrame = 0;
            numFrames = 3;
            counter = 0;

            //create scenes
            menu = new Menu(this, _spriteBatch);
            scene1 = new Scene1(this, player);

            //add scenes
            scenes.Add(menu);
            scenes.Add(scene1);
        }

        protected override void Update(GameTime gameTime)
        {
            keyboardState = Keyboard.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (CurrentScene == 0)
            {
                menu.Update(gameTime);
            }
            else if (CurrentScene == 1)
            {
                scene1.Update(gameTime);
            }

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

            if (keyboardState.IsKeyDown(Keys.C) && CurrentScene == 0)
            {
                CurrentScene += 1;
            }

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            if (CurrentScene == 0)
            {
                menu.Draw(_spriteBatch);
            }
            else if (CurrentScene == 1)
            {
                scene1.Draw(_spriteBatch);
            }

            base.Draw(gameTime);
        }
    }
}
