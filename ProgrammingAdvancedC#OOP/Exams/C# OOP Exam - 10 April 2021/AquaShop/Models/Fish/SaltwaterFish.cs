using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public class SaltwaterFish : Fish
    {
        private const int InitialSize = 5;
        private const int IncreasesSizePoint = 2;
        public SaltwaterFish(string name, string species, decimal price)
            : base(name, species, price)
        {
            this.Size = InitialSize;
        }
        public override int Size { get; protected set; }

        public override void Eat()
        {
            this.Size += IncreasesSizePoint;
        }
    }
}
