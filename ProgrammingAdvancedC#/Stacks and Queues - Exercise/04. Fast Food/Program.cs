using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantityOfFood = int.Parse(Console.ReadLine());

            int[] orders = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> orderQue = new Queue<int>(orders);

            int quantity = 0;
            Console.WriteLine(orderQue.Max());
            while (orderQue.Count > 0)
            {
                int currOrder = orderQue.Peek();
                quantity += currOrder;
                if (quantity <= quantityOfFood)
                {

                    orderQue.Dequeue();
                }
                else
                {
                    int[] arr = orderQue.ToArray();
                    Console.WriteLine($"Orders left: {string.Join(" ", arr)}");
                    return;
                }
            }
            Console.WriteLine("Orders complete");
        }
    }
}
