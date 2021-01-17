using System;

namespace _03._Sum_Prime_Non_Prime
{
    class Program
    {
        static void Main(string[] args)
        {
            string comand = Console.ReadLine();
            int primeNumber = 0;
            int nonPrimeNum = 0;

            while (comand != "stop")
            {
                int num = int.Parse(comand);
                int count = 0;
                if (num < 0)
                {
                    Console.WriteLine("Number is negative.");
                    comand = Console.ReadLine();
                    continue;
                }
                for (int i = 2; i < num; i++)
                {
                    if  (num % i == 0)
                    {
                        count++;
                        break;
                    }
                }
                if (num != 1 && count == 0)
                {
                    primeNumber += num;
                }
                else
                {
                    nonPrimeNum += num;
                }
                comand = Console.ReadLine();
            }
            Console.WriteLine($"Sum of all prime numbers is: {primeNumber}");
            Console.WriteLine($"Sum of all non prime numbers is: {nonPrimeNum}");
        }
    }
}
