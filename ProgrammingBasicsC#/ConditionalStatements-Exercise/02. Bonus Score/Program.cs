using System;

namespace _02._Bonus_Score
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            int pointInBegin = int.Parse(Console.ReadLine());
            double bonusPoints = 0.0;
            //Calculations
            if (pointInBegin <= 100)
            {
                bonusPoints = 5;
            }
            else if (pointInBegin > 1000)
            {
                bonusPoints = pointInBegin * 0.1;
            }
            else
            {
                bonusPoints = pointInBegin * 0.2;
            }
            
            if (pointInBegin % 2 == 0)
            {
                bonusPoints = bonusPoints + 1;
            }
            else if (pointInBegin % 10 == 5)
            {
                bonusPoints += 2;
            }
            //Output
            Console.WriteLine(bonusPoints);
            Console.WriteLine(pointInBegin + bonusPoints);
        }
    }
}
