using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.player
{
    internal class Bullet
    {
        private Texture2D bulletSprite;
        private Vector2 position;
        private Vector2 direction;
        private float speed = 5f;

        public Bullet(Texture2D bulletSprite, Vector2 startPosition, Vector2 direction)
        {
            this.bulletSprite = bulletSprite;
            position = startPosition;
            this.direction = Vector2.Normalize(direction); // Normaliseer de richting
        }

        public void Update()
        {
            // Verplaats de kogel in de richting
            position += direction * speed;
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
