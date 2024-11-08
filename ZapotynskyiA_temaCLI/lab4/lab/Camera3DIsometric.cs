using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace lab4
{
    /// <summary>
    /// Represents a 3D isometric camera with basic movement controls in an OpenGL context.
    /// </summary>
    public class Camera3DIsometric
    {
        private Vector3 eye;
        private Vector3 target;
        private Vector3 up_vector;

        private const int MOVEMENT_UNIT = 1;

        /// <summary>
        /// This constructor initializes a new instance of the <see cref="Camera3DIsometric"/> class
        /// with default values for an isometric view.
        /// </summary>

        public Camera3DIsometric()
        {
            eye = new Vector3(60, 60, 60);
            target = new Vector3(0, 0, 0);
            up_vector = new Vector3(0, 1, 0);
        }

        /// <summary>
        /// This constructor initializes a new instance of the <see cref="Camera3DIsometric"/> class
        /// with specified position, target, and up vectors using integer coordinates.
        /// </summary>
        /// <param name="_eyeX">X-coordinate of the eye position.</param>
        /// <param name="_eyeY">Y-coordinate of the eye position.</param>
        /// <param name="_eyeZ">Z-coordinate of the eye position.</param>
        /// <param name="_targetX">X-coordinate of the target position.</param>
        /// <param name="_targetY">Y-coordinate of the target position.</param>
        /// <param name="_targetZ">Z-coordinate of the target position.</param>
        /// <param name="_upX">X-component of the up vector.</param>
        /// <param name="_upY">Y-component of the up vector.</param>
        /// <param name="_upZ">Z-component of the up vector.</param>
        public Camera3DIsometric(int _eyeX, int _eyeY, int _eyeZ, int _targetX, int _targetY, int _targetZ, int _upX, int _upY, int _upZ)
        {
            eye = new Vector3(_eyeX, _eyeY, _eyeZ);
            target = new Vector3(_targetX, _targetY, _targetZ);
            up_vector = new Vector3(_upX, _upY, _upZ);
        }

        /// <summary>
        /// This constructor initializes a new instance of the <see cref="Camera3DIsometric"/> class
        /// with specified hladiuc position, target, and up vectors using <see cref="Vector3"/> values.
        /// </summary>
        /// <param name="_eye">Vector representing the eye position.</param>
        /// <param name="_target">Vector representing the target position.</param>
        /// <param name="_up">Vector representing the up direction.</param>
        public Camera3DIsometric(Vector3 _eye, Vector3 _target, Vector3 _up)
        {
            eye = _eye;
            target = _target;
            up_vector = _up;
        }

        /// <summary>
        /// Sets the camera's view matrix using OpenGL's LookAt function to define
        /// the view transformation based on the eye, target, and up vectors.
        /// </summary>
        public void SetCamera()
        {
            Matrix4 camera = Matrix4.LookAt(eye, target, up_vector);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref camera);
        }

        /// <summary>
        /// Moves the camera and target positions to the right by decreasing the Z-coordinate.
        /// </summary>
        public void MoveRight()
        {
            eye = new Vector3(eye.X, eye.Y, eye.Z - MOVEMENT_UNIT);
            target = new Vector3(target.X, target.Y, target.Z - MOVEMENT_UNIT);
            SetCamera();
        }

        /// <summary>
        /// Moves the camera and target positions to the left by increasing the Z-coordinate.
        /// </summary>
        public void MoveLeft()
        {
            eye = new Vector3(eye.X, eye.Y, eye.Z + MOVEMENT_UNIT);
            target = new Vector3(target.X, target.Y, target.Z + MOVEMENT_UNIT);
            SetCamera();
        }

        /// <summary>
        /// Moves the camera and target positions forward by decreasing the X-coordinate.
        /// </summary>
        public void MoveForward()
        {
            eye = new Vector3(eye.X - MOVEMENT_UNIT, eye.Y, eye.Z);
            target = new Vector3(target.X - MOVEMENT_UNIT, target.Y, target.Z);
            SetCamera();
        }

        /// <summary>
        /// Moves the camera and target positions backward by increasing the X-coordinate.
        /// </summary>
        public void MoveBackward()
        {
            eye = new Vector3(eye.X + MOVEMENT_UNIT, eye.Y, eye.Z);
            target = new Vector3(target.X + MOVEMENT_UNIT, target.Y, target.Z);
            SetCamera();
        }

        /// <summary>
        /// Moves the camera and target positions upward by increasing the Y-coordinate.
        /// </summary>
        public void MoveUp()
        {
            eye = new Vector3(eye.X, eye.Y + MOVEMENT_UNIT, eye.Z);
            target = new Vector3(target.X, target.Y + MOVEMENT_UNIT, target.Z);
            SetCamera();
        }

        /// <summary>
        /// Moves the camera and target positions downward by decreasing the Y-coordinate.
        /// </summary>
        public void MoveDown()
        {
            eye = new Vector3(eye.X, eye.Y - MOVEMENT_UNIT, eye.Z);
            target = new Vector3(target.X, target.Y - MOVEMENT_UNIT, target.Z);
            SetCamera();
        }
    }
}
