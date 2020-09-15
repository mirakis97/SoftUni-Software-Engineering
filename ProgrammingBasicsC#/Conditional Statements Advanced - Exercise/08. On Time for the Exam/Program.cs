using System;

namespace _08._On_Time_for_the_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            int hourExamStart = int.Parse(Console.ReadLine());
            int minutesOfExamStart = int.Parse(Console.ReadLine());
            int hourOfComing = int.Parse(Console.ReadLine());
            int minutesOfComing = int.Parse(Console.ReadLine());
            int difference = 0;
            int hour = 0;
            int minutes = 0;

            minutesOfExamStart += hourExamStart * 60;
            minutesOfComing += hourOfComing * 60;

            if (minutesOfComing > minutesOfExamStart)
            {
                Console.WriteLine("Late");
                difference = minutesOfComing - minutesOfExamStart;
                if (difference < 60)
                {
                    Console.WriteLine($"{difference} minutes after the start");
                }
                else
                {
                    hour = difference / 60;
                    minutes = difference % 60;
                    Console.WriteLine($"{hour}:{minutes:d2} hours after the start");
                }
            }
            else if (minutesOfComing < minutesOfExamStart - 30)
            {
                Console.WriteLine("Early");
                difference = minutesOfExamStart - minutesOfComing;
                if (difference < 60)
                {
                    Console.WriteLine($"{difference} minutes before the start");
                }
                else
                {
                    hour = difference / 60;
                    minutes = difference % 60;
                    Console.WriteLine($"{hour}:{minutes:d2} hours before the start");
                }
            }
            else
            {
                Console.WriteLine("On Time");
                difference = minutesOfExamStart - minutesOfComing;
                Console.WriteLine($"{difference} minutes before the start");
            }
        }
    }
}
