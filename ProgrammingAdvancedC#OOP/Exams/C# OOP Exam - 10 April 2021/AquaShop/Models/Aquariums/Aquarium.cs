namespace AquaShop.Models.Aquariums
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Aquariums.Contracts;
    using Decorations.Contracts;
    using Fish.Contracts;
    using Utilities.Messages;

    public abstract class Aquarium : IAquarium
    {
        private readonly ICollection<IDecoration> decorations;
        private readonly ICollection<IFish> fish;
        private string name;

        protected Aquarium(int capacity, string name)
        {
            this.Capacity = capacity;
            this.Name = name;
            this.decorations = new List<IDecoration>();
            this.fish = new List<IFish>();
        }

        public int Capacity { get; }

        public int Comfort => this.Decorations.Sum(d => d.Comfort);

        public ICollection<IDecoration> Decorations => this.decorations.ToList().AsReadOnly();

        public ICollection<IFish> Fish => this.fish.ToList().AsReadOnly();

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }

                this.name = value;
            }
        }

        public void AddDecoration(IDecoration decoration) => this.decorations.Add(decoration);

        public void AddFish(IFish fish)
        {
            if (this.Fish.Count + 1 > this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            this.fish.Add(fish);
        }

        public void Feed()
        {
            foreach (var fish in this.Fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");

            if (this.Fish.Count == 0)
            {
                sb.AppendLine("Fish: none");
            }
            else
            {
                sb.AppendLine($"Fish: {string.Join(", ", this.Fish.Select(f => f.Name))}");
            }

            sb.AppendLine($"Decorations: {this.Decorations.Count}");
            sb.AppendLine($"Comfort: {this.Comfort}");

            return sb.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish) => this.Fish.Remove(fish);
    }
}
