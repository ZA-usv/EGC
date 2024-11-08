using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace lab5
{
    internal class Window : GameWindow
    {
        private KeyboardState previousKeyboard;
        private MouseState previousMouse;
        private readonly Cube cube;

        public Window() : base(800, 600, new OpenTK.Graphics.GraphicsMode(32, 24, 0, 8), "Learn OpenGL")
        {
            // 32-bit color, 24-bit depth, 0-bit stencil, 8x multisampling
            base.VSync = VSyncMode.On;
            this.cube = new Cube();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(Color4.BlueViolet);
            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);
            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);
            GL.Enable(EnableCap.CullFace);

            this.Help();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, base.Width, base.Height);

            double aspect_ratio = base.Width / (double)base.Height;

            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)aspect_ratio, 1, 64);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);

            Matrix4 lookat = Matrix4.LookAt(30, 30, 30, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            KeyboardState keyboard = Keyboard.GetState();
            MouseState mouse = Mouse.GetState();

            if (keyboard[Key.Escape])
            {
                Exit();
            };

            if (keyboard[Key.H] && !previousKeyboard[Key.H])
            {
                this.Help();
            }

            if (keyboard[Key.R] && !previousKeyboard[Key.R])
            {
                cube.RegenerateVertexColors();
            }

            previousKeyboard = keyboard;
            previousMouse = mouse;
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            cube.Draw();

            base.SwapBuffers();
        }

        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
        }

        private void Help()
        {
            Console.WriteLine(
                "(H) - Help\n" +
                "(R) - Regenerate vertices colors"
            );
        }
        public void Run()
        {
            using (Window example = new Window())
            {
                example.Run(60.0, 0.0);
            }
        }
    }
}

