using Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork7
{
    class ShapesBuilder2 : ShapesBuilder
    {

        protected override void BuildShapes()
        {
            shapes.Add(new AnyStar(3, 3));
        }

        protected override void BuildSizedMovableShapes()
        {
            shapes.Add(new MovableSquare(5, 15, 3, MoveDirection.ToRight));
            shapes.Add(new MovableTriangle(35, 20, 5, MoveDirection.ToTop, ConsoleColor.Green));
        }

        protected override void BuildSizedShapes()
        {
            shapes.Add(new Triangle(5, Console.WindowHeight - 3, 5, ConsoleColor.Yellow));
            shapes.Add(new Square(25, Console.WindowHeight - 3, 3, ConsoleColor.Red));
        }
    }
}
