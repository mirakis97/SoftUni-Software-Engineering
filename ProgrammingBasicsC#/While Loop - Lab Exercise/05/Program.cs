using System;

namespace _05
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            double convert = money * 100;
            int cent = (int)convert;
            int coins = 0;
            while (cent > 0)
            {
                if (cent - 200 >= 0)
                {
                    coins++;
                    cent -= 200;
                }
                else if (cent - 100 >= 0)
                {
                    coins++;
                    cent -= 100;
                }
                else if (cent - 50 >= 0)
                {
                    coins++;
                    cent -= 50;
                }
                else if (cent - 20 >= 0)
                {
                    coins++;
                    cent -= 20;
                }
                else if (cent - 10 >= 0)
                {
                    coins++;
                    cent -= 10;
                }    
                else if (cent - 5 >= 0)
                {
                    coins++;
                    cent -= 5;
                }
                else if (cent - 2 >= 0)
                {
                    coins++;
                    cent -= 2;
                }
                else if (cent - 1 >= 0)
                {
                    coins++;
                    cent -= 1;
                }
            }
            Console.WriteLine(coins);
        }
    }
}
