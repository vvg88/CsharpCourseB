using HomeWork5;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWork7
{
    sealed class SingleToneEngine2D
    {
        private static SingleToneEngine2D instance;

        public static SingleToneEngine2D Instance => instance ?? (instance = new SingleToneEngine2D());

        private SingleToneEngine2D() { }

        public void Draw(IEnumerable<Shape> shapes)
        {
            while (true)
            {
                Clear();
                var movableShapes = shapes.OfType<IMovableShape>();
                foreach (var mSahpe in movableShapes)
                {
                    mSahpe.Move();
                }
                foreach (var shape in shapes)
                {
                    shape.Draw(Ticks);
                }

                Thread.Sleep(250);
                Ticks++;
            }
        }

        public int Ticks { get; private set; }

        private void Clear()
        {
            Console.Clear();
        }
    }
}
