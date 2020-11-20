using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Heroes_of_Code_and_Logic_VII
{
    class Program
    {
        static void Main(string[] args)
        {
            var heroHP = new Dictionary<string, int>();
            var heroMp = new Dictionary<string, int>();

            int n = int.Parse(Console.ReadLine());
            int hpMax = 100;
            int manaMax = 200;

            for (int i = 0; i < n; i++)
            {
                string[] hero = Console.ReadLine().Split();

                string nameHero = hero[0];
                int hp = int.Parse(hero[1]);
                int mp = int.Parse(hero[2]);

                heroHP[nameHero] = hp > hpMax ? hpMax : hp;
                heroMp[nameHero] = mp > manaMax ? manaMax : mp;
            }

            string cmd = Console.ReadLine();

            while (cmd != "End")
            {
                string[] cmndArg = cmd.Split(" - ");
                string comand = cmndArg[0];
                string heroName = cmndArg[1];

                if (comand == "CastSpell")
                {
                    int mpNeeded = int.Parse(cmndArg[2]);
                    string spellName = cmndArg[3];
                    if (heroMp[heroName] >= mpNeeded)
                    {
                        heroMp[heroName] -= mpNeeded;

                        Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {heroMp[heroName]} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                    }
                }

                else if (comand == "TakeDamage")
                {
                    int damage = int.Parse(cmndArg[2]);
                    string attacker = cmndArg[3];

                    heroHP[heroName] -= damage;

                    if (heroHP[heroName] > 0)
                    {
                        Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {heroHP[heroName]} HP left!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} has been killed by {attacker}!");
                        heroHP.Remove(heroName);
                        heroMp.Remove(heroName);
                    }
                }
                else if (comand == "Recharge")
                {
                    int amount = int.Parse(cmndArg[2]);

                    int mpBefore = heroMp[heroName];
                    heroMp[heroName] += amount;
                    if (heroMp[heroName] > manaMax)
                    {
                        heroMp[heroName] = manaMax;
                    }

                    int mpAfter = heroMp[heroName];
                    int totalAmount = mpAfter - mpBefore;
                    Console.WriteLine($"{heroName} recharged for {totalAmount} MP!");
                }
                else if (comand == "Heal")
                {
                    int amount = int.Parse(cmndArg[2]);
                    int hpBefore = heroHP[heroName];

                    heroHP[heroName] += amount;
                    if (heroHP[heroName] > hpMax)
                    {
                        heroHP[heroName] = hpMax;
                    }

                    int hpAfter = heroHP[heroName];
                    int totalAMount = hpAfter - hpBefore;
                    Console.WriteLine($"{heroName} healed for {totalAMount} HP!");
                }


                cmd = Console.ReadLine();
            }
            foreach (var hero in heroHP.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{hero.Key}");
                Console.WriteLine($"HP: {hero.Value}");
                Console.WriteLine($"MP: {heroMp[hero.Key]}");
            }
        }
    }
}