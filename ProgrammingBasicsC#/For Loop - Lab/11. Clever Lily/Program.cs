using System;

namespace _11._Clever_Lily
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double priceForMashine = double.Parse(Console.ReadLine());
            double priceOfToys = double.Parse(Console.ReadLine());

            int toyCount = 0;
            double savedMoney = 0;
            int temp = 10;
            for (int i = 1; i <= age; i++)
            {
                if (i % 2 != 0)
                {
                    toyCount++;
                }
                else
                {
                    savedMoney += temp;
                    temp += 10;
                }
            }
            savedMoney -= age / 2;

            savedMoney += toyCount * priceOfToys;

            double leftMoney = Math.Abs(savedMoney - priceForMashine);

            if (savedMoney >= priceForMashine)
            {
                Console.WriteLine($"Yes! {leftMoney:f2}");
            }
            else
            {
                Console.WriteLine($"No! {leftMoney:f2}");
            }
        }
    }
}
