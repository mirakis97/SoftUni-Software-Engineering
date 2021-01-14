using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothesNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> allClothes = new Stack<int>(clothesNumbers);

            int capacity = int.Parse(Console.ReadLine());
            int currentBoxCap = capacity;
            int count = 1;
            while (allClothes.Any())
            {
                int clothes = allClothes.Pop();
                currentBoxCap -= clothes;

                if (currentBoxCap < 0)
                {
                    count++;
                    currentBoxCap = capacity - clothes;

                }
            }

            Console.WriteLine(count);
        }
    }
}
