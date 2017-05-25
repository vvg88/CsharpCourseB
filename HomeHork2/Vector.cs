using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
    class Vector<T> where T : struct
    {
        public T X { get; private set; }

        public T Y { get; private set; }

        public double Length
        {
            get
            {
                dynamic x = X;
                dynamic y = Y;
                return Math.Sqrt(x * x + y * y);
            }
        }

        public Vector(T x, T y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"{X};\t{Y}";
        }

        public static Vector<T> operator +(Vector<T> leftOp, Vector<T> righOp)
        {
            dynamic lx = leftOp.X;
            dynamic ly = leftOp.Y;
            return new Vector<T>(lx + righOp.X, ly + righOp.Y);
        }

        public static Vector<T> operator +(Vector<T> leftOp, T righOp)
        {
            dynamic lx = leftOp.X;
            dynamic ly = leftOp.Y;
            return new Vector<T>(lx + righOp, ly + righOp);
        }

        public static bool operator ==(Vector<T> leftOp, Vector<T> righOp)
        {
            return leftOp.Length == leftOp.Length;
        }

        public static bool operator !=(Vector<T> leftOp, Vector<T> righOp)
        {
            return leftOp.Length != leftOp.Length;
        }
    }
}
