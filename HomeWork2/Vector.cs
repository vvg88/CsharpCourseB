using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
    /// <summary>
    /// Вектор с координатами X и Y
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Vector<T> where T : struct
    {
        /// <summary>
        /// Координата X
        /// </summary>
        public T X { get; private set; }
        /// <summary>
        /// Координата Y
        /// </summary>
        public T Y { get; private set; }
        /// <summary>
        /// Длина вектора
        /// </summary>
        public double Length
        {
            get
            {
                dynamic x = X;
                dynamic y = Y;
                try
                {
                    return Math.Sqrt(x * x + y * y);
                }
                catch (RuntimeBinderException)
                {
                    throw new WrongVectorTypeException($"Тип {typeof(T)} не реализует опреатор + или *!");
                }
            }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="x"> Координата X </param>
        /// <param name="y"> Координата Y </param>
        public Vector(T x, T y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"{X};\t{Y}";
        }

        /// <summary>
        /// Оператор сложения векторов
        /// </summary>
        /// <param name="leftOp"> Левый операнд </param>
        /// <param name="righOp"> Правый опреанд </param>
        /// <exception cref="WrongVectorTypeException"> Если тип координаты вектора не реализует оператор +, возникает исключение </exception>
        /// <returns> Результат сложения </returns>
        public static Vector<T> operator +(Vector<T> leftOp, Vector<T> righOp)
        {
            dynamic lx = leftOp.X;
            dynamic ly = leftOp.Y;
            try
            {
                return new Vector<T>(lx + righOp.X, ly + righOp.Y);
            }
            catch (RuntimeBinderException)
            {
                throw new WrongVectorTypeException($"Тип {typeof(T)} не реализует опреатор +!");
            }
        }

        /// <summary>
        /// Оператор сложения вектора с числом
        /// </summary>
        /// <param name="leftOp"> Левый операнд </param>
        /// <param name="righOp"> Правый опреанд </param>
        /// <exception cref="WrongVectorTypeException"> Если тип координаты вектора не реализует оператор +, возникает исключение </exception>
        /// <returns> Результат сложения </returns>
        public static Vector<T> operator +(Vector<T> leftOp, T righOp)
        {
            dynamic lx = leftOp.X;
            dynamic ly = leftOp.Y;
            try
            {
                return new Vector<T>(lx + righOp, ly + righOp);
            }
            catch (RuntimeBinderException)
            {
                throw new WrongVectorTypeException($"Тип {typeof(T)} не реализует опреатор +!");
            }
        }

        /// <summary>
        /// Оператор равно для векторов
        /// </summary>
        /// <param name="leftOp"> Левый операнд </param>
        /// <param name="righOp"> Правый опреанд </param>
        /// <returns> Результат операци </returns>
        public static bool operator ==(Vector<T> leftOp, Vector<T> righOp)
        {
            return leftOp.Length == leftOp.Length;
        }

        /// <summary>
        /// Оператор не равно для векторов
        /// </summary>
        /// <param name="leftOp"> Левый операнд </param>
        /// <param name="righOp"> Правый опреанд </param>
        /// <returns> Результат операци </returns>
        public static bool operator !=(Vector<T> leftOp, Vector<T> righOp)
        {
            return leftOp.Length != leftOp.Length;
        }
    }
}
