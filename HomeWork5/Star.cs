using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5
{
    class Star : Shape
    {
        public Star(int x, int y, ConsoleColor color = ConsoleColor.Blue)
            : base(x, y, color)
        {
        }

        public override void Draw(int ticks)
        {
            Engine2D.SetPixel(X - 1, Y, Color);
            Engine2D.SetPixel(X + 1, Y, Color);
            Engine2D.SetPixel(X, Y - 1, Color);
            Engine2D.SetPixel(X, Y + 1, Color);
            Engine2D.SetPixel(X, Y, Color);
        }
    }
}
