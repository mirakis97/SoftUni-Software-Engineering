using System;
using System.Collections.Generic;
using System.Text;
using Wild_Farm.Foods;

namespace Wild_Farm.Animals
{
    public abstract class Animal
    {
        protected Animal(string name,double weight,HashSet<string> allowedFoods,double weightModifier)
        {
            this.Name = name;
            this.Weight = weight;
            this.AllowedFoods = allowedFoods;
            this.WeightModifier = weightModifier;
        }
        private HashSet<string> AllowedFoods { get; set; }
        private double WeightModifier { get; set; }
        public string Name { get; private set; }
        public double Weight { get; private set; }
        public int  FoodEaten { get; private set; }

        public abstract string ProduceSound();

        public void Eat(Food food)
        {
            string foodTypeName = food.GetType().Name;
            if (!AllowedFoods.Contains(foodTypeName))
            {
                throw new InvalidOperationException($"{this.GetType().Name} does not eat {foodTypeName}!");
            }

            this.FoodEaten += food.Quantity;

            this.Weight += this.WeightModifier * food.Quantity;
        }
    

    }
}
