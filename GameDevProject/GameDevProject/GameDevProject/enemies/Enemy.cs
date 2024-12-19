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

        public Enemy(Vector2 position, Player player)
        {
            this.position = position;
            this.player = player;
        }

        public void Update()
        {

        }

        public void Draw(Texture2D enemySprite, SpriteBatch spriteBatch)
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
