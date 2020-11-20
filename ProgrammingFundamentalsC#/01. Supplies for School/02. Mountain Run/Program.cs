using System;

namespace _02._Mountain_Run
{
    class Program
    {
        static void Main(string[] args)
        {
            double recordInSeconds = double.Parse(Console.ReadLine());
            double distanceInMeters = double.Parse(Console.ReadLine());
            double timeInSeconds = double.Parse(Console.ReadLine());

            double timeForClimb = distanceInMeters * timeInSeconds;
            double slower = Math.Floor(distanceInMeters / 50) * 30;
            double totalTime = timeForClimb + slower;

            if (totalTime >= recordInSeconds)
            {
                double timeHeNeed = totalTime - recordInSeconds;
                Console.WriteLine($"No! He was {timeHeNeed:f2} seconds slower.");
            }
            else
            {
                Console.WriteLine($" Yes! The new record is {totalTime:f2} seconds.");
            }
        }
    }
}
