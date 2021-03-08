﻿using System;
using System.Collections.Generic;
using Wild_Farm.Animals;
using Wild_Farm.Animals.Birds;
using Wild_Farm.Animals.Mammals;
using Wild_Farm.Animals.Mammals.Felines;
using Wild_Farm.Foods;

namespace Wild_Farm
{
   public class Program
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "End")
                {
                    break;
                }
                string[] animalParts = line.Split();

                Animal animal = CreateAnimal(animalParts);
                animals.Add(animal);

                string[] foodParts = Console.ReadLine().Split();

                Food food = CreateFood(foodParts);

                Console.WriteLine(animal.ProduceSound());
                try
                {
                    animal.Eat(food);
                }
                catch (InvalidOperationException ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        private static Food CreateFood(string[] foodParts)
        {
            string type = foodParts[0];
            int quantity = int.Parse(foodParts[1]);

            Food food = null;
            if (type == nameof(Meat))
            {
                food = new Meat(quantity);
            }
            else if (type == nameof(Vegetable))
            {
                food = new Vegetable(quantity);
            }
            else if (type == nameof(Fruit))
            {
                food = new Fruit(quantity);
            }
            else if (type == nameof(Seeds))
            {
                food = new Seeds(quantity);
            }
            return food;
        }

        private static Animal CreateAnimal(string[] parts)
        {
            string type = parts[0];

            Animal animal = null;

            string name = parts[1];
            double weight = double.Parse(parts[2]);

            if (type == nameof(Hen))
            {
                double wingSize = double.Parse(parts[3]);
                animal = new Hen(name,weight,wingSize);
            }
            else if (type == nameof(Owl))
            {
                double wingSize = double.Parse(parts[3]);
                animal = new Owl(name, weight, wingSize);
            }
            else if (type == nameof(Mouse))
            {
                string livingRegion = parts[3];
                animal = new Mouse(name, weight, livingRegion);
            }
            else if (type == nameof(Dog))
            {
                string livingRegion = parts[3];
                animal = new Dog(name, weight, livingRegion);
            }
            else if (type == nameof(Cat))
            {
                string livingRegion = parts[3];
                string breed = parts[4];

                animal = new Cat(name, weight, livingRegion,breed);
            }
            else if (type == nameof(Tiger))
            {
                string livingRegion = parts[3];
                string breed = parts[4];

                animal = new Tiger(name, weight, livingRegion, breed);
            }
            return animal;
        }
    }
}
