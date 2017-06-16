using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork5;

namespace HomeWork7
{
    abstract class ShapesFactory
    {
        public abstract Shape CreateStar(int x, int y, ConsoleColor color);

        public abstract SizedShape CreateSizedShape(int x, int y, uint size, ConsoleColor color);

        public abstract MovableSizedShape CreateMovableShape(int x, int y, uint size, MoveDirection moveDirection,
            ConsoleColor color);
    }
}
