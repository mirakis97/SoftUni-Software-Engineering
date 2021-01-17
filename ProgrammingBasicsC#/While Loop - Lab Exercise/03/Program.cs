using System;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyForTrip = double.Parse(Console.ReadLine());
            double moneyWeHave = double.Parse(Console.ReadLine());
            int days = 0;
            int timeSpending = 0;

            while (moneyWeHave < moneyForTrip)
            {
                days++;
                string moving = Console.ReadLine();
                double money = double.Parse(Console.ReadLine());
                if (moving == "spend")
                {
                    timeSpending++;
                    if (timeSpending == 5)
                    {
                        Console.WriteLine("You can't save the money.");
                        Console.WriteLine(days);
                        break;
                    }
                    moneyWeHave -= money;
                    if (moneyWeHave < 0)
                    {
                        moneyWeHave = 0;
                    }

                }
                else if (moving == "save")
                {
                    timeSpending = 0;
                    moneyWeHave += money;
                }
            }
            
            if (moneyWeHave >= moneyForTrip)
            {
                Console.WriteLine($"You saved the money for {days} days.");
            }
        }
    }
}
