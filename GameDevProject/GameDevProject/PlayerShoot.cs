using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GameDevProject
{
    internal class PlayerShoot
    {
        Texture2D bulletSprite;
        Vector2 pos;

        private List<Bullet> bullets = new List<Bullet>();

        float counter = 0;

        public PlayerShoot(Texture2D bulletSprite, Vector2 pos)
        {
            this.bulletSprite = bulletSprite;
            this.pos = pos;
        }

        public void Update()
        {
            counter++;
            if (counter > 29)
            {
                counter = 0;
            }

            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                Vector2 direction = Mouse.GetState().Position.ToVector2() - pos;
                bullets.Add(new Bullet(bulletSprite, this.pos, direction));
            }


            // Update bullets
            foreach (var bullet in bullets)
            {
                bullet.Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var bullet in bullets)
            {
                bullet.Draw(spriteBatch);
            }
        }

    }
}