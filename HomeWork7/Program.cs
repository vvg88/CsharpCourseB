using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork7
{
    class Program
    {
        static void Main(string[] args)
        {
            var shapesField1 = new FieldOfShapes(new ShapesFactory1());
            var shapesField2 = new FieldOfShapes(new ShapesFactory2());

            var singleEngine = SingleToneEngine2D.Instance;
            singleEngine.Draw(shapesField2.Shapes);
        }
    }
}
