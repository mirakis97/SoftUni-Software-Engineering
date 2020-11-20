using System;
using System.Linq;

namespace _02._MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            int health = 100;
            int bitcoin = 0;
            string[] room = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            

            for (int i = 0; i < room.Length; i++)
            {
                string[] roomSplit = room[i].Split().ToArray();
                string comand = roomSplit[0];
                int amount = int.Parse(roomSplit[1]);
                switch (comand)
                {
                    case "potion":
                        int curentHealth = health;
                        curentHealth += amount;
                        if (curentHealth > health)
                        {
                            int totalHealth = curentHealth - health;
                            
                            Console.WriteLine($"You healed for {totalHealth} hp.");
                            Console.WriteLine($"Current health: {health + 10} hp.");
                        }
                        
                        break;
                    case "chest":
                        bitcoin += amount;
                        Console.WriteLine($"You found {amount} bitcoins.");
                        break;
                    default:
                        string monster = comand;
                        health -= amount;
                        
                        if (health < 0)
                        {
                            Console.WriteLine($"You died! Killed by {monster}.");
                            Console.WriteLine($"Best room: {i + 1}");
                            Environment.Exit(0);
                        }
                        else
                        {
                            Console.WriteLine($"You slayed {monster}.");
                        }

                        break;
                }
            }
            Console.WriteLine($"You've made it!");
            Console.WriteLine($"Bitcoins: {bitcoin}");
            Console.WriteLine($"Health: {health}");
        }
    }
}
