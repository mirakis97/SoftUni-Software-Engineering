﻿using System;

namespace _05.Time__15_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            minutes += 15;
            if (minutes >= 60)
            {
                minutes -= 60;
                hours += 1;
            }
            if (hours >= 24)
            {
                hours = 0;
            }
            //Output
            Console.WriteLine($"{hours}:{minutes:d2}"); 
        }
    }
}
