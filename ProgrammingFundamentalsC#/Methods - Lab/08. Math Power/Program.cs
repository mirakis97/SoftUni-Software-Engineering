using System;

namespace _08._Math_Power
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstNum = double.Parse(Console.ReadLine());
            double secondNUm = int.Parse(Console.ReadLine());
            
           double result = RiseToPower(firstNum, secondNUm);
            Console.WriteLine(result);
        }

        static double RiseToPower(double num, double power)
        {
            double result = 0d;
            result = Math.Pow(num, power);
            return result;
        }
    }
}
