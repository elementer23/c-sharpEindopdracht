using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBindingOfZelda
{
    public class Projectile : Sprite
    {
        public Vector2 Direction { get; set; }
        public float Duration { get; set; }


        public Projectile(Texture2D texture, Vector2 position, int speed, Vector2 direction, float rotation, float duration) : base(texture, position) {
            this.Speed = speed;
            this.Rotation = rotation;
            Direction = new((float)Math.Cos(rotation), (float)Math.Sin(Rotation));
            Duration = duration;
        }

        public void Update() {
            Position += Direction * Speed * Utility.TotalGameTimeSeconds;
            Duration -= Utility.TotalGameTimeSeconds;
        }
    }
}
