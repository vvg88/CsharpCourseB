using HomeWork8.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork8
{
    class Program
    {
        static void Main(string[] args)
        {
            var singleEngine = SingleToneEngine2D.Instance;
            var squares = new List<CollisionsAvoidSquare>();
            var mediator = new CollisionsAvoidMediator(squares);
            squares.AddRange(new[]
            {
                new CollisionsAvoidSquare(5, 5, 3, new HorisontalMoveStrategy(), mediator),
                new CollisionsAvoidSquare(15, 15, 3, new VerticalMoveStrategy(), mediator)
            });
            singleEngine.Draw(squares);
            //singleEngine.Draw(new[]
            //{
            //    new StrategyMovableSquare(5, 5, 3, new HorisontalMoveStrategy()),
            //    new StrategyMovableSquare(15, 15, 3, new VerticalMoveStrategy())
            //});
        }
    }
}
