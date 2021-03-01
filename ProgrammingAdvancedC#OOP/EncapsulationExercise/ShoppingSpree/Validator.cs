using System;

namespace ShoppingSpree
{
    public static class Validator
    {
        public static void ThrowIfStringIsNullOrEmpty(string str, string ex)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                throw new ArgumentException(ex);
            }
        }

        public static void ThrowIfNumberIsNegative(decimal num, string ex)
        {
            if (num < 0)
            {
                throw new ArgumentException(ex);
            }
        }
    }
}