using System;

namespace _06._Max_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int minNumber = int.MaxValue;
            while (name != "Stop")
            {
                int num = int.Parse(name);

                if (num < minNumber)
                {
                    minNumber = num;
                }
                name = Console.ReadLine();
            }
            Console.WriteLine(minNumber);
        }
    }
}
