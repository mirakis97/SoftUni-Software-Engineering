using System;

namespace _02._Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokens = Console.ReadLine().Split();

            var firstWord = tokens[0];
            var secondWord = tokens[1];

            var longWord = firstWord;
            var shortWord = secondWord;

            if (firstWord.Length < secondWord.Length)
            {
                longWord = secondWord;
                shortWord = firstWord;
            }
            var totalSum = Sum(longWord, shortWord);

            Console.WriteLine(totalSum);
        }
        public static int Sum(string longWord, string shortWord)
        {
            var sum = 0;
            for (int i = 0; i < shortWord.Length; i++)
            {
                var multiply = longWord[i] * shortWord[i];
                sum += multiply;
            }

            for (int i = shortWord.Length; i < longWord.Length; i++)
            {
                sum += longWord[i];
            }
            return sum;
        }
    }
}
