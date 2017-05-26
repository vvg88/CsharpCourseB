using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
    class VectorGenerator<T> : IEnumerable<Vector<T>> where T : struct
    {
        private List<Vector<T>> vectors;

        public VectorGenerator(int vectNum)
        {
            vectors = new List<Vector<T>>(vectNum);
            var randomGen = new Random();
            for (int i = 0; i < vectNum; i++)
            {
                dynamic x = randomGen.Next(-10, 10);
                dynamic y = randomGen.Next(-10, 10);
                vectors.Add(new Vector<T>(x, y));
            }
        }

        public IEnumerator<Vector<T>> GetEnumerator()
        {
            return vectors.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
