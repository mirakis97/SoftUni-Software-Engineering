using System;
using System.Collections.Generic;

namespace _6._Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Queue<string> names = new Queue<string>();
            int count = 0;
            while (input != "End")
            {
                count++;
                if (input == "Paid")
                {
                    Console.WriteLine(string.Join(Environment.NewLine, names));
                    names.Dequeue();
                    count = 0;
                }
                names.Enqueue(input);
                
                

                input = Console.ReadLine();
            }
            Console.WriteLine($"{count} people remaining.");
        }
    }
}
