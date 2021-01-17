using System;

namespace Programming_Basics_Online_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            int eggsPlayerOne = int.Parse(Console.ReadLine());
            int eggsPlayerTwo = int.Parse(Console.ReadLine());

            const   int PlayerOneEgs = 1;
            const   int PlayerTwoEgs = 1;
            while (true)
            {
                
                string cmd = Console.ReadLine();
                if (cmd == "End of battle")
                {
                    Console.WriteLine($"Player one has {eggsPlayerOne} eggs left.");
                    Console.WriteLine($"Player two has {eggsPlayerTwo} eggs left.");
                    Environment.Exit(0);
                }

                if (cmd == "one")
                {
                     eggsPlayerTwo -= PlayerTwoEgs;
                }
                else
                {
                    eggsPlayerOne -= PlayerOneEgs;
                }
                

                if (eggsPlayerOne == 0)
                {
                    Console.WriteLine($"Player one is out of eggs. Player two has {eggsPlayerTwo} eggs left.");
                    break;
                }
                if (eggsPlayerTwo == 0)
                {
                    Console.WriteLine($"Player two is out of eggs. Player one has {eggsPlayerOne} eggs left.");
                    break;
                }

            }
        }
    }
}
