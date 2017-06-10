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
                    new Star(2, 2),
                    new AnyStar(2, 5, ConsoleColor.Yellow),
                    new Star(Console.WindowWidth - 3, 2, ConsoleColor.Red),
                    new MovableSquare(30, 2, 3, MoveDirection.ToBottom), 
                    new MovableTriangle(50, Console.WindowHeight - 1, 5, MoveDirection.ToTop, ConsoleColor.Green),
                    new MovableSquare(2, 10, 2, MoveDirection.ToRight, ConsoleColor.Red),
                    new MovableTriangle(Console.WindowWidth - 3, 20, 3, MoveDirection.ToLeft, ConsoleColor.Gray),
                    new Square(2, Console.WindowHeight - 1, 4, ConsoleColor.Cyan),
                    new Triangle(8, Console.WindowHeight - 1, 7, ConsoleColor.Magenta), 
                    
                });

            Console.Read();
        }
    }
}
