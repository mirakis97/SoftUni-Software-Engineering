using System;

namespace _04._Train_The_Trainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            string cmd = Console.ReadLine();
            int gradeCount = 0;
            double gradeSum = 0;
            while (cmd != "Finish")
            {
                double grades = 0;
                for (int i = 0; i < num; i++)
                {
                    double grad = double.Parse(Console.ReadLine());
                    grades += grad;
                    gradeCount++;
                    gradeSum += grad;
                }
                double average = grades / num;
                Console.WriteLine($"{cmd} - {average:f2} ");
                cmd = Console.ReadLine();
            }
            double averageSum = gradeSum / gradeCount;
            Console.WriteLine($"Student's final assessment is {averageSum:f2}.");
        }
    }
}
