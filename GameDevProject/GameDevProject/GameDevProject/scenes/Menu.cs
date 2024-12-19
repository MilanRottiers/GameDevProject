using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevProject.scenes
{
    internal class Menu : Scene
    {

        Texture2D backgroundImage;

        public Menu(Game1 game, SpriteBatch _spriteBatch) : base(game, _spriteBatch)
        {
            Load();
        }

        public override void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();
            //draw background
            _spriteBatch.Draw(backgroundImage, new Rectangle(0, 0, 1920, 1080), Color.White);

            _spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {

        }

        protected override void Load()
        {
            backgroundImage = game.Content.Load<Texture2D>("menuBackground");
        }
    }
}
