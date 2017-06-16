using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public abstract class MovableSizedShape : SizedShape, IMovableShape
    {
        public MoveDirection MoveDirection { get; protected set; }

        protected MovableSizedShape(int x, int y, uint size, MoveDirection moveDirection,
            ConsoleColor color = ConsoleColor.White)
            : base(x, y, size, color)
        {
            MoveDirection = moveDirection;
        }

        public void Move()
        {
            CheckWindowBorderCrossing();
            switch (MoveDirection)
            {
                case MoveDirection.ToRight:
                    X += 1;
                    break;
                case MoveDirection.ToTop:
                    Y -= 1;
                    break;
                case MoveDirection.ToLeft:
                    X -= 1;
                    break;
                case MoveDirection.ToBottom:
                    Y += 1;
                    break;
            }
        }

        protected abstract void CheckWindowBorderCrossing();
    }
}
