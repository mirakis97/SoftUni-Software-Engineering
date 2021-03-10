using System;

namespace _5._Convert.ToDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            try
            {
                double result = Convert.ToDouble(input);
                Console.WriteLine(result);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}
