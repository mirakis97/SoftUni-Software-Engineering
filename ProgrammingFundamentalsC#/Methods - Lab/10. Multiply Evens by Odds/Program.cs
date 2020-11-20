using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main()
        {
            int num = Math.Abs(int.Parse(Console.ReadLine()));
            int result = FindResult(num);
            Console.WriteLine(result);
        }
        static int FindResult(int num)
        {
            int rezult = FindSumOfOdds(num) * FindSumOfEvens(num);
            return rezult;
        }

        static int FindSumOfOdds(int num)
        {

            int sumOfOdds = 0;

            while (num != 0)
            {
                int nextNum = num % 10;

                if (nextNum % 2 == 1)
                {
                    sumOfOdds += nextNum;
                }
                num -= nextNum;
                num /= 10;

            }

            return sumOfOdds;
        }

        static int FindSumOfEvens(int num)
        {

            int sumOfEvens = 0;
            while (num != 0)
            {
                int nextNum = num % 10;

                if (nextNum % 2 == 0)
                {
                    sumOfEvens += nextNum;
                }
                num -= nextNum;
                num /= 10;

            }

            return sumOfEvens;
        }
    }
}