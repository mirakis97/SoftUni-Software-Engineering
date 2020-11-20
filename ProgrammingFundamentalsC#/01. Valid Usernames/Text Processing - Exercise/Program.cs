using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
namespace Text_Processing___Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(", ");

            for (int i = 0; i < input.Length; i++)
            {
                var curChar = input[i];
                if (IsValid(curChar))
                {
                    Console.WriteLine(curChar);
                }
            }
        }

        public static bool IsValid(string curChar)
        {
            return curChar.Length >= 3 &&
                curChar.Length < 16 &&
                curChar.All(c => char.IsLetterOrDigit(c)) ||
                curChar.Contains("-") || curChar.Contains("_");
        }
    }
}
