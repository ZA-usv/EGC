using OpenTK;
using System;
using System.Drawing;

namespace lab4
{
    /// <summary>
    /// This class generates various random values for different kind of parameters (<see cref="Random()"/>)
    /// </summary>
    public class Randomizer
    {
        private Random r;
        private const int LOW_INT_VAL = -25;
        private const int HIGH_INT_VAL = 25;
        private const int LOW_COORD_VAL = -50;
        private const int HIGH_COORD_VAL = 50;

        /// <summary>
        /// Standard constructor. Initialised with the system clock for seed.
        /// </summary>
        public Randomizer()
        {
            r = new Random();
        }

        /// <summary>
        /// This method returns a random Color when requested.
        /// The RGB values are generated randomly within the range of 0 to 255.
        /// </summary>
        /// <returns>the Color, randomly generated!</returns>
        public Color RandomColor()
        {
            int genR = r.Next(0, 255);
            int genG = r.Next(0, 255);
            int genB = r.Next(0, 255);

            Color col = Color.FromArgb(genR, genG, genB);

            return col;
        }


        /// <summary>
        /// This method returns a random 3D coordinate.
        /// Values are ranged (0 - centered).
        /// </summary>
        /// <returns>the 3D point's coordinates, randomly generated!</returns>
        public Vector3 Random3DPoint()
        {
            int a = r.Next(LOW_COORD_VAL, HIGH_COORD_VAL);
            int b = r.Next(LOW_COORD_VAL, HIGH_COORD_VAL);
            int c = r.Next(LOW_COORD_VAL, HIGH_COORD_VAL);

            Vector3 vec = new Vector3(a, b, c);

            return vec;
        }

        /// <summary>
        /// This method returns a random int when required.
        /// The value is ranged between predefined values (symmetrical over zeo).
        /// </summary>
        /// <returns>random integer;</returns>
        public int RandomInt()
        {
            int a = r.Next(LOW_INT_VAL, HIGH_INT_VAL);

            return a;
        }

        /// <summary>
        /// This method returns a random int when required. The value is ranged between 0 and a given values.
        /// </summary>
        /// <param name="minval">minimum value for the randomized range;</param>
        /// <param name="maxval">maximum value for the randomized range;</param>
        /// <returns>random integer;</returns>
        public int RandomInt(int minval, int maxval)
        {
            int a = r.Next(minval, maxval);

            return a;
        }

        /// <summary>
        /// This method returns a random int when required. The value is ranged between 0 and a given value.
        /// </summary>
        /// <param name="maxval">upper value for integer generation;</param>
        /// <returns>random integer;</returns>
        public int RandomInt(int maxval)
        {
            int a = r.Next(maxval);

            return a;
        }
    }
}