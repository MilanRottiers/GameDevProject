using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System;
using GameDevProject.player;
using GameDevProject;

public class PlayerShoot
{
    private Texture2D bulletSprite;
    private Vector2 playerPosition;
    public List<Bullet> bullets = new List<Bullet>();
    private Game1 game;

    private float timeSinceLastShot = 0f;  // Tijd sinds het laatste schot
    private float shootCooldown = 0.1f;    // Cooldown-tijd tussen schoten in seconden (0.1 seconde)

    public PlayerShoot(Texture2D bulletSprite, Vector2 pos, Game1 game)
    {
        this.bulletSprite = bulletSprite;
        this.playerPosition = pos;
        this.game = game;
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
                bullets.Add(new Bullet(bulletSprite, this.playerPosition, direction, game, this));
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
