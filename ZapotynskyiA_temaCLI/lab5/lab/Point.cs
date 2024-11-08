using System;
using System.Collections.Generic;
using System.Drawing;
using OpenTK.Graphics;

namespace lab5
{
    internal class Point
    {
        public float X {  get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public Color4 Color { get; set; }

        public Point(float x, float y, float z, Color4 color = default)
        {
            if(color == default) Color = Color4.Green;
            X = x;
            Y = y;
            Z = z;
            Color = color;
        }
    }
}
