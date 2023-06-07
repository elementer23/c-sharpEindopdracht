using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace TheBindingOfZelda
{
    public class Game1 : Game
    {
        Texture2D ballTexture;
        Vector2 ballPosition;
        float ballSpeed;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

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
            ballPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
            ballSpeed = 100f;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            ballTexture = Content.Load<Texture2D>("ball");
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
            // Respond to user input for menu selections, etc
            if (kstate.IsKeyDown(Keys.R))
            {
                _state = GameState.GamePlay;
            }
        }

        void UpdateGameplay(GameTime gameTime)
        {
            KeyboardState kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.Up))
            {
                ballPosition.Y -= ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.Down))
            {
                ballPosition.Y += ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.Left))
            {
                ballPosition.X -= ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.Right))
            {
                ballPosition.X += ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (kstate.IsKeyDown(Keys.T))
            {
                _state = GameState.EndOfGame;
            }
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

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(
                ballTexture,
                ballPosition,
                null,
                Color.White,
                0f,
                new Vector2(ballTexture.Width / 2, ballTexture.Height / 2),
                Vector2.One,
                SpriteEffects.None,
                0f
            );
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