using Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork8.Mediator
{
    class CollisionsAvoidMediator
    {
        private IEnumerable<CollisionsAvoidSquare> squares;

        public CollisionsAvoidMediator(IEnumerable<CollisionsAvoidSquare> squares)
        {
            this.squares = squares;
        }

        public bool Send(CollisionsAvoidSquare square)
        {
            var isCollision = true;
            foreach(var sqr in squares)
            {
                isCollision &= sqr.Notify(square);
            }
            return isCollision;
        }
    }
}
