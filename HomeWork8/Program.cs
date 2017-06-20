using HomeWork8.Decorator;
using HomeWork8.Mediator;
using Shapes;
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
            var notCollisSquares = new List<CollisionsAvoidSquare>();
            var mediator = new CollisionsAvoidMediator(notCollisSquares);
            notCollisSquares.AddRange(new[]
            {
                new CollisionsAvoidSquare(5, 5, 3, new HorisontalMoveStrategy(), mediator),
                new CollisionsAvoidSquare(10, 10, 3, new VerticalMoveStrategy(), mediator),
                new CollisionsAvoidSquare(5, 20, 5, new HorisontalMoveStrategy(), mediator),
                new CollisionsAvoidSquare(20, 20, 2, new VerticalMoveStrategy(), mediator, ConsoleColor.Yellow),
                new SquareDecorator(new CollisionsAvoidSquare(10, 15, 2, new HorisontalMoveStrategy(), mediator))
            });
            //var squares = new List<StrategyMovableSquare>
            singleEngine.Draw(notCollisSquares);
            //singleEngine.Draw(new[]
            //{
            //    new StrategyMovableSquare(5, 5, 3, new HorisontalMoveStrategy()),
            //    new StrategyMovableSquare(15, 15, 3, new VerticalMoveStrategy())
            //});
        }
    }
}
