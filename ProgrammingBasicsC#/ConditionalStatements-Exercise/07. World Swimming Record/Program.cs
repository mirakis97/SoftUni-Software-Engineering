using System;

namespace _07._World_Swimming_Record
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            double recordInSeconds = double.Parse(Console.ReadLine());
            double distanceInMeters = double.Parse(Console.ReadLine());
            double timeInSeconds = double.Parse(Console.ReadLine());
            //Caluculations
            double timeForSwim = distanceInMeters * timeInSeconds;
            double resistance = Math.Floor(distanceInMeters / 15) * 12.5;
            double finalTime = timeForSwim + resistance;
            
            if (finalTime < recordInSeconds)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {finalTime:f2} seconds.");
            }
            else
            {
                double timeHeNeed = finalTime - recordInSeconds;
                Console.WriteLine($"No, he failed! He was {timeHeNeed:f2} seconds slower.");
            }
        }
    }
}
