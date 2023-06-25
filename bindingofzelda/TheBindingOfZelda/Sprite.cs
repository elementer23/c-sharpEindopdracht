using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBindingOfZelda
{
    public class Sprite
    {
        protected Texture2D texture;
        protected Vector2 originalposition;
        public Vector2 Position { get; set; }
        public int Speed { get; set; }
        public float Rotation { get; set; }
        public Sprite(Texture2D texture, Vector2 position) {
            this.texture = texture;
            this.Position = position;
            Speed = 200;
            originalposition = new Vector2(texture.Width / 2, texture.Height / 2);
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, Position, null, Color.White, Rotation, originalposition, 1, SpriteEffects.None, 1);
        }
    }
}
