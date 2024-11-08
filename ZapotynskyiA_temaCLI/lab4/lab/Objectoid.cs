using System;
using System.Collections.Generic;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace lab4
{
    /// <summary>
    /// Represents a 3D object that, when placed in a 3D environment, falls downwards
    /// under the effect of "gravity" until it reaches the "ground" (grid).
    /// </summary>
    public class Objectoid
    {
        private bool visibility;
        private bool isGravityBound;
        private Color color;
        private List<Vector3> coordList;
        private Randomizer rando;

        private const int GRAVITY_OFFSET = 1;

        /// <summary>
        /// This constructor initializes a new instance of the <see cref="Objectoid"/> class with specified gravity status.
        /// Generates randomized properties for color, size, and initial position offsets.
        /// </summary>
        /// <param name="gravity_status">If true, the object will be affected by gravity.</param>
        public Objectoid(bool gravity_status)
        {
            rando = new Randomizer();

            visibility = true;
            isGravityBound = gravity_status;
            color = rando.RandomColor();

            coordList = new List<Vector3>();
            int size_offset = rando.RandomInt(3, 7);            // permite crearea de obiecte cu un mic offset de dimensiune (variabile ca dimensiune);
            int height_offset = rando.RandomInt(40, 60);        // permite crearea de obiecte plasate la un mic offset de inaltime (diverse inaltimi);
            int radial_offset = rando.RandomInt(5, 15);         // permite crearea de obiecte cu un mic offset pe directia OX - OZ pozitive;

            coordList.Add(new Vector3(0 * size_offset + radial_offset, 0 * size_offset + height_offset, 1 * size_offset + radial_offset));
            coordList.Add(new Vector3(0 * size_offset + radial_offset, 0 * size_offset + height_offset, 0 * size_offset + radial_offset));
            coordList.Add(new Vector3(1 * size_offset + radial_offset, 0 * size_offset + height_offset, 1 * size_offset + radial_offset));
            coordList.Add(new Vector3(1 * size_offset + radial_offset, 0 * size_offset + height_offset, 0 * size_offset + radial_offset));
            coordList.Add(new Vector3(1 * size_offset + radial_offset, 1 * size_offset + height_offset, 1 * size_offset + radial_offset));
            coordList.Add(new Vector3(1 * size_offset + radial_offset, 1 * size_offset + height_offset, 0 * size_offset + radial_offset));
            coordList.Add(new Vector3(0 * size_offset + radial_offset, 1 * size_offset + height_offset, 1 * size_offset + radial_offset));
            coordList.Add(new Vector3(0 * size_offset + radial_offset, 1 * size_offset + height_offset, 0 * size_offset + radial_offset));
            coordList.Add(new Vector3(0 * size_offset + radial_offset, 0 * size_offset + height_offset, 1 * size_offset + radial_offset));
            coordList.Add(new Vector3(0 * size_offset + radial_offset, 0 * size_offset + height_offset, 0 * size_offset + radial_offset));
        }

        /// <summary>
        /// Draws the object in the 3D scene if visibility is enabled.
        /// The object is drawn with the specified color and uses <c>PrimitiveType.QuadStrip</c> for rendering.
        /// </summary>
        public void Draw()
        {
            if (visibility)
            {
                GL.Color3(color);
                GL.Begin(PrimitiveType.QuadStrip);
                foreach (Vector3 v in coordList)
                    GL.Vertex3(v);

                GL.End();
            }
        }

        /// <summary>
        /// Updates the object's position by applying gravity if both visibility and gravity are enabled,
        /// and if the object has not yet collided with the ground.
        /// </summary>
        /// <param name="gravity_status">The current gravity status; if true, gravity is applied.</param>
        public void UpdatePosition(bool gravity_status)
        {
            if (visibility && gravity_status && !GroundCollisionDetected())
            {
                for (int i = 0; i < coordList.Count; i++)
                {
                    coordList[i] = new Vector3(coordList[i].X, coordList[i].Y - GRAVITY_OFFSET, coordList[i].Z);
                }
            }
        }

        /// <summary>
        /// Checks for a collision with the ground by examining if any vertex has a Y-coordinate of zero or below.
        /// </summary>
        /// <returns>True if a ground collision is detected; otherwise, false.</returns>
        public bool GroundCollisionDetected()
        {
            foreach (Vector3 v in coordList)
                if (v.Y <= 0)
                    return true;
            return false;
        }

        /// <summary>
        /// Toggles the object's visibility state, either showing or hiding it.
        /// </summary>
        public void ToggleVisibility()
        {
            visibility = !visibility;
        }
    }
}
