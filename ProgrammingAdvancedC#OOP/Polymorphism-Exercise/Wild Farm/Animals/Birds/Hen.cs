using System;
using System.Collections.Generic;
using System.Text;
using Wild_Farm.Foods;

namespace Wild_Farm.Animals.Birds
{
   public class Hen : Bird
    {
        private const double BaseWeigthModifier = 0.35;
        private static HashSet<string> HenAllowedFood = new HashSet<string>()
        {
            nameof(Meat),
            nameof(Vegetable),
            nameof(Fruit),
            nameof(Seeds)

        };
        public Hen(string name, double weight,double wingSize)
            : base(name, weight, HenAllowedFood, BaseWeigthModifier, wingSize)
        {
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
