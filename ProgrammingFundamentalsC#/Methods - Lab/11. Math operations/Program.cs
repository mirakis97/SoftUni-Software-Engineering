using System;

namespace _10._Multiply_Evens_by_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            var operation = Console.ReadLine();
            int b = int.Parse(Console.ReadLine());
            double result = Calculate(a, operation, b);
            Console.WriteLine(result);
        }

        private static double Calculate(int a, string operation, int b)
        {
            double result = 0;

            switch (operation)
            {
                case "+":
                    result = a + b;
                    break;
                case "-":
                    result = a - b;
                    break;
                case "*":
                    result = a * b;
                    break;
                case "/":
                    result = a / b;
                    break;

            }

            return result;
        }
    }
}
