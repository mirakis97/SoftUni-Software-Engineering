using System;
using System.Runtime.InteropServices.ComTypes;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            double mark = double.Parse(Console.ReadLine());
            double salary = double.Parse(Console.ReadLine());
           
            double socialScholarship = Math.Floor(salary * 0.35);
            double excellentScholarship = Math.Floor(mark * 25);

            if (income >= salary && mark >= 5.5)
            {
                Console.WriteLine($"You get a scholarship for excellent results {excellentScholarship} BGN");
            }
            else if (income >= salary && mark < 5.5 )
            {
                Console.WriteLine($"You cannot get a scholarship!");
            }
            else if (income < salary && mark > 5.5 && socialScholarship <= excellentScholarship)
            {
                Console.WriteLine($"You get a scholarship for excellent results {excellentScholarship} BGN");
            }
            else if (income < salary && mark > 4.5)
            {
                Console.WriteLine($"You get a Social scholarship {socialScholarship} BGN");
            }
            else if (income < salary && mark < 4.5)
            {
                Console.WriteLine($"You cannot get a scholarship!");
            }    
        }
    }
}
