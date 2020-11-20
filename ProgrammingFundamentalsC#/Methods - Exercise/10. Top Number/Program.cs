using System;

namespace _10._Top_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            PrintTopInteger(num);
        }

        private static void PrintTopInteger(int num)
        {
            for (int i = 0; i <= num; i++)
            {
                string curentNum = i.ToString();
                bool isOddDigit = false;
                int sumOfDigits = 0;

                foreach (var cur in curentNum)
                {
                    int parseNum = (int)cur;

                    if (parseNum % 2 == 1)
                    {
                        isOddDigit = true; 
                    }
                    sumOfDigits += parseNum;
                }

                if (sumOfDigits % 8 == 0 && isOddDigit)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
