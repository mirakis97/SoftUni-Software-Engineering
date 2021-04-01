using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects
{
   public class FoodDollar : Food
    {
        private const char foodSymbol = '$';
        private const int points = 2;
        private const ConsoleColor Color = ConsoleColor.Green;
        public FoodDollar(Wall wall)
            : base(wall, foodSymbol, points, Color)
        {
        }
    }
}
