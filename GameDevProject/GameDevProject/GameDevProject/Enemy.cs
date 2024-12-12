using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Numerics;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace GameDevProject
{
    public class Enemy
    {
        Vector2 position;

        public Enemy(Vector2 position)
        {
            Random rng = new Random();
            this.position = position;
        }

        public void Draw(Texture2D enemySprite, SpriteBatch spriteBatch)
        {
            Vector2 origin = new Vector2(enemySprite.Width / 2f, enemySprite.Height / 2f);

            // Stel de schaal in (bijvoorbeeld 0.5f om de kogel te verkleinen)
            float scale = 0.1f; // Pas de schaal aan zoals gewenst

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
