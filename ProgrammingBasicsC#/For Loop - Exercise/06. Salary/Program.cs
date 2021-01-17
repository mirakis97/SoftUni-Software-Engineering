using System;

namespace _06._Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            const  int facebook = 150;
            const int instagram = 100;
            const int reddit = 50;
            int openTab = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());

            for (int i = 0; i <= openTab; i++)
            {
                if (salary == 0)
                {
                    Console.WriteLine($"You have lost your salary.");
                    break;
                }
                string website = Console.ReadLine();

                if (website == "Facebook")
                {
                    salary -= facebook;
                }
                else if (website == "Instagram")
                {
                    salary -= instagram;
                }
                else if (website == "Reddit")
                {
                    salary -= reddit;
                }
            }
            if (salary > 0)
            {
                Console.WriteLine($"{salary}");
            }
        }
    }
}
