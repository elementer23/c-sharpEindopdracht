using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project.MonoGameControls;

namespace Project
{
    public class Game1 : MonoGameViewModel
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch = default!;

        private Texture2D _player = default!;
        private Vector2 _velocity;
        private float _speed = 5f;

        static public bool test = false;

        public Game1()
        {
            _graphics=new GraphicsDeviceManager(this);
            Content.RootDirectory="Content";
            IsMouseVisible=true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch=new SpriteBatch(GraphicsDevice);
            _player = Content.Load<Texture2D>("monogame-logo");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.W))
            {
                _velocity.Y -= _speed;
            }
            if (keyboardState.IsKeyDown(Keys.A))
            {
                _velocity.X -= _speed;
            }
            if (keyboardState.IsKeyDown(Keys.S))
            {
                _velocity.Y += _speed;
            }
            if (keyboardState.IsKeyDown(Keys.D))
            {
                _velocity.X += _speed;
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            _spriteBatch.Draw(_player, _velocity, Color.White);
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}