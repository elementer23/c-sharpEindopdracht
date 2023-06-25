﻿using Microsoft.Xna.Framework;
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
        Ball _enemyBall1;
        Ball _enemyBall2;

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
            _ball = new Ball(Content.Load<Texture2D>("ball"), new Vector2(100f, 100f), _graphics);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            //_ball.SetTexture(Content.Load<Texture2D>("ball"));
            _ball.GetHitbox().LoadHitbox(64, 64);
            Vector2 vector21 = new Vector2(32f, 32f);
            _enemyBall1 = new Ball(Content.Load<Texture2D>("ball"), vector21, _graphics);
            _enemyBall1.SetPosition(vector21);
            //_enemyBall1.SetTexture(Content.Load<Texture2D>("ball"));
            _enemyBall1.GetHitbox().LoadHitbox(64, 64);

            Vector2 vector22 = new Vector2(32f, 96f);
            _enemyBall2 = new Ball(Content.Load<Texture2D>("ball"), vector22, _graphics);
            _enemyBall2.SetPosition(vector22);
            //_enemyBall2.SetTexture(Content.Load<Texture2D>("ball"));
            _enemyBall2.GetHitbox().LoadHitbox(64, 64);
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
                    UpdateGameplay(gameTime, _graphics);
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

        void UpdateGameplay(GameTime gameTime, GraphicsDeviceManager graphics)
        {
            KeyboardState kstate = Keyboard.GetState();
            MouseState mstate = Mouse.GetState();

            _ball.Update(gameTime, graphics);

            
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
            _ball.GetHitbox().Draw(_spriteBatch, new Vector2(_ball.GetPosition().X - (_ball.GetTexture().Width / 2), _ball.GetPosition().Y - (_ball.GetTexture().Height / 2)));
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
            _enemyBall1.GetHitbox().Draw(_spriteBatch, new Vector2(_enemyBall1.GetPosition().X - (_enemyBall1.GetTexture().Width / 2), _enemyBall1.GetPosition().Y - (_enemyBall1.GetTexture().Height / 2)));
            _spriteBatch.Draw(
                _enemyBall1.GetTexture(),
                _enemyBall1.GetPosition(),
                null,
                Color.White,
                0f,
                new Vector2(_enemyBall1.GetTexture().Width / 2, _enemyBall1.GetTexture().Height / 2),
                Vector2.One,
                SpriteEffects.None,
                0f);
            _enemyBall2.GetHitbox().Draw(_spriteBatch, new Vector2(_enemyBall2.GetPosition().X - (_enemyBall2.GetTexture().Width / 2), _enemyBall2.GetPosition().Y - (_enemyBall2.GetTexture().Height / 2)));
            _spriteBatch.Draw(
                _enemyBall2.GetTexture(),
                _enemyBall2.GetPosition(),
                null,
                Color.White,
                0f,
                new Vector2(_enemyBall2.GetTexture().Width / 2, _enemyBall2.GetTexture().Height / 2),
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