using System;

namespace SoftUni_Reception
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstEmployee = int.Parse(Console.ReadLine());
            int SecondEmployee = int.Parse(Console.ReadLine());
            int thirdEmployee = int.Parse(Console.ReadLine());
            int studentCount = int.Parse(Console.ReadLine());

            int totalEmployes = firstEmployee + SecondEmployee + thirdEmployee;

            int neededHours = 0;

            while (studentCount > 0)
            {
                studentCount -= totalEmployes;
                neededHours++;

                if (neededHours % 4 == 0)
                {
                    neededHours++;
                }
            }

            Console.WriteLine($"Time needed: {neededHours}h.");
        }
    }
}
