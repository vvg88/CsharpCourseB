using Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork7
{
    class ShapesBuilder1 : ShapesBuilder
    {
        protected override void BuildShapes()
        {
            shapes.Add(new Star(3, 3));
            shapes.Add(new Star(Console.WindowWidth - 5, 3));
        }

        protected override void BuildSizedMovableShapes()
        {
            shapes.Add(new MovableSquare(5, 7, 3, MoveDirection.ToRight));
            shapes.Add(new MovableSquare(20, 12, 3, MoveDirection.ToTop, ConsoleColor.Cyan));
        }

        protected override void BuildSizedShapes()
        {
            shapes.Add(new Triangle(15, 20, 5, ConsoleColor.Yellow));
        }
    }
}
