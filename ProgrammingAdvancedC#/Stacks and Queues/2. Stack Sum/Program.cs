using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>(numbers);
            string cmd = Console.ReadLine().ToLower();

            while (cmd !="end")
            {
                if (cmd.Contains("add"))
                {
                    var splitted = cmd.Split();
                    stack.Push(int.Parse(splitted[1]));
                    stack.Push(int.Parse(splitted[2]));
                }
                if (cmd.Contains("remove"))
                {
                    var splitted = cmd.Split();
                    var count = int.Parse(splitted[1]);

                    if (count <= stack.Count)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            stack.Pop();
                        }
                    }
                }


                cmd = Console.ReadLine();
            }
            Console.WriteLine("Sum: " + stack.Sum());
        }
    }
}
