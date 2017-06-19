using Shapes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWork8
{
    sealed class SingleToneEngine2D
    {
        private static SingleToneEngine2D instance;

        public static SingleToneEngine2D Instance => instance ?? (instance = new SingleToneEngine2D());

        private SingleToneEngine2D() { }

        public void Draw(IEnumerable<StrategyMovableSquare> shapes)
        {
            while (true)
            {
                Clear();
                foreach (var shape in shapes)
                {
                    shape.Move();
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
