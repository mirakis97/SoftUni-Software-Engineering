using System;

namespace TextAndNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            string firstName = Console.ReadLine();
            int projectNumbers = int.Parse(Console.ReadLine());
            //Output
            double timeForOneProjetct = projectNumbers * 3;

            Console.WriteLine($"The architect {firstName} will need {timeForOneProjetct} hours to complete {projectNumbers} project/s.");
           
        }
    }
}
