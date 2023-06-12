using bindingofzelda;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TheBindingOfZelda
{

    public abstract class Entity
    {
        Texture2D texture;
        Vector2 position;
        float speed;
        private Hitbox _hitbox;

        private GraphicsDeviceManager graphics;

        public Entity(GraphicsDeviceManager graphics)
        {
            this.graphics = graphics;
            position = new Vector2(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight / 2);
            speed = 100f;
            _hitbox = new Hitbox(graphics);
        }

        public void Update(GameTime gameTime)
        {

        }

        public void reset()
        {
            position = new Vector2(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight / 2);
            speed = 100f;
        }
        public Texture2D GetTexture()
        {
            return texture;
        }

        public void SetTexture(Texture2D value)
        {
            texture = value;
        }

        public float GetAxis(string axis)
        {
            if(axis == "x") return position.X;
            return position.Y;
        }

        public void SetAxis(string axis, float value)
        {
            if (axis == "x")
            {
                position.X = value;
            }

            if (axis == "y")
            {
                position.Y = value;
            }
        }

        public Vector2 GetPosition()
        { 
            return position;
        }

        public void SetPosition(Vector2 value) 
        { 
            position = value;
        }

        public float GetSpeed()
        {
            return speed;
        }

        public void SetSpeed(float value)
        {
            speed = value;
        }

        /*public void SetHitbox(int width, int height)
        {
            _hitbox.LoadHitbox(width, height);
        }*/

        public Hitbox GetHitbox()
        {
            return _hitbox;
        }
    }
}
