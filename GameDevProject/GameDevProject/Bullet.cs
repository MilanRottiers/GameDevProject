using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevProject
{
    internal class Bullet
    {
        private Texture2D bulletSprite;
        private Vector2 pos;
        private Vector2 direction;
        private float speed = 5f;

        public Bullet(Texture2D bulletSprite, Vector2 startPos, Vector2 direction)
        {
            this.bulletSprite = bulletSprite;
            this.pos = startPos;
            this.direction = Vector2.Normalize(direction);
        }

        public void Update()
        {
            pos += direction * speed;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(bulletSprite, pos, Color.Red);
        }
    }

}
