using Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork8
{
    class StrategyMovableSquare : Square
    {
        protected MoveStrategy moveStrategy;

        public MoveDirection DirectionMove => moveStrategy.MoveDirect;

        public StrategyMovableSquare(int x, int y, uint size, MoveStrategy moveStrategy, ConsoleColor color = ConsoleColor.White) : base(x, y, size, color)
        {
            this.moveStrategy = moveStrategy;
        }

        public void SetStrategy(MoveStrategy moveStrtgy)
        {
            moveStrategy = moveStrtgy;
        }

        public virtual void Move()
        {
            moveStrategy.Move(this, false);
        }
    }
}
