using System;
using System.Collections.Generic;
using System.Linq;

namespace Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> liquids = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray()); 
            Stack<int> ingredients = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());

            int bread = 25;
            int cake = 50;
            int pastry = 75;
            int fruitPie = 100;

            int breadCount = 0;
            int cakeCount = 0;
            int pastryCount = 0;
            int fruitPieCount = 0;
            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                int liquit = liquids.Peek();
                int ingredient = ingredients.Peek();

                int sum = liquit + ingredient;

                if (sum == bread)
                {
                    breadCount++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else if (sum == cake)
                {
                    cakeCount++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else if (sum == pastry)
                {
                    pastryCount++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else if (sum == fruitPie)
                {
                    fruitPieCount++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else
                {
                    liquids.Dequeue();
                    ingredients.Pop();
                    ingredients.Push(ingredient += 3);
                }
            }

            if (breadCount > 0 && cakeCount > 0 && pastryCount > 0 && fruitPieCount > 0)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (!liquids.Any())
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }

            if (!ingredients.Any())
            {
                Console.WriteLine("Ingredients left: none");
            }
            else
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
            }
            Console.WriteLine($"Bread: {breadCount}");
            Console.WriteLine($"Cake: {cakeCount}");
            Console.WriteLine($"Fruit Pie: {fruitPieCount}");
            Console.WriteLine($"Pastry: {pastryCount}");
        }
    }
}
