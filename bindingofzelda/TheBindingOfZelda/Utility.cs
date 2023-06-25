using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBindingOfZelda
{
    public static class Utility
    {
        public static float TotalGameTimeSeconds;

        public static void Update(GameTime gameTime)
        {
            TotalGameTimeSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
