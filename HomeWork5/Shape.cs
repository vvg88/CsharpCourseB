using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5
{
    abstract class Shape
    {
        public int X { get; set; }

        public int Y { get; set; }

        public ConsoleColor Color { get; set; }

        protected Shape(int x, int y, ConsoleColor color = ConsoleColor.White)
        {
            X = x;
            Y = y;
            Color = color;
        }

        public abstract void Draw(int ticks);
    }
}
