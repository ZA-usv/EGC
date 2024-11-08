using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics;

namespace lab5
{
    internal class Randomizer
    {
        private Random r = new Random();
        public Color4 RandomColor()
        {
            int genR = r.Next(0, 255);
            int genG = r.Next(0, 255);
            int genB = r.Next(0, 255);

            Color4 col = Color.FromArgb(genR, genG, genB);
            return col;
        }
    }
}
