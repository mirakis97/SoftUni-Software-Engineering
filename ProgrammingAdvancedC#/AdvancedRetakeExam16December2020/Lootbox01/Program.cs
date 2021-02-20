using System;
using System.Collections.Generic;
using System.Linq;

namespace Lootbox01
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> firstLootBox = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
            Stack<int> secondLootBox = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());

            int collection = 0;
            while (true)
            {
                if (firstLootBox.Count == 0)
                {
                    break;
                }
                else if (secondLootBox.Count == 0)
                {
                    break;
                }
                int firstItem = firstLootBox.Peek();
                int secondItem = secondLootBox.Peek();

                int sum = firstItem + secondItem;

                if (sum % 2 == 0)
                {
                    collection += sum;
                    firstLootBox.Dequeue();
                    secondLootBox.Pop();
                }
                else
                {
                    secondLootBox.Pop();
                    firstLootBox.Enqueue(secondItem);
                }
            }

            if (!firstLootBox.Any())
            {
                Console.WriteLine("First lootbox is empty");
            }
            else if (!secondLootBox.Any())
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (collection >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {collection}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {collection}");
            }
        }
    }
}
