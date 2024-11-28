using GameDevProject;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;

internal class Player
{
    public Vector2 pos;
    public float rotation;

    private float speedX = 0;
    private float speedY = 0;

    private float actualSpeedX;
    private float actualSpeedY;

    private PlayerShoot playerShoot;

    public Player(Texture2D texture, Vector2 pos, Texture2D bulletSprite)
    {
        this.pos = pos;
        playerShoot = new PlayerShoot(bulletSprite, pos);
    }

    public Rectangle Rect
    {
        get
        {
            return new Rectangle((int)pos.X, (int)pos.Y, 100, 200);
        }
    }

    public void Update()
    {
        playerShoot.Update();

        MouseState mouse = Mouse.GetState();

        Vector2 distance;
        distance.X = mouse.X - pos.X;
        distance.Y = mouse.Y - pos.Y;

        rotation = (float)Math.Atan2(distance.Y, distance.X) + MathHelper.PiOver2;

        pos.X += actualSpeedX;
        pos.Y += actualSpeedY;

        if (Math.Abs(actualSpeedX - speedX) < 0.1f)
        {
            actualSpeedX = speedX;
        }
        else
        {
            actualSpeedX += (actualSpeedX < speedX) ? 0.1f : -0.1f;
        }

        if (Math.Abs(actualSpeedY - speedY) < 0.1f)
        {
            actualSpeedY = speedY;
        }
        else
        {
            actualSpeedY += (actualSpeedY < speedY) ? 0.1f : -0.1f;
        }

        KeyboardState keyboardState = Keyboard.GetState();

        speedY = keyboardState.IsKeyDown(Keys.W) ? -3 :
                 keyboardState.IsKeyDown(Keys.S) ? 3 : 0;

        speedX = keyboardState.IsKeyDown(Keys.A) ? -3 :
                 keyboardState.IsKeyDown(Keys.D) ? 3 : 0;
    }
}
