using System;

namespace _2.EnterNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ReadNumber(1, 100);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void ReadNumber(int start, int end)
        {
            int n = 0;

            for (int i = 0; i < 100; i++)
            {
                int n2 = int.Parse(Console.ReadLine());
                if (i == 0)
                {
                    n = n2;
                }
                if (n < n2 || n < start || n > end)
                {
                    throw new ArgumentOutOfRangeException("Invalid number");
                }
            }
        }
    }
}
