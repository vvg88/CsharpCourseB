using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
    /// <summary>
    /// Генератор векторов с произвольными координатами
    /// </summary>
    /// <typeparam name="T"> Тип координат вектора </typeparam>
    class VectorGenerator<T> : IEnumerable<Vector<T>> where T : struct
    {
        /// <summary>
        /// Сгенерированные векторы
        /// </summary>
        private List<Vector<T>> vectors;

        private Random randomGen = new Random();

        /// <summary>
        /// Конструктор генератора
        /// </summary>
        /// <param name="vectNum"> Число генерируемых векторов </param>
        public VectorGenerator(int vectNum)
        {
            vectors = new List<Vector<T>>(vectNum);
            //randomGen = new Random();
            // Сгенерировать векторы с произвольными координатами от -10 до 10
            for (int i = 0; i < vectNum; i++)
            {
                dynamic x = randomGen.Next(-10, 10);
                dynamic y = randomGen.Next(-10, 10);
                vectors.Add(new Vector<T>(x, y));
            }
        }

        public IEnumerator<Vector<T>> GetEnumerator()
        {
            dynamic x = randomGen.Next(-10, 10);
            dynamic y = randomGen.Next(-10, 10);
            yield return new Vector<T>(x, y);
            yield return new Vector<T>(x, y);
            yield return new Vector<T>(x, y);
            yield return new Vector<T>(x, y);
            yield return new Vector<T>(x, y);

            //foreach (var vect in vectors)
            //    yield return vect;
            //return vectors.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
