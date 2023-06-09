using Microsoft.Xna.Framework;

namespace TheBindingOfZelda
{
    public class Enemy : Entity
    {
        public Enemy(GraphicsDeviceManager graphics) : base(graphics)
        {
            Vector2 vector2 = new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            SetPosition(vector2);
        }
    }
}
