using System;

namespace _04._Recursive_Factorial
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(RecursiveFactorial(n));
        }

        private static int RecursiveFactorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            return n * RecursiveFactorial(n - 1);
        }
    }
}
