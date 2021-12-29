using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Sum_of_Coins
{
    public class Program
    {
        static void Main(string[] args)
        {
            var coins = new Queue<int>(Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .OrderByDescending(x => x));

            var target = int.Parse(Console.ReadLine());
            var selectedCoins = new Dictionary<int, int>();
            var totalCoins = 0;

            while (target > 0 && coins.Count > 0)
            {
                var currentCoin = coins.Dequeue();
                var count = target / currentCoin;

                if (count == 0)
                {
                    continue;
                }

                selectedCoins[currentCoin] = count;
                totalCoins += count;

                target %= currentCoin;
            }
            if (target == 0)
            {
                Console.WriteLine($"Number of coins to take: {totalCoins}");

                foreach (var coin in selectedCoins)
                {
                    Console.WriteLine($"{coin.Value} coin(s) with value {coin.Key}");
                }
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
    }
}
