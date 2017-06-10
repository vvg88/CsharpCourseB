using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5
{
    class MovableSquare : MovableSizedShape
    {
        public MovableSquare(int x, int y, uint size, MoveDirection moveDirection, ConsoleColor color = ConsoleColor.White)
            : base(x, y, size, moveDirection, color)
        { }

        protected override void CheckWindowBorderCrossing()
        {
            switch (MoveDirection)
            {
                case MoveDirection.ToRight:
                    if (X + Size + 1 > Console.WindowWidth - 1)
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

        public override void Draw(int ticks)
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Engine2D.SetPixel(X + i, Y - j, Color);
                }
            }
        }
    }
}
