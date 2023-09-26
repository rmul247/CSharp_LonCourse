using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            int snakes = 16;
            Console.WriteLine((Reptile)snakes);
            Console.ReadKey();
        }
    }

    [Flags]
    enum Reptile
    {
        BlackMamba = 2,
        CottonMouth = 4,
        Wiper = 8,
        Crocodile = 16,
        Aligator = 32
    }
}
