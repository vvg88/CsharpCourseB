using Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork8.Mediator
{
    class CollisionsAvoidSquare : Square
    {
        protected readonly CollisionsAvoidMediator colAvoidMediator;

        public CollisionsAvoidSquare(int x, int y, uint size,
            CollisionsAvoidMediator mediator,
            ConsoleColor color = ConsoleColor.White)
            : base(x, y, size, color)
        {
            colAvoidMediator = mediator;
        }

        public CollisionsAvoidSquare()
            : base(0, 0, 0)
        { }

        public bool Notify(Square anotherSquare)
        {
            return DefineCollision(anotherSquare);
        }

        private bool DefineCollision(Square square)
        {
            var sqrPoints = new List<Tuple<int, int>>();
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    sqrPoints.Add(new Tuple<int, int>(X + i, Y - j));

            var anotherSqrPoints = new List<Tuple<int, int>>();
            for (int i = 0; i < square.Size; i++)
                for (int j = 0; j < square.Size; j++)
                    anotherSqrPoints.Add(new Tuple<int, int>(square.X + i, square.Y - j));

            foreach(var anSqrPoint in anotherSqrPoints)
            {
                if (sqrPoints.Any(point => point.Item1 == anSqrPoint.Item1 && point.Item2 == anSqrPoint.Item2))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
