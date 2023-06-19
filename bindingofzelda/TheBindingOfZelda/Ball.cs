using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TheBindingOfZelda
{
    public class Ball : Entity
    {
        public Rectangle playerRect;
        private GraphicsDeviceManager _graphics;
        public Ball(GraphicsDeviceManager graphics) : base(graphics)
        {
            playerRect = new Rectangle((int)GetPosition().X, (int)GetPosition().Y, 16, 16);
            SetSpeed(120f);
        }

        public void Update(GameTime gameTime, GraphicsDeviceManager graphics)
        {
            base.Update(gameTime);
            KeyboardState kstate = Keyboard.GetState();
            if (kstate.IsKeyDown(Keys.Up) && GetAxis("y") > 0)
            {
                SetAxis("y", GetAxis("y") - GetSpeed() * (float)gameTime.ElapsedGameTime.TotalSeconds);
            }

            if (kstate.IsKeyDown(Keys.Down) && GetAxis("y") < graphics.PreferredBackBufferHeight)
            {
                SetAxis("y", GetAxis("y") + GetSpeed() * (float)gameTime.ElapsedGameTime.TotalSeconds);
            }

            if (kstate.IsKeyDown(Keys.Left) && GetAxis("x") > 0)
            {
                SetAxis("x", GetAxis("x") - GetSpeed() * (float)gameTime.ElapsedGameTime.TotalSeconds);
            }

            if (kstate.IsKeyDown(Keys.Right) && GetAxis("x") < graphics.PreferredBackBufferWidth)
            {
                SetAxis("x", GetAxis("x") + GetSpeed() * (float)gameTime.ElapsedGameTime.TotalSeconds);
            }
            
            playerRect.X = (int)GetPosition().X;
        }
    }
}
