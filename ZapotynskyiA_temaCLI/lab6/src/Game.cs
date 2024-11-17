using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;

namespace lab6.src
{
    internal class Game : GameWindow
    {
        private KeyboardState previousKeyboard;
        private MouseState previousMouse;
        private Axe axe;
        private Cube cube;
        private double[] cubePositionOffset = { 0, 0, 0 };
        private double speed = 2;

        float rotationX = 0f;
        float rotationY = 0f;
        float sensitivity = 0.5f;

        public Game() : base(800, 600, new OpenTK.Graphics.GraphicsMode(32, 24, 0, 8), "Learn OpenGL")
        {
            // 32-bit color, 24-bit depth, 0-bit stencil, 8x multisampling
            base.VSync = VSyncMode.On;
            this.axe = new Axe();
            this.cube = new Cube();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(Color4.Black);
            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);
            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);
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

            double deltaTime = e.Time;
            KeyboardState keyboard = Keyboard.GetState();
            MouseState mouse = Mouse.GetState();


            if (mouse[MouseButton.Left])
            {
                rotationX += (previousMouse.X - mouse.X) * sensitivity;
                rotationY += (previousMouse.Y - mouse.Y) * sensitivity;
            }

            if (keyboard[Key.Escape])
            {
                Exit();
            };

            if (keyboard[Key.W]) {
                cubePositionOffset[2] += speed * deltaTime;
            }
            if (keyboard[Key.A])
            {
                cubePositionOffset[0] -= speed * deltaTime;
            }
            if (keyboard[Key.S])
            {
                cubePositionOffset[2] -= speed * deltaTime;
            }
            if (keyboard[Key.D])
            {
                cubePositionOffset[0] += speed * deltaTime;
            }
            if (keyboard[Key.R] && !previousKeyboard[Key.R])
            {
                cube.RegenerateVertexColors();
            }
            if (keyboard[Key.V] && !previousKeyboard[Key.V])
            {
                cube.toggleVisibility();
            }
            if (keyboard[Key.H] && !previousKeyboard[Key.H])
            {
                Console.WriteLine( ""
                    + "WASD - Move"
                    + "R - Regenerate cube color"
                    + "V - show/hide cube"
                    + "H - Help"
                    + "In order to rotate cube move the mouse"
                );
            }

            this.previousKeyboard = keyboard;
            this.previousMouse = mouse;
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            axe.Draw();

            GL.PushMatrix();
            GL.Translate(cubePositionOffset[0], cubePositionOffset[1], cubePositionOffset[2]);

            GL.Rotate(rotationX, 1, 0, 0);
            GL.Rotate(rotationY, 0, 1, 0);

            cube.Draw();

            GL.PopMatrix();

            base.SwapBuffers();
        }

        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
        }

        public void Run()
        {
            using (Game example = new Game())
            {
                example.Run(60.0, 0.0);
            }
        }
    }
}
