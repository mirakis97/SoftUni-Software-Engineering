using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class FoodAsterisk : Food
    {
        private const char foodSymbol = '*';
        private const int points = 1;
        private const ConsoleColor Color = ConsoleColor.Red;
        public FoodAsterisk(Wall wall)
            : base(wall, foodSymbol, points,Color)
        {
        }
    }
}
