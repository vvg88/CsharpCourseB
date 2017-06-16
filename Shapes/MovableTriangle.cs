using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class MovableTriangle : MovableSizedShape
    {
        private readonly uint width;
        private readonly uint heigt;

        public MovableTriangle(int x, int y, uint size, MoveDirection moveDirection,
            ConsoleColor color = ConsoleColor.White)
            : base(x, y, size, moveDirection, color)
        {
            width = Size;
            heigt = width % 2 == 0 ? width / 2 : (width + 1) / 2;
        }

        protected override void CheckWindowBorderCrossing()
        {
            switch (MoveDirection)
            {
                case MoveDirection.ToRight:
                    if (X + Size + 1 > Console.WindowWidth - 1)
                        MoveDirection = MoveDirection.ToLeft;
                    break;
                case MoveDirection.ToTop:
                    if (Y - heigt < 0)
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
            for (int i = 0; i < heigt; i++)
            {
                for (int j = 0 + i; j < width - i; j++)
                {
                    Engine2D.SetPixel(X + j, Y - i, Color);
                }
            }
        }
    }
}
