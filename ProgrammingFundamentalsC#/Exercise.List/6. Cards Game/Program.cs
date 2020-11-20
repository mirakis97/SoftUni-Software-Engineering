using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Cards_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                           .Split()
                           .Select(int.Parse)
                           .ToList();
            List<int> numbers2 = Console.ReadLine()
                           .Split()
                           .Select(int.Parse)
                           .ToList();

            while (numbers.Count != 0 && numbers2.Count != 0)
            {
                int firstPlayerCard = numbers[0];
                int secondPlayerCard = numbers2[0];

                if (firstPlayerCard > secondPlayerCard)
                {
                    numbers.Add(firstPlayerCard);
                    numbers.Add(secondPlayerCard);
                }
                else if (firstPlayerCard < secondPlayerCard)
                {
                    numbers2.Add(secondPlayerCard);
                    numbers2.Add(firstPlayerCard);
                }
                numbers.RemoveAt(0);
                numbers2.RemoveAt(0);
            }
            if (numbers.Count == 0)
            {
                Console.WriteLine($"Second player wins! Sum: {numbers2.Sum()}");
            }
            else
            {
                Console.WriteLine($"First player wins! Sum: {numbers.Sum()}");
            }
        }
    }
}
