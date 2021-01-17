using System;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            int badGrades = int.Parse(Console.ReadLine());
            int faildTimes = 0;
            int solvedProblems = 0;
            double gradeSum = 0;
            string lastProblem = "";
            bool isFaild = true;
            while (faildTimes < badGrades)
            {
                string taskName = Console.ReadLine();
                if (taskName == "Enough")
                {
                    isFaild = false;
                    break;
                }
                int grade = int.Parse(Console.ReadLine());
                if (grade <= 4)
                {
                    faildTimes++;
                }
                gradeSum += grade;
                solvedProblems++;
                lastProblem = taskName;
            }
            if (isFaild)
            {
                Console.WriteLine($"You need a break, {faildTimes} poor grades.");
            }
            else
            {
                Console.WriteLine($"Average score: {gradeSum / solvedProblems:f2}");
                Console.WriteLine($"Number of problems: {solvedProblems}");
                Console.WriteLine($"Last problem: {lastProblem}");
            }
            
        }
    }
}
