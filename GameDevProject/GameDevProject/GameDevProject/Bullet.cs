using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Numerics;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace GameDevProject
{
    internal class Bullet
    {
        private Texture2D bulletSprite;
        private Microsoft.Xna.Framework.Vector2 position;
        private Vector2 direction;
        private float speed = 5f;

        public Bullet(Texture2D bulletSprite, Vector2 startPosition, Vector2 direction)
        {
            this.bulletSprite = bulletSprite;
            this.position = startPosition;
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

            // Stel de schaal in (bijvoorbeeld 0.5f om de kogel te verkleinen)
            float scale = 0.1f; // Pas de schaal aan zoals gewenst

            spriteBatch.Draw(
                bulletSprite,
                position,
                null,
                Color.White,
                0f,
                origin, // Gebruik het midden van de sprite als origin
                scale,
                SpriteEffects.None,
                0f
            );
        }


    }
}
