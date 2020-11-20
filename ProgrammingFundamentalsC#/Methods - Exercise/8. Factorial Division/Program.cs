using System;

namespace _8._Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            double calculateFactorialFirstNum = GetFactorial(num1);
            double calculateFactorialFirstNum2 = GetFactorial(num2);

            double result = calculateFactorialFirstNum / calculateFactorialFirstNum2;

            Console.WriteLine($"{result:f2}");

        }

        private static double GetFactorial(int num1)
        {
            double result = 1;
            while (num1 != 1)
            {
                result = result * num1;
                num1 = num1 - 1;
            }
            return result;
        }
    }
}
