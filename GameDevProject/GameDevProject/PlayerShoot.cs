using GameDevProject;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System;

internal class PlayerShoot
{
    private Texture2D bulletSprite;
    private Vector2 playerPosition;
    private List<Bullet> bullets = new List<Bullet>();

    private float timeSinceLastShot = 0f;  // Tijd sinds het laatste schot
    private float shootCooldown = 0.1f;    // Cooldown-tijd tussen schoten in seconden (0.1 seconde)

    public PlayerShoot(Texture2D bulletSprite, Vector2 pos)
    {
        this.bulletSprite = bulletSprite;
        this.playerPosition = pos;
    }

    public void Update(Vector2 playerPosition, GameTime gameTime)
    {
        this.playerPosition = playerPosition;

        timeSinceLastShot += (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (Mouse.GetState().LeftButton == ButtonState.Pressed)
        {
            
            if (timeSinceLastShot >= shootCooldown)
            {
                timeSinceLastShot = 0f; // Reset de timer
                Vector2 direction = Mouse.GetState().Position.ToVector2() - this.playerPosition;
                bullets.Add(new Bullet(bulletSprite, this.playerPosition, direction));
            }
        }

        // Update de kogels
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
