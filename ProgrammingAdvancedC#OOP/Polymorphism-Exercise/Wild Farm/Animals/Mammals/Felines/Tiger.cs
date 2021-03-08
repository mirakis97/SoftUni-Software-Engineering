using System;
using System.Collections.Generic;
using System.Text;
using Wild_Farm.Foods;

namespace Wild_Farm.Animals.Mammals.Felines
{
    public class Tiger : Feline
    {
        private const double BaseWeigthModifier = 1;
        private static HashSet<string> AllowedFood = new HashSet<string>()
        {
            nameof(Meat)
        };
        public Tiger(string name, double weight,string livingRegion, string breed)
            : base(name, weight, AllowedFood, BaseWeigthModifier, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
