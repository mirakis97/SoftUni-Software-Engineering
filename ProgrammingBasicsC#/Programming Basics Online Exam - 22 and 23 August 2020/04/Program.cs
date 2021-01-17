using System;

namespace _04
{
    class Program
    {
        static void Main(string[] args)
        {
            double s = double.Parse(Console.ReadLine());
            double sComplex = s;
            int months = int.Parse(Console.ReadLine());
            for (int i = 1; i <= months; i++)
            {
                double sPercent = sComplex * 0.03;
                s = s + sPercent;
            }
            for (int j = 1; j <= months; j++)
            {
                double lastMonthMoney = sComplex * 0.027;
                sComplex = sComplex + lastMonthMoney;
            }
            Console.WriteLine($"Simple interest rate: {s:f2} lv.");
            Console.WriteLine($"Complex interest rate: {sComplex:f2} lv.");
            double differance = s - sComplex;
            if (s > sComplex){
                Console.WriteLine($"Choose a simple interest rate. You will win {differance:f2} lv.");
            }else
            {
                Console.WriteLine($"Choose a complex interest rate. You will win {Math.Abs(differance):f2} lv.");
            }
        }
    }
}
