using System;
using System.Collections.Generic;
using System.Text;
using Wild_Farm.Foods;

namespace Wild_Farm.Animals.Birds
{
    public class Owl : Bird
    {
        private const double BaseWeigthModifier = 0.25;
        private static HashSet<string> OwlAllowedFood = new HashSet<string>()
        {
            nameof(Meat)
        };
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, OwlAllowedFood, BaseWeigthModifier, wingSize)
        {
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
