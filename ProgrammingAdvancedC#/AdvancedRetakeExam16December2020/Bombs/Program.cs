using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> bombEffects = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());
            Stack<int> bombCasing = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());

            int dauturaBombs = 40;
            int cherryBombs = 60;
            int smokeDecoyBombs = 120;
            int dauturaCount = 0;
            int cherryCount = 0;
            int smokeDecoyCount = 0;
            while (bombEffects.Count > 0 && bombCasing.Count > 0)
            {
                int effect = bombEffects.Peek();
                int casing = bombCasing.Peek();
                int sum = effect + casing;
                if (dauturaCount >= 3 && cherryCount >= 3 && smokeDecoyCount >= 3)
                {
                    break;
                }

                if (sum == dauturaBombs)
                {
                    bombEffects.Dequeue();
                    bombCasing.Pop();
                    dauturaCount++;
                }
                else if (sum == cherryBombs)
                {
                    bombEffects.Dequeue();
                    bombCasing.Pop();
                    cherryCount++;
                }
                else if (sum == smokeDecoyBombs)
                {
                    bombEffects.Dequeue();
                    bombCasing.Pop();
                    smokeDecoyCount++;
                }
                else
                {
                    casing -= 5;
                    bombCasing.Pop();
                    bombCasing.Push(casing);
                }
            }

            if (dauturaCount >= 3 && cherryCount >= 3 && smokeDecoyCount >= 3)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (!bombEffects.Any())
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", bombEffects )}");
            }

            if (!bombCasing.Any())
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasing)}");
            }

            Console.WriteLine($"Cherry Bombs: {cherryCount}");
            Console.WriteLine($"Datura Bombs: {dauturaCount}");
            Console.WriteLine($"Smoke Decoy Bombs: {smokeDecoyCount}");
        }
    }
}
