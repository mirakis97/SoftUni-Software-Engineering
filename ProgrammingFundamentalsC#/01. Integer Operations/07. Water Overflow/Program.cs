using System;

namespace _07._Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int liters = int.Parse(Console.ReadLine());
            int litersSum = 0;
            for (int i = 0; i < liters; i++)
            {
                int quantitiesWater = int.Parse(Console.ReadLine());

                bool isFull = quantitiesWater > 255;
                bool isOverflow = litersSum + quantitiesWater > 255;
                if (isFull || isOverflow)
                {
                    Console.WriteLine("Insufficient capacity!");
                    continue;
                }

                litersSum += quantitiesWater;
               
            }
            Console.WriteLine($"{litersSum}");
               
        }
    }
}
