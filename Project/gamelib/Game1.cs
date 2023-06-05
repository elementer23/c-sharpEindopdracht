﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace gamelib
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        enum GameState
        {
            MainMenu,
            GamePlay,
            Credits,
        }

        private GameState _state;

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

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back==ButtonState.Pressed||Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //void update(gametime deltatime)
            //{
            //    base.update(deltatime);
            //    switch (_state)
            //    {
            //        case gamestate.mainmenu:
            //            updatemainmenu(deltatime);
            //            break;
            //        case gamestate.gameplay:
            //            updategameplay(deltatime);
            //            break;
            //        case gamestate.endofgame:
            //            updateendofgame(deltatime);
            //            break;
            //    }
            //}
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}