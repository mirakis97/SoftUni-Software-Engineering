using System;
using System.Collections.Generic;

namespace Raiding
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<BaseHero> heros = new List<BaseHero>();

            int n = int.Parse(Console.ReadLine());

            while (heros.Count < n)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();

                BaseHero hero = CreateHero(type, name);
                if (hero == null)
                {
                    Console.WriteLine("Invalid hero!");
                    continue;
                }
                heros.Add(hero);
            }

            int bossHealtPoints = int.Parse(Console.ReadLine());

            foreach (var hero in heros)
            {
                Console.WriteLine(hero.CastAbility());
                bossHealtPoints -= hero.Power;
            }
            if (bossHealtPoints <= 0)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }

        private static BaseHero CreateHero(string type, string name)
        {
            BaseHero hero = null;
            if (type == nameof(Druid))
            {
                hero = new Druid(name);
            }
            else if (type == nameof(Paladin))
            {
                hero = new Paladin(name);
            }
            else if (type == nameof(Rogue))
            {
                hero = new Rogue(name);
            }
            else if (type == nameof(Warrior))
            {
                hero = new Warrior(name);
            }

            return hero;
        }
    }
}
