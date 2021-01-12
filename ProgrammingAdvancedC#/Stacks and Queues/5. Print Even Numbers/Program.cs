using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] n = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> evenNum = new Queue<int>();

            for (int i = 0; i < n.Length; i++)
            {
                if (n[i] % 2 == 0)
                {
                    evenNum.Enqueue(n[i]);
                }   
            }

            Console.WriteLine(string.Join(", ", evenNum));
        }
    }
}
