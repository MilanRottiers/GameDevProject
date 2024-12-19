using GameDevProject;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;

public class Player
{
    Game1 game;
    public bool IsAlive = true;
    public Vector2 pos;
    public float rotation;

    private float speedX = 0;
    private float speedY = 0;

    private float actualSpeedX;
    private float actualSpeedY;

    private PlayerShoot playerShoot;

    public Player(Texture2D texture, Vector2 pos, Texture2D bulletSprite, Game1 game)
    {
        this.pos = pos;
        playerShoot = new PlayerShoot(bulletSprite, pos, game);
        this.game = game;
    }

    public Rectangle Rect
    {
        get
        {
            return new Rectangle((int)pos.X, (int)pos.Y, 100, 200);
        }
    }

    public void Update(GameTime gametime)
    {
        playerShoot.Update(pos, gametime);

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

        if (keyboardState.IsKeyDown(Keys.W))
        {
            speedY = -3;
        }
        else if (keyboardState.IsKeyDown(Keys.S))
        {
            speedY = 3;
        }
        else
        {
            speedY = 0;
        }

        if (keyboardState.IsKeyDown(Keys.A))
        {
            speedX = -3;
        }
        else if (keyboardState.IsKeyDown(Keys.D))
        {
            speedX = 3;
        }
        else
        {
            speedX = 0;
        }

    }

    public void Draw(SpriteBatch spriteBatch)
    {
        playerShoot.Draw(game._spriteBatch);
    }
}
