using System;

namespace PizzaCalories
{
    public static class Validator
    {
        public static void ThrowIfNumberIsNotInRange(int min, int max, int num, string ex)
        {
            if (num < min || num > max)
            {
                throw new ArgumentException(ex);
            }
        }
    }
}