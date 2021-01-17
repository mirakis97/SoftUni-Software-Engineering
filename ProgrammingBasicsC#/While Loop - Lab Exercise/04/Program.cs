using System;

namespace _04
{
    class Program
    {
        static void Main(string[] args)
        {
            int steps = 10000;
            int stepsOver = 0;

            while (stepsOver < steps)
            {
                string word = Console.ReadLine();
                if (word == "Going home")
                {
                    int stepsLeft = int.Parse(Console.ReadLine());
                    stepsOver += stepsLeft;
                    break;
                }
                else
                {
                    int stepss = int.Parse(word);
                    stepsOver += stepss;
                }

            }
            if (stepsOver > steps)
            {
                int overSteps = stepsOver - steps;
                Console.WriteLine($"Goal reached! Good job!");
                Console.WriteLine($"{overSteps} steps over the goal!");
            }
            else
            {
                int stepsWeNeed = steps - stepsOver;
                Console.WriteLine($"{stepsWeNeed} more steps to reach goal.");
            }
        }
    }
}
