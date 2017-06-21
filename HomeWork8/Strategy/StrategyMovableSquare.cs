using Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork8.Mediator;

namespace HomeWork8
{
    class StrategyMovableSquare : CollisionsAvoidSquare/*Square*/
    {
        protected MoveStrategy moveStrategy;

        public StrategyMovableSquare(int x, int y, uint size, CollisionsAvoidMediator mediator, MoveStrategy moveStrategy, ConsoleColor color = ConsoleColor.White)
            : base(x, y, size, mediator, color)
        {
            this.moveStrategy = moveStrategy;
        }

        public void SetStrategy(MoveStrategy moveStrtgy)
        {
            moveStrategy = moveStrtgy;
        }

        public virtual void Move()
        {
            switch (moveStrategy.MoveDirect)
            {
                case MoveDirection.ToLeft:
                    X--;
                    break;
                case MoveDirection.ToRight:
                    X++;
                    break;
                case MoveDirection.ToTop:
                    Y--;
                    break;
                case MoveDirection.ToBottom:
                    Y++;
                    break;
            }
            var isCollision = colAvoidMediator.Send(this);
            switch (moveStrategy.MoveDirect)
            {
                case MoveDirection.ToLeft:
                    X++;
                    break;
                case MoveDirection.ToRight:
                    X--;
                    break;
                case MoveDirection.ToTop:
                    Y++;
                    break;
                case MoveDirection.ToBottom:
                    Y--;
                    break;
            }
            moveStrategy.Move(this, isCollision);
        }
    }
}
