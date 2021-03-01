using System;

namespace FootballTeamGenerator
{
    public static class Validator
    {
        public static void ThrowIfStringIsNullOrWhiteSpace(string str,string ex)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                throw new ArgumentException(ex);
            }
        }

        public static void ThrowIfNumberIsNotInRange(int num, int min, int max, string ex)
        {
            if (num < min || num > max)
            {
                throw new ArgumentException(ex);
            }
        }
    }
}