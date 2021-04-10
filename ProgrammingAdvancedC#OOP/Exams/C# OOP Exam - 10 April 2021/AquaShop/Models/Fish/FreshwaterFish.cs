using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public class FreshwaterFish : Fish
    {
        private const int size = 3;
        public FreshwaterFish(string name, string species, decimal price)
            : base(name, species, price)
        {
            this.Size = size;
        }
        public override int Size { get; protected set; }

        public override void Eat()
        {
            this.Size += size;
        }
    }
}
