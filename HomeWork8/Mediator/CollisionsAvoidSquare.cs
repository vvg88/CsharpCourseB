using Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork8.Mediator
{
    class CollisionsAvoidSquare : StrategyMovableSquare
    {
        private CollisionsAvoidMediator colAvoidMediator;

        public CollisionsAvoidSquare(int x, int y, uint size, MoveStrategy moveStrategy,
            CollisionsAvoidMediator mediator,
            ConsoleColor color = ConsoleColor.White)
            : base(x, y, size, moveStrategy, color)
        {
            colAvoidMediator = mediator;
        }

        public CollisionsAvoidSquare()
            : base(0, 0, 0, new HorisontalMoveStrategy())
        { }

        public bool Notify(StrategyMovableSquare anotherSquare)
        {
            var tmpSquare = new Square(anotherSquare.X, anotherSquare.Y, anotherSquare.Size);
            switch (anotherSquare.DirectionMove)
            {
                case MoveDirection.ToLeft:
                    tmpSquare.X--;
                    return DefineCollision(tmpSquare)/*X + Size < anotherSquare.X - 1*/;
                case MoveDirection.ToRight:
                    tmpSquare.X++;
                    return DefineCollision(tmpSquare)/*anotherSquare.X + anotherSquare.Size + 1 < X*/;
                case MoveDirection.ToTop:
                    tmpSquare.Y--;
                    return DefineCollision(tmpSquare)/*anotherSquare.Y - anotherSquare.Size - 1 < Y*/;
                case MoveDirection.ToBottom:
                    tmpSquare.Y++;
                    return DefineCollision(tmpSquare)/*anotherSquare.Y + 1 < Y - Size*/;
            }
            return false;
        }

        public override void Move()
        {
            moveStrategy.Move(this, colAvoidMediator.Send(this));
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
