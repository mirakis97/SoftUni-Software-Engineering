using System;

namespace _05._Account_Balance
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double savedMoney = 0;

            while (input != "NoMoreMoney")
            {
                double inputMoney = double.Parse(input);

                if (inputMoney < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                savedMoney += inputMoney;
                Console.WriteLine($"Increase: {inputMoney:f2}");
                input = Console.ReadLine();
            }

            Console.WriteLine($"Total: {savedMoney:f2}");
        }
    }
}
