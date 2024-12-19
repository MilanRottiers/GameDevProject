using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Numerics;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace GameDevProject.enemies
{
    public class Enemy
    {
        Vector2 position;
        Player player;
        Texture2D enemySprite;
        Game1 game;


        public Enemy(Vector2 position, Player player, Texture2D enemySprite, Game1 game)
        {
            this.enemySprite = enemySprite;
            this.position = position;
            this.player = player;
            game = game;
        }


        public Rectangle BoundingBox
        {
            get
            {
                int width = (int)(enemySprite.Width * 0.1f); // Schaalfactor gebruiken
                int height = (int)(enemySprite.Height * 0.1f);
                return new Rectangle(
                    (int)(position.X - width / 2),
                    (int)(position.Y - height / 2),
                    width,
                    height
                );
            }
        }



        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 origin = new Vector2(enemySprite.Width / 2f, enemySprite.Height / 2f);

            float scale = 0.1f;


            spriteBatch.Draw(
                enemySprite,
                position,
                null,
                Color.White,
                0f,
                origin,
                scale,
                SpriteEffects.None,
                0f
            );
        }
    }
}
