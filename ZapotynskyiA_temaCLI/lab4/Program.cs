using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab4;

namespace lab4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (Window3D window = new Window3D())
            {
                window.Run(30.0, 0.0);
            }
        }
    }
}

//Axes.cs, Camera3DIsometric.cs, Grid.cs, Objectoid.cs, Randomizer.cs, Window3D.cs, Program.cs