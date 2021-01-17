using System;

namespace _03._Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int sum = 0;

            while (sum < num)
            {
                int inputNumber = int.Parse(Console.ReadLine());

                sum += inputNumber;
            }

            Console.WriteLine(sum);
        }
    }
}
