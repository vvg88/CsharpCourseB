using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class AnyStar : Shape
    {
        public AnyStar(int x, int y, ConsoleColor color = ConsoleColor.White)
            : base(x, y, color)
        {
        }

        public override void Draw(int ticks)
        {
            if (++X > Console.WindowWidth - 2)
            {
                X = 10;
            }


            if (ticks % 2 == 0)
            {
                Engine2D.SetPixel(X - 1, Y - 1, Color);
                Engine2D.SetPixel(X + 1, Y - 1, Color);
                Engine2D.SetPixel(X - 1, Y + 1, Color);
                Engine2D.SetPixel(X + 1, Y + 1, Color);
                Engine2D.SetPixel(X, Y, Color);
            }
            else
            {
                Engine2D.SetPixel(X - 1, Y, Color);
                Engine2D.SetPixel(X + 1, Y, Color);
                Engine2D.SetPixel(X, Y - 1, Color);
                Engine2D.SetPixel(X, Y + 1, Color);
                Engine2D.SetPixel(X, Y, Color);
            }
        }
    }
}
