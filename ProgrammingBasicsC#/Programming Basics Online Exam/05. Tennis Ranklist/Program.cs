using System;

namespace _05._Tennis_Ranklist
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxPoints = 301;

            string name = Console.ReadLine();


            int shots = 0;
            int faildShots = 0;


            while (true)
            {
                string cmd = Console.ReadLine();
                int points = int.Parse(Console.ReadLine());
                if (cmd == "Retire")
                {
                    break;
                }
                

                if (cmd == "Single")
                {
                    maxPoints -= points;
                    shots++;
                }
                else if (cmd == "Double")
                {
                    points *= 2;
                    maxPoints -= points;
                    shots++;
                }
                else if (cmd == "Triple")
                {
                    points *= 3;
                    maxPoints -= points;
                    shots++;
                }

                else if (points > maxPoints)
                {
                    cmd = Console.ReadLine();
                    points = Console.Read();
                    if (points < maxPoints)
                    {
                        continue;
                    }
                    faildShots++;
                }


                if (maxPoints == 0)
                {
                    Console.WriteLine($"{name} won the leg with {shots} shots.");
                    Environment.Exit(0);
                }

            }
            Console.WriteLine($"{name} retired after {faildShots} unsuccessful shots.");
        }
    }
}
