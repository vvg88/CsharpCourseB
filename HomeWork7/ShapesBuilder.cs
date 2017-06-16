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
        protected List<Shape> shapes;
        public IEnumerable<Shape> Shapes => shapes;

        protected abstract void BuildShapes();
        protected abstract void BuildSizedShapes();
        protected abstract void BuildSizedMovableShapes();
    }
}
