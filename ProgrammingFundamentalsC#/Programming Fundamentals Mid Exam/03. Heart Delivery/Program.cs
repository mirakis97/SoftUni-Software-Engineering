using System;
using System.Linq;

namespace _03._Heart_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] neighborhood = Console.ReadLine()
                .Split("@")
                .Select(int.Parse).ToArray();

            int jumpPosition = 0;

            string cmd = Console.ReadLine();

            while (cmd != "Love!")
            {
                string[] comandArgs = cmd.Split();
                int jumpLenght = int.Parse(comandArgs[1]);

                jumpPosition += jumpLenght;

                if (jumpPosition >= 0 && jumpPosition < neighborhood.Length)
                {
                    neighborhood[jumpPosition] -= 2;
                }
                else
                {
                    jumpPosition = 0;
                    neighborhood[jumpPosition] -= 2;
                }

                if (neighborhood[jumpPosition] == 0)
                {
                    Console.WriteLine($"Place {jumpPosition} has Valentine's day.");
                }
                else if (neighborhood[jumpPosition] < 0)
                {
                    Console.WriteLine($"Place {jumpPosition} already had Valentine's day.");
                }
                cmd = Console.ReadLine();
            }

            Console.WriteLine($"Cupid's last position was {jumpPosition}.");

            int succsesCount = neighborhood.Count(x => x == 0);
            int failCount = neighborhood.Count(x => x > 0);

            if (failCount == 0)
            {
                Console.WriteLine($"Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid has failed {failCount} places.");
            }
        }
    }
}   

