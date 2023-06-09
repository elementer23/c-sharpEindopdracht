using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace TheBindingOfZelda
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Ball _ball;
        private Ball _enemyBall;

        enum GameState
        {
            MainMenu,
            GamePlay,
            EndOfGame,
        }

        GameState _state;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _ball = new Ball(_graphics);
            _enemyBall = new Ball(_graphics);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            _ball.SetTexture(Content.Load<Texture2D>("ball"));
            _enemyBall.SetTexture(Content.Load<Texture2D>("ball"));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
            switch (_state)
            {
                case GameState.MainMenu:
                    UpdateMainMenu(gameTime);
                    break;
                case GameState.GamePlay:
                    UpdateGameplay(gameTime);
                    break;
                case GameState.EndOfGame:
                    UpdateEndOfGame(gameTime);
                    break;
            }
        }

        void UpdateMainMenu(GameTime gameTime)
        {
            KeyboardState kstate = Keyboard.GetState();
            if (kstate.IsKeyDown(Keys.R))
            {
                _state = GameState.GamePlay;
            }
        }

        void UpdateGameplay(GameTime gameTime)
        {
            KeyboardState kstate = Keyboard.GetState();
            MouseState mstate = Mouse.GetState();

            _ball.Update(gameTime);

            
            if (kstate.IsKeyDown(Keys.T))
            {
                ResetLevel();
                _state = GameState.EndOfGame;
            }
        }

        private void ResetLevel()
        {
            _ball.reset();
        }

        void UpdateEndOfGame(GameTime gameTime)
        {
            KeyboardState kstate = Keyboard.GetState();
            if (kstate.IsKeyDown(Keys.Y))
            {
                _state = GameState.MainMenu;
            }
            else if (kstate.IsKeyDown(Keys.U))
            {
                _state = GameState.GamePlay;
            }
        }

        void DrawMainMenu(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            base.Draw(gameTime);
        }

        void DrawGameplay(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(
                _ball.GetTexture(),
                _ball.GetPosition(),
                null,
                Color.White,
                0f,
                new Vector2(_ball.GetTexture().Width / 2, _ball.GetTexture().Height / 2),
                Vector2.One,
                SpriteEffects.None,
                0f
            );
            _spriteBatch.Draw(
                _enemyBall.GetTexture(),
                _enemyBall.GetPosition(),
                null,
                Color.White,
                0f,
                new Vector2(_enemyBall.GetTexture().Width / 2, _enemyBall.GetTexture().Height / 2),
                Vector2.One,
                SpriteEffects.None,
                0f);
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        void DrawEndOfGame(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Red);
            base.Draw(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            switch (_state)
            {
                case GameState.MainMenu:
                    DrawMainMenu(gameTime);
                    break;
                case GameState.GamePlay:
                    DrawGameplay(gameTime);
                    break;
                case GameState.EndOfGame:
                    DrawEndOfGame(gameTime);
                    break;
            }
        }
    }
}