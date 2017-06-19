using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shapes;

namespace HomeWork8
{
    class VerticalMoveStrategy : MoveStrategy
    {
        public VerticalMoveStrategy()
        {
            MoveDirect = MoveDirection.ToTop;
        }

        public override void Move(SizedShape shape, bool changeDirection)
        {
            MoveDirect = changeDirection ? (MoveDirect == MoveDirection.ToTop ? MoveDirection.ToBottom : MoveDirection.ToTop)
                                         : MoveDirect;
            switch (MoveDirect)
            {
                case MoveDirection.ToTop:
                    if (shape.Y - shape.Size < 0)
                    {
                        MoveDirect = MoveDirection.ToBottom;
                        shape.Y++;
                    }
                    else
                    {
                        shape.Y--;
                    }
                    break;
                case MoveDirection.ToBottom:
                    if (shape.Y + 1 > Console.WindowHeight - 1)
                    {
                        MoveDirect = MoveDirection.ToTop;
                        shape.Y--;
                    }
                    else
                    {
                        shape.Y++;
                    }
                    break;
            }
        }
    }
}
