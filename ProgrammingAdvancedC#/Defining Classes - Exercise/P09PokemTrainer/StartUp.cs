using System;
using System.Collections.Generic;
using System.Linq;

namespace P09PokemTrainer
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            string input = Console.ReadLine();

            while (input != "Tournament")
            {
                string[] cmd = input.Split();
                string name = cmd[0];
                string pokemonName = cmd[1];
                string element = cmd[2];
                int health = int.Parse(cmd[3]);

                if (trainers.Exists(t=>t.Name == name)== false)
                {
                    Trainer trainer = new Trainer(name);
                    trainers.Add(trainer);
                }

                Pokemon pokemon = new Pokemon(pokemonName,element,health);

                trainers.Find(t => t.Name == name).Pokemons.Add(pokemon);
                input = Console.ReadLine();
            }

            string comand = string.Empty;

            while ((comand = Console.ReadLine()) != "End")
            {


                foreach (var trainer in trainers)
                {
                    trainer.Comand(comand);
                }
            }

            foreach (var trainer in trainers.OrderByDescending(t => t.BadgesNumber))
            {
                Console.WriteLine($"{trainer.Name} {trainer.BadgesNumber} {trainer.Pokemons.Count}");
            }

        }
    }
}
