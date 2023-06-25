using bindingofzelda;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TheBindingOfZelda
{

    public abstract class Entity
    {
        protected readonly Texture2D texture;
        public Vector2 Position;
        protected readonly Vector2 originalposition;
        public float speed { get; set; }
        public float Rotation { get; set; }
        private Hitbox _hitbox;

        private GraphicsDeviceManager graphics;

        public Entity(Texture2D texture, Vector2 position, GraphicsDeviceManager graphics)
        {
            this.texture = texture;
            this.graphics = graphics;
            Position = position;
            originalposition = new Vector2(texture.Width / 2, texture.Height / 2);  
            speed = 100f;
            _hitbox = new Hitbox(graphics);
        }

        public void Update(GameTime gameTime)
        {

        }

        public void reset()
        {
            Position = new Vector2(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight / 2);
            speed = 100f;
        }
        public Texture2D GetTexture()
        {
            return texture;
        }

        public float GetAxis(string axis)
        {
            if(axis == "x") return Position.X;
            return Position.Y;
        }

        public void SetAxis(string axis, float value)
        {
            if (axis == "x")
            {
                Position.X = value;
            }

            if (axis == "y")
            {
                Position.Y = value;
            }
        }

        public Vector2 GetPosition()
        { 
            return Position;
        }

        public void SetPosition(Vector2 value) 
        { 
            Position = value;
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

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, null, Color.White, Rotation, originalposition, 1, SpriteEffects.None, 1);
        }
    }
}
