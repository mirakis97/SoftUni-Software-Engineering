using System;
using System.Collections.Generic;
using System.Text;
using Wild_Farm.Foods;

namespace Wild_Farm.Animals.Mammals
{
   public class Dog : Mammal
    {
        private const double BaseWeigthModifier = 0.4;
        private static HashSet<string> AllowedFood = new HashSet<string>()
        {
            nameof(Meat)
        };
        public Dog(string name, double weight,string livingRegion)
            : base(name, weight, AllowedFood, BaseWeigthModifier, livingRegion)
        {
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
