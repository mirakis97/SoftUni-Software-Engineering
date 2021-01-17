using System;

namespace _06._Vowels_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int number = 0;
            for (int i = 0; i < input.Length; i++)
            {
                char currentLetter = input[i];

                switch (currentLetter)
                {
                    case 'a':
                        number += 1;
                        break;
                    case 'e':
                        number += 2;
                        break;
                    case 'i':
                        number += 3;
                        break;
                    case 'o':
                        number += 4;
                        break;
                    case 'u':
                        number += 5;
                        break;
                }
            }
            Console.WriteLine(number);
        }
    }
}
