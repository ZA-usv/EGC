using OpenTK.Graphics.OpenGL;
using System;
using System.Drawing;

namespace lab6
{
    internal class Randomizer
    {
        private Random r;

        public Randomizer()
        {
            r = new Random();
        }

        public Color RandomColor()
        {
            int r = this.r.Next(0, 255);
            int g = this.r.Next(0, 255);
            int b = this.r.Next(0, 255);

            return Color.FromArgb(r, g, b);
        }
    }
}
