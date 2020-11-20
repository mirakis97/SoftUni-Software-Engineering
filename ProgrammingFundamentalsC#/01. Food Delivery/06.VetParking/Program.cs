using System;

namespace _06.VetParking
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());
            double oddSum = 2.50;
            double evenSum = 1.25;
            double elseSum = 1.0;
            double money = 0;
            double moneySum = 0;
            for (int i = 0; i < days; i++)
            {
                
                for (int j = 0; j < hours; j++)
                {
                    if (days % 2 == 0 && hours % 2 != 0)
                    {
                        money += oddSum;
                    }
                    else if (days % 2 != 0 && hours % 2 == 0)
                    {
                        money += evenSum;
                    }
                    else
                    {
                        money += elseSum;
                    }
                    moneySum += money;
                }
                double totalSum = moneySum + money;
                Console.WriteLine($"Day: {i} - {money:f2}");
                Console.WriteLine($"Total: {totalSum}");
            }
            
        }
    }
}

