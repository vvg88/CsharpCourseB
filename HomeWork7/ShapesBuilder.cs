using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shapes;

namespace HomeWork7
{
    abstract class ShapesBuilder
    {
        protected List<Shape> shapes = new List<Shape>();
        public IEnumerable<Shape> Shapes => shapes;

        public ShapesBuilder()
        {
            BuildShapes();
            BuildSizedShapes();
            BuildSizedMovableShapes();
        }

        protected abstract void BuildShapes();
        protected abstract void BuildSizedShapes();
        protected abstract void BuildSizedMovableShapes();
    }
}
