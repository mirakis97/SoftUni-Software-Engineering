using System;

namespace _06._Strong_number
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            int number = input;
            int curentNum = 0;
            int factiorilSum = 0;

            while (number != 0)
            {
                curentNum = number % 10;
                number /= 10;

                int factiral = 1;
                for (int i = 1; i <= curentNum; i++)
                {
                    factiral *= i;
                }
                factiorilSum += factiral;
            }

            string result = string.Empty;

            if (input == factiorilSum)
            {
                result = "yes";
            }
            else
            {
                result = "no";
            }
            Console.WriteLine(result);
        }
    }
}
