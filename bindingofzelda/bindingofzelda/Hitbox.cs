using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bindingofzelda
{
    internal class Hitbox
    {
        private GraphicsDeviceManager _deviceManager;
        private Texture2D _hitbox;
        private Color[] _colors;

        public Hitbox(GraphicsDeviceManager graphicsDeviceManager)
        {
            _deviceManager = graphicsDeviceManager;
        }

        public void LoadHitbox(int width, int height)
        {
            _hitbox = new Texture2D(_deviceManager.GraphicsDevice, width, height);
            _colors = new Color[width * height];
            for (int i = 0; i < _colors.Length; i++)
            {
                _colors[i] = Color.White;
            }
            _hitbox.SetData(_colors);
        }

        public void Dispose()
        {
            _hitbox.Dispose();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            spriteBatch.Draw(_hitbox, position, Color.White);
        }
    }
}
