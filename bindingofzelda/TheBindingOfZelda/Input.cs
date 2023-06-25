using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBindingOfZelda
{
    public static class Input
    {
        public static MouseState lastMouseState;
        public static Vector2 Direction;
        public static Vector2 MousePosition => Mouse.GetState().Position.ToVector2();
        public static bool MouseClicked { get; set; }

        public static void Update()
        {
            KeyboardState keyboardState = Keyboard.GetState();

            Direction = Vector2.Zero;
            if (keyboardState.IsKeyDown(Keys.W)) Direction.Y--;
            if (keyboardState.IsKeyDown(Keys.S)) Direction.Y++;
            if (keyboardState.IsKeyDown(Keys.A)) Direction.X--;
            if (keyboardState.IsKeyDown(Keys.D)) Direction.X++;

            MouseClicked = (Mouse.GetState().LeftButton == ButtonState.Pressed) 
                && (lastMouseState.LeftButton  == ButtonState.Released);
            lastMouseState = Mouse.GetState();
        }
    }
}
