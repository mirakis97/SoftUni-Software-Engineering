using System;
using System.Xml.Schema;

namespace Programming_Fundamentals_Mid_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            double countStudent = double.Parse(Console.ReadLine());
            double lectures = double.Parse(Console.ReadLine());
            double additionalBonus = double.Parse(Console.ReadLine());

            double atendetLectures = 0;
            double maxBonus = 0;

            for (int i = 0; i < countStudent; i++)
            {
                double attendancy = double.Parse(Console.ReadLine());

                double bonus = Math.Round(attendancy / lectures * (5 + additionalBonus));

                if (bonus >= maxBonus )
                {
                    maxBonus = bonus;
                    atendetLectures = attendancy;
                }
            }

            Console.WriteLine($"Max Bonus: {maxBonus}.");
            Console.WriteLine($"The student has attended {atendetLectures} lectures.");
            
        }
    }
}
