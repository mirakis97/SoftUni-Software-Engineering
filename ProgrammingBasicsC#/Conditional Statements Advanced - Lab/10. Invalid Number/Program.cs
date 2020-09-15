using System;

namespace _10._Invalid_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            bool isValid = number1 >= 100 && number1 <= 200 || number1 == 0;

            if (!isValid)
            {
                Console.WriteLine("invalid");
            }
        }
    }
}
