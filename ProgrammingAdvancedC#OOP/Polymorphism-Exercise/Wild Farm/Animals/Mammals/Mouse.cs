using System;
using System.Collections.Generic;
using System.Text;
using Wild_Farm.Foods;

namespace Wild_Farm.Animals.Mammals
{
    public class Mouse : Mammal
    {
        private const double BaseWeigthModifier = 0.1;
        private static HashSet<string> AllowedFood = new HashSet<string>()
        {
            nameof(Vegetable),
            nameof(Fruit)
        };
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, AllowedFood, BaseWeigthModifier, livingRegion)
        {
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }
    }
}
