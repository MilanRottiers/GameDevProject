using GameDevProject.enemies;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GameDevProject.scenes
{
    internal class Scene1 : Scene
    {
        Game1 game;
        Texture2D backgroundImage;

        Player player;

        EnemySpawner enemySpawner;
        Texture2D playerSpriteSheet;
        Texture2D bulletSprite;
        Texture2D enemySprite;

        public Scene1(Game1 game, Player player) : base(game)
        {
            this.game = game;
            this.player = player;
            Load();
        }

        protected override void Load()
        {

            backgroundImage = game.Content.Load<Texture2D>("background");
            playerSpriteSheet = game.Content.Load<Texture2D>("PngItem_6602144");
            bulletSprite = game.Content.Load<Texture2D>("98948-200");
            enemySprite = game.Content.Load<Texture2D>("pngkey.com-spaceship-png-280173");

            enemySpawner = new EnemySpawner(game, player, enemySprite);
        }

        public override void Update(GameTime gameTime)
        {
            if (enemySpawner != null)
            {
                enemySpawner.Update(gameTime);

            }
            player.Update(gameTime);
        }

        public override void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();
            //draw background
            _spriteBatch.Draw(backgroundImage, Vector2.Zero, Color.White);

            int frameWidth = 150;
            int frameHeight = 381;
            int frameX = (game.activeFrame + 1) * frameWidth;

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

            if (game.enemies != null)
            {
                foreach (Enemy e in game.enemies)
                {
                    e.Draw(_spriteBatch);
                }
            }

            player.Draw(_spriteBatch);
            _spriteBatch.End();
        }
    }
}
