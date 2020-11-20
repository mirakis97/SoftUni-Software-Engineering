using System;

namespace _01._Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string result = string.Empty;

            foreach (var word in text)
            {
                int lenght = word.Length;

                for (int i = 0; i < lenght; i++)
                {
                    result += word;
                }
            }

            Console.WriteLine(result);
        }
    }
}
