using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());

            int[] bulletsInput = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            Stack<int> bullets = new Stack<int>(bulletsInput);

            int[] keysInput = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Queue<int> locks = new Queue<int>(keysInput);

            int intelligenceValue = int.Parse(Console.ReadLine());
            int bulletCount = 0;
            int currGunBarrelSize = gunBarrelSize;

            while (bullets.Any() && locks.Any())
            {
              
                bulletCount++;
                currGunBarrelSize--;
                int currBullet = bullets.Pop();
                int currLock = locks.Peek();

                
                if (currBullet <= currLock)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (currGunBarrelSize == 0 && bullets.Any())
                {

                    currGunBarrelSize = gunBarrelSize;
                    Console.WriteLine("Reloading!");
                }
            }
            if (!locks.Any())
            {
                int moneyEarned = intelligenceValue - (bulletCount * bulletPrice);
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${moneyEarned}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }
    }
}
