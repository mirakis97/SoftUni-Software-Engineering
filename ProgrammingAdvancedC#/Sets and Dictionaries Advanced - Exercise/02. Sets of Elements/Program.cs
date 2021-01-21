using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] n = Console.ReadLine().Split().Select(int.Parse).ToArray() ;

            int num1 = n[0];
            int num2 = n[1];
            HashSet<int> hashSetOne = new HashSet<int>();
            HashSet<int> hashSetTwo = new HashSet<int>();

            for (int i = 0; i < num1 ; i++)
            {
                int num3 = int.Parse(Console.ReadLine());
                hashSetOne.Add(num3);
                
            }
            for (int j = 0; j < num2; j++)
            {
                int num4 = int.Parse(Console.ReadLine());
                hashSetTwo.Add(num4);
            }

            foreach (var num in hashSetOne)
            {
                if (hashSetTwo.Contains(num))
                {
                    Console.Write($"{num} ");
                }
            }
        }
    }
}
