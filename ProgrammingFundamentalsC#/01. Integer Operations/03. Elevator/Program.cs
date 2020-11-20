using System;

namespace _03._Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            int elevatorCapacity = int.Parse(Console.ReadLine());
            int coursesCount = 0;
            while (people > 0)
            {
                people -= elevatorCapacity;
                coursesCount++;

            }

            Console.WriteLine(coursesCount);
        }
    }
}
