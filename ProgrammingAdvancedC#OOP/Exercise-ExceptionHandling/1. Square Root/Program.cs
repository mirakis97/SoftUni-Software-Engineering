using System;

namespace _1._Square_Root
{
    class Program
    {
        static void Main(string[] args)
        {

            double square = 0.0;
            try
            {
                int n = int.Parse(Console.ReadLine());

                square =Sqrt(n);

            }
            catch (FormatException)
            {
                throw new FormatException("Invalid number");
            }
            finally
            {
                
            }
            Console.WriteLine(square);
        }
        public static double Sqrt(double d)
        {
            if (d < 0)

                throw new System.ArgumentOutOfRangeException("value",

                "Invalid number");
            double square = Math.Sqrt(d);
            return square;
        }
    }
}
