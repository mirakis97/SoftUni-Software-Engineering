﻿using System;

namespace _02._Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            string result = string.Empty;

            if (num % 10 == 0)
            {
                result="The number is divisible by 10";
            }
            else if (num % 7 == 0)
            {
                result ="The number is divisible by 7";
            }
            else if (num % 6 == 0)
            {
                result = "The number is divisible by 6";
            }
            else if (num % 3 == 0)
            {
                result = "The number is divisible by 3";
            }
            else if (num % 2 == 0)
            {
               result = "The number is divisible by 2";
            }
            else
            {
                result = "Not divisible";
            }

            Console.WriteLine(result);
        }
    }
}
