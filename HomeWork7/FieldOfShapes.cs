using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork5;

namespace HomeWork7
{
    class FieldOfShapes
    {
        public IEnumerable<Shape> Shapes { get; }

        public FieldOfShapes(ShapesFactory sFactory)
        {
            Shapes = new[]
            {
                sFactory.CreateStar(5, 10, ConsoleColor.Blue),
                sFactory.CreateSizedShape(15, 20, 3, ConsoleColor.Magenta),
                sFactory.CreateMovableShape(25, 30, 5, MoveDirection.ToRight, ConsoleColor.Red)
            };
        }
    }
}
