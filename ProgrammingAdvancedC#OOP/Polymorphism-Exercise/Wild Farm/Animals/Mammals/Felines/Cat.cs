using System;
using System.Collections.Generic;
using System.Text;
using Wild_Farm.Foods;

namespace Wild_Farm.Animals.Mammals.Felines
{
    public class Cat : Feline
    {
        private const double BaseWeigthModifier = 0.3;
        private static HashSet<string> AllowedFood = new HashSet<string>()
        {
            nameof(Meat),
            nameof(Vegetable)
        };
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, AllowedFood, BaseWeigthModifier, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
