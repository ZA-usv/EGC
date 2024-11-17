using System;
using OpenTK.Graphics.OpenGL;
using OpenTK;
using System.Drawing;

namespace lab6
{
    internal class Axe
    {
        private int size = 75;
        private Color OxColor = Color.Green;
        private Color OyColor = Color.Red;
        private Color OzColor = Color.Purple;
        public Axe()
        {

        }

        public void Draw()
        {
            GL.LineWidth(2);
            GL.Begin(PrimitiveType.Lines);
            GL.Color4(OxColor);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(size, 0, 0);
            GL.Color4(OyColor);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, size, 0);
            GL.Color4(OzColor);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 0, size);
            GL.End();
            GL.LineWidth(1);
        }
    }
}
