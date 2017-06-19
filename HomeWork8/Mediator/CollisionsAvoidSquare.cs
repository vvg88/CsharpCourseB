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

        public bool Notify(StrategyMovableSquare anotherSquare)
        {
            switch(anotherSquare.DirectionMove)
            {
                case MoveDirection.ToLeft:
                    return X + Size < anotherSquare.X - 1;
                case MoveDirection.ToRight:
                    return anotherSquare.X + anotherSquare.Size + 1 < X;
                case MoveDirection.ToTop:
                    return anotherSquare.Y - anotherSquare.Size - 1 < Y;
                case MoveDirection.ToBottom:
                    return anotherSquare.Y + 1 < Y - Size;
            }
            return false;
        }

        public override void Move()
        {
            moveStrategy.Move(this, colAvoidMediator.Send(this));
        }
    }
}
