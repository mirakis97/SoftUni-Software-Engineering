using System;

namespace _08._Letters_Change_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double result = 0;
            string alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            for (int i = 0; i < input.Length; i++)
            {
                string curr = input[i];
                char fisrtLetter = curr[0];
                char lastLetter = curr[curr.Length - 1];
                double num = double.Parse(curr.Substring(1, curr.Length - 2));

                int firstElementIndex = alpha.IndexOf(char.ToUpper(fisrtLetter));
                int secondElement = alpha.IndexOf(char.ToUpper(lastLetter));

                if ((int)fisrtLetter >= 65 && (int)fisrtLetter <= 90)
                {
                    num = num / (firstElementIndex + 1);
                }
                else
                {
                    num = num * (firstElementIndex + 1);
                }

                if ((int)lastLetter >= 65 && (int)lastLetter <= 90)
                {
                    num = num - (secondElement + 1);
                }
                else
                {
                    num = num + (secondElement + 1);
                }
                result += num;
            }
            Console.WriteLine($"{result:f2}");
        }
    }
}
