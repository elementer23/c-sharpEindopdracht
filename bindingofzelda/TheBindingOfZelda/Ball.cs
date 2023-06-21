using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TheBindingOfZelda
{
    public class Ball : Entity
    {
        public Rectangle playerRect;
        public int width;
        public int height;

        public Ball(GraphicsDeviceManager graphics) : base(graphics)
        {
            playerRect = new Rectangle((int)GetPosition().X, (int)GetPosition().Y, 16, 16);
            SetSpeed(120f);
        }

        public void Update(GameTime gameTime, GraphicsDeviceManager graphics)
        {
            base.Update(gameTime);
            KeyboardState kstate = Keyboard.GetState();
            if (kstate.IsKeyDown(Keys.Up) && GetPosition().Y - (GetTexture().Height / 2) > 0)
            {
                SetAxis("y", GetAxis("y") - GetSpeed() * (float)gameTime.ElapsedGameTime.TotalSeconds);
            }

            if (kstate.IsKeyDown(Keys.Down) && GetPosition().Y + (GetTexture().Height / 2) < graphics.PreferredBackBufferHeight)
            {
                SetAxis("y", GetAxis("y") + GetSpeed() * (float)gameTime.ElapsedGameTime.TotalSeconds);
            }

            if (kstate.IsKeyDown(Keys.Left) && GetPosition().X - (GetTexture().Width / 2) > 0)
            {
                SetAxis("x", GetAxis("x") - GetSpeed() * (float)gameTime.ElapsedGameTime.TotalSeconds);
            }

            if (kstate.IsKeyDown(Keys.Right) && GetPosition().X + (GetTexture().Width / 2) < graphics.PreferredBackBufferWidth)
            {
                SetAxis("x", GetAxis("x") + GetSpeed() * (float)gameTime.ElapsedGameTime.TotalSeconds);
            }
            
            playerRect.X = (int)GetPosition().X;
        }
    }
}
