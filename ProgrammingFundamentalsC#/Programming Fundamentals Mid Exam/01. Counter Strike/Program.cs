using System;

namespace _01._Counter_Strike
{
    class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());
            int batllesWon = 0;
            int wins = 0;
            string cmd = Console.ReadLine();

            while (cmd != "End of battle")
            {
                batllesWon++;
                int distance = int.Parse(cmd);
                if (energy < distance)
                {
                    Console.WriteLine($"Not enough energy! Game ends with {wins} won battles and {energy} energy");
                    Environment.Exit(0);
                }
                energy -= distance;
                
                
                wins++;

                if (batllesWon % 3 == 0)
                {
                    energy += wins; ;
                }

                

                cmd = Console.ReadLine();
            }

            Console.WriteLine($"Won battles: {wins}. Energy left: {energy}");
        }
    }
}
