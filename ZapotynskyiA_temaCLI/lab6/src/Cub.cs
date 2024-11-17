using OpenTK.Graphics.OpenGL;
using OpenTK;
using System.IO;
using System;
using System.Collections.Generic;
using OpenTK.Graphics;
using lab6;
using System.Drawing;

namespace lab6
{
    internal class Cube
    {
        private bool hide = false;
        private readonly Randomizer r = new Randomizer();
        private List<Point> vertices = new List<Point>();

        private int[] indices =
        {
        0, 1, 2, 0, 2, 3, // Front face
        4, 5, 6, 4, 6, 7, // Back face
        8, 9, 10, 8, 10, 11, // Left face
        12, 13, 14, 12, 14, 15, // Right face
        16, 17, 18, 16, 18, 19, // Top face
        20, 21, 22, 20, 22, 23, // Bottom face
    };

        public Cube()
        {
            string line;
            string[] vertex;
            try
            {
                StreamReader sr = new StreamReader(@"cubeCoordinates.txt");
                line = sr.ReadLine();
                while (line != null)
                {
                    vertex = line.Split(' ');

                    this.vertices.Add(new Point(float.Parse(vertex[0]), float.Parse(vertex[1]), float.Parse(vertex[2]), r.RandomColor()));
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error when reading cube coordinates: " + e.Message);
                this.vertices = this.getVertices();
            }
        }

        public void Draw()
        {
            if (hide) return;

            GL.Begin(PrimitiveType.Triangles);
            for (int i = 0; i < indices.Length; i++)
            {
                int index = indices[i];

                GL.Color4(vertices[index].Color);
                GL.Vertex3(vertices[index].X, vertices[index].Y, vertices[index].Z);
            }
            GL.End();
        }
        public void RegenerateVertexColors()
        {
            for (int i = 0; i < vertices.Count; i++)
            {
                vertices[i].Color = r.RandomColor();
            }
        }

        public bool toggleVisibility()
        {
            hide = !hide;
            return hide;
        }

        private List<Point> getVertices()
        {
            List<Point> v = new List<Point>
    {
        // Front face
        new Point(-1f, -1f,  1f, r.RandomColor()),
        new Point( 1f, -1f,  1f, r.RandomColor()),
        new Point( 1f,  1f,  1f, r.RandomColor()),
        new Point(-1f,  1f,  1f, r.RandomColor()),

        // Back face
        new Point(-1f, -1f, -1f, r.RandomColor()),
        new Point(-1f,  1f, -1f, r.RandomColor()),
        new Point( 1f,  1f, -1f, r.RandomColor()),
        new Point( 1f, -1f, -1f, r.RandomColor()),

        // Left face
        new Point(-1f, -1f, -1f, r.RandomColor()),
        new Point(-1f, -1f,  1f, r.RandomColor()),
        new Point(-1f,  1f,  1f, r.RandomColor()),
        new Point(-1f,  1f, -1f, r.RandomColor()),

        // Right face
        new Point( 1f, -1f, -1f, r.RandomColor()),
        new Point( 1f,  1f, -1f, r.RandomColor()),
        new Point( 1f,  1f,  1f, r.RandomColor()),
        new Point( 1f, -1f,  1f, r.RandomColor()),

        // Top face
        new Point(-1f,  1f, -1f, r.RandomColor()),
        new Point(-1f,  1f,  1f, r.RandomColor()),
        new Point( 1f,  1f,  1f, r.RandomColor()),
        new Point( 1f,  1f, -1f, r.RandomColor()),

        // Bottom face
        new Point(-1f, -1f, -1f, r.RandomColor()),
        new Point( 1f, -1f, -1f, r.RandomColor()),
        new Point( 1f, -1f,  1f, r.RandomColor()),
        new Point(-1f, -1f,  1f, r.RandomColor())
    };

            return v;
        }
    }
}