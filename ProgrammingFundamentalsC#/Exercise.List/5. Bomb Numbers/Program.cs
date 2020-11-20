using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _5._Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                            .Split()
                            .Select(int.Parse)
                            .ToList();

            int[] bombProp = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int bomb = bombProp[0];
            int power = bombProp[1];

            for (int i = 0; i < numbers.Count; i++)
            {
                int currentNumber = numbers[i];

                if (currentNumber == bomb)
                {
                    int starIndex = i - power;
                    int endIndex = i + power;

                    if (starIndex < 0)
                    {
                        starIndex = 0;
                    }
                    if (endIndex > numbers.Count - 1)
                    {
                        endIndex = numbers.Count - 1;
                    }

                    int indexToRemove = endIndex - starIndex + 1;
                    numbers.RemoveRange(starIndex, indexToRemove);

                    i = starIndex - 1;
                }
            }
            Console.WriteLine(numbers.Sum());
        }
    }
}
