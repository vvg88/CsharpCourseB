using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5
{
    class Program
    {
        static void Main(string[] args)
        {
            Engine2D.Draw(
                new Shape[]
                {
                    new Star(5, 5),
                    new AnyStar(20, 8, ConsoleColor.Yellow),
                    new Star(10, 15, ConsoleColor.Red),
                    new Square(5, 18, 3, ConsoleColor.Cyan),
                    new Triangle(15, 18, 6), 
                });

            Console.Read();
        }
    }
}
