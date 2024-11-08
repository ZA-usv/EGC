using OpenTK.Graphics.OpenGL;
using System.Drawing;


namespace lab4
{
    /// <summary>
    /// Represents a 3D grid for use in an OpenGL context, allowing visualization of a grid on the XZ plane.
    /// Includes options to toggle grid visibility and set grid color.
    /// </summary>
    public class Grid
    {
        private readonly Color colorisation;
        private bool visibility;

        //CONST
        private readonly Color GRIDCOLOR = Color.WhiteSmoke;
        private const int GRIDSTEP = 10;
        private const int UNITS = 50;
        private const int POINT_OFFSET = GRIDSTEP * UNITS;

        /// <summary>
        /// Offset applied to prevent grid lines from overlapping with the axes,
        /// reducing visual interference when axes are displayed with thicker lines.
        /// </summary>
        private const int MICRO_OFFSET = 0;

        /// <summary>
        /// This constructor initializes a new instance of the <see cref="Grid"/> class with a default color and visibility.
        /// </summary>
        public Grid()
        {
            colorisation = GRIDCOLOR;
            visibility = true;
        }

        /// <summary>
        /// Sets visibility of the object ON.
        /// </summary>
        public void Show()
        {
            visibility = true;
        }

        /// <summary>
        /// Sets visibility of the object OFF.
        /// </summary>
        public void Hide()
        {
            visibility = false;
        }

        /// <summary>
        /// Toggles the grid's visibility. If currently visible, it will be hidden, and vice versa.
        /// </summary>
        public void ToggleVisibility()
        {
            visibility = !visibility;
        }

        /// <summary>
        /// Draws the grid on the XZ plane if visibility is enabled, rendering lines in the specified color.
        /// </summary>
        public void Draw()
        {
            if (visibility)
            {
                GL.Begin(PrimitiveType.Lines);
                GL.Color3(colorisation);
                for (int i = -1 * GRIDSTEP * UNITS; i <= GRIDSTEP * UNITS; i += GRIDSTEP)
                {
                    // XZ plan drawing: parallel with Oz
                    GL.Vertex3(i + MICRO_OFFSET, 0, POINT_OFFSET);
                    GL.Vertex3(i + MICRO_OFFSET, 0, -1 * POINT_OFFSET);

                    // XZ plan drawing: parallel with Ox
                    GL.Vertex3(POINT_OFFSET, 0, i + MICRO_OFFSET);
                    GL.Vertex3(-1 * POINT_OFFSET, 0, i + MICRO_OFFSET);

                }

                GL.End();
            }
        }
    }
}
