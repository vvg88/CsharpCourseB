using System;

namespace HomeWork2
{
    /// <summary>
    /// Исключение, возникающее в том случае, если тип координаты вектора не реализует какой-то оператор
    /// </summary>
    class WrongVectorTypeException : Exception
    {
        public WrongVectorTypeException(string msg) : base (msg)
        { }
    }
}
