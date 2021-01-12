using System;
using System.Collections;
using System.Collections.Generic;

namespace _7._Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] children = Console.ReadLine().Split();

            int n = int.Parse(Console.ReadLine());
            Queue<string> potatoQueue = new Queue<string>(children);
            int potatosTosses = 0;

            while (potatoQueue.Count > 1)
            {
                potatosTosses++;
                string kid = potatoQueue.Dequeue();
                if (potatosTosses == n)
                {
                    potatosTosses = 0;
                    Console.WriteLine("Removed " + kid);
                }
                else
                {
                    potatoQueue.Enqueue(kid);
                }
            }

            Console.WriteLine("Last is " + potatoQueue.Dequeue());
        }
    }
}
