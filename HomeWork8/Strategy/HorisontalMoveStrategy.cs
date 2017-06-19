using Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork8
{
    class HorisontalMoveStrategy : MoveStrategy
    {
        public HorisontalMoveStrategy()
        {
            MoveDirect = MoveDirection.ToRight;
        }

        public override void Move(SizedShape shape, bool changeDirection)
        {
            MoveDirect = changeDirection ? (MoveDirect == MoveDirection.ToRight ? MoveDirection.ToLeft : MoveDirection.ToRight)
                                         : MoveDirect;
            switch (MoveDirect)
            {
                case MoveDirection.ToRight:
                    if (shape.X + shape.Size + 1 > Console.WindowWidth - 1)
                    {
                        MoveDirect = MoveDirection.ToLeft;
                        shape.X--;
                    }
                    else
                    {
                        shape.X++;
                    }
                    break;
                case MoveDirection.ToLeft:
                    if (shape.X - 1 < 0)
                    {
                        MoveDirect = MoveDirection.ToRight;
                        shape.X++;
                    }
                    else
                    {
                        shape.X--;
                    }
                    break;
            }
        }
    }
}
