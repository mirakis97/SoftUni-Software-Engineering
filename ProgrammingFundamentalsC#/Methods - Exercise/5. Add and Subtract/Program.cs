using System;

namespace _5._Add_and_Subtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());
            int add = 0;
            int substract = 0;
            add = AddSum(firstNum, secondNum);
            substract = SubstractSum(thirdNum, add);
            Console.WriteLine(substract);
        }

        private static int SubstractSum(int firstNum, int susbract)
        {
            int result = susbract - firstNum;
            return result;
        }

        private static int AddSum(int firstNum, int secondNum)
        {
            int result = firstNum + secondNum;
            return result;
        }
    }
}
