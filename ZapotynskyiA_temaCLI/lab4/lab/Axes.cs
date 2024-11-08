using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace lab4
{
    /// <summary>
    /// This class renders an XYZ coordinates system for the 3D scene. 
    /// </summary>
    public class Axes
    {
        private bool myVisibility;

        private const int AXIS_LENGTH = 75;

        /// <summary>
        /// This constructor initializes a new instance of the <see cref="Axes"/> class with default visibility set to true.
        /// </summary>
        public Axes()
        {
            myVisibility = true;
        }

        /// <summary>
        /// This methods handles the drawing of the object. Must be called - always - from OnRendeFrame() method! The drawing can be unconditional.
        /// </summary>
        public void Draw()
        {
            if (myVisibility)
            {
                GL.LineWidth(3.0f);

                GL.Begin(PrimitiveType.Lines);
                GL.Color3(Color.Red);
                GL.Vertex3(0, 0, 0);
                GL.Vertex3(AXIS_LENGTH, 0, 0);
                GL.Color3(Color.ForestGreen);
                GL.Vertex3(0, 0, 0);
                GL.Vertex3(0, AXIS_LENGTH, 0);
                GL.Color3(Color.RoyalBlue);
                GL.Vertex3(0, 0, 0);
                GL.Vertex3(0, 0, AXIS_LENGTH);
                GL.End();

                GL.LineWidth(1.0f);
            }
        }

        /// <summary>
        /// Sets visibility of the object ON.
        /// </summary>
        public void Show()
        {
            myVisibility = true;
        }

        /// <summary>
        /// Sets visibility of the object OFF.
        /// </summary>
        public void Hide()
        {
            myVisibility = false;
        }

        /// <summary>
        /// Toggles the visibility of the axes. If currently visible, they will be hidden, and vice versa.
        /// </summary>
        public void ToggleVisibility()
        {
            myVisibility = !myVisibility;
        }
    }
}
