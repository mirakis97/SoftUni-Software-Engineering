using System;

namespace Nested_Loops___Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int currentNum = 1;
            bool isNum = false;

            for (int rows  = 1; rows  <= num; rows ++)
            {
                for (int colls   = 1; colls <= rows; colls++)
                {
                    if (currentNum > num)
                    {
                        isNum = true;
                        break;
                    }
                    Console.Write(currentNum + " ");
                    currentNum++;
                }
                if (isNum)
                {
                    break;
                }
                Console.WriteLine();
            }
        }
    }
}
