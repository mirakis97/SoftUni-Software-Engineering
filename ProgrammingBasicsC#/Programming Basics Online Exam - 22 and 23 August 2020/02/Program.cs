using System;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalPeople = int.Parse(Console.ReadLine());
            int powerOFOneGuy = int.Parse(Console.ReadLine());
            int healthOfIldun = int.Parse(Console.ReadLine());

            int totalPower = totalPeople * powerOFOneGuy;

            if(totalPower >= healthOfIldun)
            {
                int pointsLeft = totalPower - healthOfIldun;
                Console.WriteLine($"Illidan has been slain! You defeated him with {pointsLeft} points.");
            }
            else
            {
                int pointsNeeeded = healthOfIldun - totalPower;
                Console.WriteLine($"You are not prepared! You need {pointsNeeeded} more points.");
            }


        }
    }
}
