using System;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    int product = j * i;
                    Console.WriteLine($"{i} * {j} = {product}" );
                    
                }
            }
        }
    }
}
