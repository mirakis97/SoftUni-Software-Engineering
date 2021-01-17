using System;

namespace _05
{
    class Program
    {
        static void Main(string[] args)
        {


            int maxMeters = 5364;
            int days = 1;
            while (true)
            {
                string cmd = Console.ReadLine();

                if (cmd == "END")
                {
                    Console.WriteLine("Failed!");
                    Console.WriteLine($"{maxMeters}");
                    Environment.Exit(0);
                }
                else if (cmd == "Yes")
                {
                    days++;
                }
                int meters = int.Parse(Console.ReadLine());
                maxMeters += meters;

                if (days >= 5)
                {
                    Console.WriteLine("Failed!");
                    Console.WriteLine($"{maxMeters}");
                    Environment.Exit(0);
                }
                else if (maxMeters >= 8848)
                {
                    Console.WriteLine($"Goal reached for {days} days!");
                    break;
                }
            }
        }
    }
}
