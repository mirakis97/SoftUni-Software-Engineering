using System;

namespace _04.VacationBooksList
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            double pages = double.Parse(Console.ReadLine());
            double pagesPerHour = double.Parse(Console.ReadLine());
            double daysOfReading = double.Parse(Console.ReadLine());
            //Calculations
            double dayOfReadingTheBook = pages / pagesPerHour;
            double dailyHoursOfReading = dayOfReadingTheBook / daysOfReading;
            //Output
            Console.WriteLine(dailyHoursOfReading);
        }
    }
}
