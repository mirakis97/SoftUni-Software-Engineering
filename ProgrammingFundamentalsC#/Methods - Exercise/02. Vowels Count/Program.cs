using System;

namespace _02._Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToLower();

            int result = PrintVowels(input);
            
            Console.WriteLine(result);
        }
        static int PrintVowels(string input)
        {
            int counter = 0;

            for (int i = 0; i < input.Length; i++)
            {
                char curentChar = input[i];

                if (curentChar == 'a')
                {
                    counter++;
                }
                else if (curentChar == 'e')
                {
                    counter++;
                }
                else if (curentChar == 'i')
                {
                    counter++;
                }
                else if (curentChar == 'o')
                {
                    counter++;
                }
                else if (curentChar == 'u')
                {
                    counter++;
                }
                else if (curentChar == 'y')
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}
