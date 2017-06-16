using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Triangle : SizedShape
    {
        private readonly uint width;
        private readonly uint heigt;

        public Triangle(int x, int y, uint size, ConsoleColor color = ConsoleColor.White) : base(x, y, size, color)
        {
            width = Size;
            heigt = width % 2 == 0 ? width / 2 : (width + 1) / 2;
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
