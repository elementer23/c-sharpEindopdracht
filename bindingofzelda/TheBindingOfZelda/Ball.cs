using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace TheBindingOfZelda
{
    public class Ball : Entity
    {
        public Ball(GraphicsDeviceManager graphics) : base(graphics)
        {
            SetSpeed(120f);
        }

        public void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            KeyboardState kstate = Keyboard.GetState();
            if (kstate.IsKeyDown(Keys.Up))
            {
                SetAxis("y", GetAxis("y") - GetSpeed() * (float)gameTime.ElapsedGameTime.TotalSeconds);
            }

            if (kstate.IsKeyDown(Keys.Down))
            {
                SetAxis("y", GetAxis("y") + GetSpeed() * (float)gameTime.ElapsedGameTime.TotalSeconds);
            }

            if (kstate.IsKeyDown(Keys.Left))
            {
                SetAxis("x", GetAxis("x") - GetSpeed() * (float)gameTime.ElapsedGameTime.TotalSeconds);
            }

            if (kstate.IsKeyDown(Keys.Right))
            {
                SetAxis("x", GetAxis("x") + GetSpeed() * (float)gameTime.ElapsedGameTime.TotalSeconds);
            }
        }
    }
}
