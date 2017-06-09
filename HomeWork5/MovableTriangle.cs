using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5
{
    class MovableTriangle : Triangle, IMovableShape
    {
        public MoveDirection MoveDirection { get; private set; }

        public MovableTriangle(int x, int y, uint size, MoveDirection moveDirection, ConsoleColor color = ConsoleColor.White) : base(x, y, size, color)
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

        private void CheckWindowBorderCrossing()
        {
            switch (MoveDirection)
            {
                case MoveDirection.ToRight:
                    if (X + 1 + Size > Console.WindowWidth - 1)
                        MoveDirection = MoveDirection.ToLeft;
                    break;
                case MoveDirection.ToTop:
                    if (Y - Size < 0)
                        MoveDirection = MoveDirection.ToBottom;
                    break;
                case MoveDirection.ToLeft:
                    if (X - 1 < 0)
                        MoveDirection = MoveDirection.ToRight;
                    break;
                case MoveDirection.ToBottom:
                    if (Y + 1 > Console.WindowHeight - 1)
                        MoveDirection = MoveDirection.ToTop;
                    break;
            }
        }
    }
}
