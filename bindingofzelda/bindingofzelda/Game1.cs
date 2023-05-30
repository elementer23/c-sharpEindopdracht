using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace bindingofzelda
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _player;
        private Vector2 _velocity;
        private float _speed = 5f;
        private Hitbox _hitbox;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _hitbox = new Hitbox(_graphics);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _player = Content.Load<Texture2D>("player/red");
            _hitbox.LoadHitbox(88, 50);
            // TODO: use this.Content to load your game content here
        }

        protected override void UnloadContent()
        {
            _hitbox.Dispose();
            base.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
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
            _hitbox.Draw(_spriteBatch, _velocity);
            _spriteBatch.Draw(_player, _velocity, Color.White);
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}