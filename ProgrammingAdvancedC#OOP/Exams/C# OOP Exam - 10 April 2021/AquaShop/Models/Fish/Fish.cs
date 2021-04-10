namespace AquaShop.Models.Fish
{
    using System;

    using Contracts;
    using Utilities.Messages;

    public abstract class Fish : IFish
    {
        private string name;
        private string species;
        private decimal price;

        protected Fish(string name, string species, decimal price)
        {
            this.Name = name;
            this.Species = species;
            this.Price = price;
            this.Size = 0;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidFishName);
                }

                this.name = value;
            }
        }

        public string Species
        {
            get => this.species;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidFishSpecies);
                }

                this.species = value;
            }
        }

        public abstract int Size { get; protected set; }

        public decimal Price
        {
            get => this.price;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidFishPrice);
                }

                this.price = value;
            }
        }

        public abstract void Eat();
    }
}
