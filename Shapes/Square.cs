using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Square : SizedShape
    {
        public Square(int x, int y, uint size, ConsoleColor color = ConsoleColor.White) : base(x, y, size, color)
        {
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
