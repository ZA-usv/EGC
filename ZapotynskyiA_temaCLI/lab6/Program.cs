using lab6.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    internal class Program
    {
        static void Main(string[] args)
        {        
            using(Game game = new Game())
            {
                game.Run();
            }
        }
    }
}
