using Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork8
{
    abstract class MoveStrategy
    {
        public MoveDirection MoveDirect { get; protected set; }

        public abstract void Move(SizedShape shape, bool changeDirection);
    }
}
