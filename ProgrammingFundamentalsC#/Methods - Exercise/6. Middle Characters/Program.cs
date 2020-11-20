using System;

namespace _6._Middle_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            if (text.Length % 2 == 0)
            {
                string output = GetMiddleCharFromEven(text);
                Console.WriteLine(output);
            }
            else
            {
                string oddOutput = GetMiddCahrFromOdd(text);
                Console.WriteLine(oddOutput);
            }
        }

        private static string GetMiddCahrFromOdd(string text)
        {
            int index = text.Length / 2;
            string chars = text.Substring(index, 1);
            return chars;
        }

        private static string GetMiddleCharFromEven(string text)
        {
            int index = text.Length / 2;
            string chars = text.Substring(index - 1, 2);
            return chars;
        }
    }
}
