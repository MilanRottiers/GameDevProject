using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevProject.scenes
{
    public abstract class Scene
    {
        protected Game1 game;
        SpriteBatch _spriteBatch;
        protected Scene(Game1 game, SpriteBatch _spriteBatch)
        {
            this.game = game;
            this._spriteBatch = _spriteBatch;
        }

        protected Scene(Game1 game)
        {
            this.game = game;
        }

        protected abstract void Load();
        public abstract void Draw(SpriteBatch _spriteBatch);
        public abstract void Update(GameTime gameTime);
    }
}
