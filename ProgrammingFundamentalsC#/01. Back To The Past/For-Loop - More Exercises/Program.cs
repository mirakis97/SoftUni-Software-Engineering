using System;

namespace For_Loop___More_Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int year = int.Parse(Console.ReadLine());
            int yearsOld = 18;
            double lifeCost = 0;
            for (int i = 1800; i <= year; i++)
            {
                if (i % 2 == 0)
                {
                    lifeCost += 12000;
                }
                else
                {
                    lifeCost += 12000 + 50 * yearsOld;
                }

                yearsOld++;
            }

            if (money >= lifeCost)
            {
                double moneyLeft = money - lifeCost;
                Console.WriteLine($"Yes! He will live a carefree life and will have {moneyLeft:f2} dollars left.");
            }
            else
            {
                double moneyHeNeed = lifeCost - money;
                Console.WriteLine($"He will need {moneyHeNeed:f2} dollars to survive.");
            }
        }
    }
}
