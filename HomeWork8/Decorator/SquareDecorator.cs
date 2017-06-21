using HomeWork8.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork8.Decorator
{
    class SquareDecorator : CollisionsAvoidSquare
    {
        private readonly CollisionsAvoidSquare square;
        private static Random colorRandomiser = new Random();

        public SquareDecorator(CollisionsAvoidSquare sqr)
        {
            square = sqr;
            X = sqr.X;
            Y = sqr.Y;
            Size = sqr.Size;
        }

        public override void Draw(int ticks)
        {
            square.Color = (ConsoleColor)colorRandomiser.Next(0, 15);
            square.Draw(ticks);
        }
    }
}
