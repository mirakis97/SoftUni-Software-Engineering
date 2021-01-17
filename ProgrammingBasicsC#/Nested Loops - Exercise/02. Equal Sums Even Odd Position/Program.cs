using System;

namespace _02._Equal_Sums_Even_Odd_Position
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            for (int i = num1; i <= num2; i++)
            {
                int curNum = i;
                int evenSum = 0;
                int oddSum = 0;
                int count = 0;
                while (curNum != 0)
                {
                    int digit = curNum % 10;
                    if (count % 2 == 0)
                    {
                        evenSum += digit;
                    }
                    else
                    {
                        oddSum += digit;
                    }
                    curNum = curNum / 10;
                    count++;
                }
                if (evenSum == oddSum)
                { 
                    Console.Write(i + " ");
                }
            }
        }
    }
}
