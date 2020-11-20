using System;

namespace _03.DepositCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            double deposit = double.Parse(Console.ReadLine());
            int depositDue = int.Parse(Console.ReadLine());
            double yearInterest = double.Parse(Console.ReadLine());
            //Calcultions
            double interstAmount = (deposit * yearInterest) / 100;
            double monthlyInterest = interstAmount / 12;
            double totalSum = deposit + depositDue * monthlyInterest;
            //Output
            Console.WriteLine($"{totalSum}");



        }
    }
}
