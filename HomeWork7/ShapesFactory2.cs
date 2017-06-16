using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork5;

namespace HomeWork7
{
    class ShapesFactory2 : ShapesFactory
    {
        public override Shape CreateStar(int x, int y, ConsoleColor color)
        {
            return new AnyStar(x, y, color);
        }

        public override SizedShape CreateSizedShape(int x, int y, uint size, ConsoleColor color)
        {
            return new Triangle(x, y, size, color);
        }

        public override MovableSizedShape CreateMovableShape(int x, int y, uint size, MoveDirection moveDirection, ConsoleColor color)
        {
            return new MovableTriangle(x, y, size, moveDirection, color);
        }
    }
}
