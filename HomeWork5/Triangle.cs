using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5
{
    class Triangle : SizedShape
    {
        public Triangle(int x, int y, uint size, ConsoleColor color = ConsoleColor.White) : base(x, y, size, color)
        {
        }

        public override void Draw(int ticks)
        {
            var heigt = Size;
            var width = heigt + 1;
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
