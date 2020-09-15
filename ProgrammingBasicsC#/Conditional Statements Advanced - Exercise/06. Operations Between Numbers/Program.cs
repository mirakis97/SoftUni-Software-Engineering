using System;

namespace _06._Operations_Between_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            string math = Console.ReadLine();

            double result = 0;
            string type = "";

            if (math == "+")
            {
                result = n1 + n2;
                if (result % 2 == 0)
                {
                    type = "even";
                    Console.WriteLine($"{n1} {math} {n2} = {result} - {type}");
                }
                else
                {
                    type = "odd";
                    Console.WriteLine($"{n1} {math} {n2} = {result} - {type}");
                }
            }
            else if (math == "-")
            {
                result = n1 - n2;
                if (result % 2 == 0)
                {
                    type = "even";
                    Console.WriteLine($"{n1} {math} {n2} = {result} - {type}");
                }
                else
                {
                    type = "odd";
                    Console.WriteLine($"{n1} {math} {n2} = {result} - {type}");
                }
            }
            else if (math == "*")
            {
                result = n1 * n2;
                if (result % 2 == 0)
                {
                    type = "even";
                    Console.WriteLine($"{n1} {math} {n2} = {result} - {type}");
                }
                else
                {
                    type = "odd";
                    Console.WriteLine($"{n1} {math} {n2} = {result} - {type}");
                }
            }
            else if (math == "/" && n2 == 0)
            {
                Console.WriteLine($"Cannot divide {n1} by zero");
            }
            else if (math == "%" && n2 == 0)
            {
                Console.WriteLine($"Cannot divide {n1} by zero");
            }
            else if (math == "/")
            {
                result = (double)n1  /  n2;
                Console.WriteLine($"{n1} / {n2} = {result:f2}");
            }
            else if (math == "%")
            {
                result = (double)n1 % n2;
                Console.WriteLine($"{n1} % {n2} = {result}");
            }
        }
    }
}
