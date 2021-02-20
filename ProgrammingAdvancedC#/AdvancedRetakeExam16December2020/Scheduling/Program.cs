using System;
using System.Collections.Generic;
using System.Linq;

namespace Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> task = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());
            Queue<int> threads = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
            int taskToBeKilled = int.Parse(Console.ReadLine());

            while (true)
            {
                int firstTask = task.Peek();
                int firstThread = threads.Peek();

                if (firstTask == taskToBeKilled)
                {
                    Console.WriteLine($"Thread with value {firstThread} killed task {taskToBeKilled}");
                    break;
                }
                else if (firstThread >= firstTask)
                {
                    task.Pop();
                    threads.Dequeue();
                }
                else if (firstThread < firstTask)
                {
                    threads.Dequeue();
                }
            }

            Console.WriteLine(string.Join(" ", threads));
        }
    }
}
