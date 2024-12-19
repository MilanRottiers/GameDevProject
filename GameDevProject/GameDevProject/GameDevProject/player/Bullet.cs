using GameDevProject.enemies;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace GameDevProject.player
{
    public class Bullet
    {
        private Texture2D bulletSprite;
        private Vector2 position;
        private Vector2 direction;
        private float speed = 5f;
        PlayerShoot spawner;
        Game1 game;

        public bool NeedsToDespawn = false;

        List<Enemy> enemies;

        public Bullet(Texture2D bulletSprite, Vector2 startPosition, Vector2 direction, Game1 game, PlayerShoot spawner)
        {
            this.spawner = spawner;
            this.bulletSprite = bulletSprite;
            position = startPosition;
            this.direction = Vector2.Normalize(direction); // Normaliseer de richting
            this.enemies = enemies;
            this.game = game;
        }

        public Rectangle BoundingBox
        {
            get
            {
                int width = (int)(bulletSprite.Width * 0.01f); // Schaalfactor gebruiken
                int height = (int)(bulletSprite.Height * 0.01f);
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
            position += direction * speed;

            Enemy enemyToRemove = null;

            foreach (Enemy enemy in game.enemies)
            {
                if (BoundingBox.Intersects(enemy.BoundingBox))
                {
                    enemyToRemove = enemy;
                    break;
                }
            }

            if (enemyToRemove != null)
            {
                game.enemies.Remove(enemyToRemove);
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Bepaal de origin als het midden van de kogel
            Vector2 origin = new Vector2(bulletSprite.Width / 2f, bulletSprite.Height / 2f);

            float scale = 0.01f; // Pas de schaal aan zoals gewenst

            spriteBatch.Draw(
                bulletSprite,
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
