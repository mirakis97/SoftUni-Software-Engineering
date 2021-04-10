using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{

    public abstract class Aquarium : IAquarium
    {
        private string name;
        private ICollection<IDecoration> decorations;
        private ICollection<IFish> fish;
        private int currCapacity;
        protected Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.currCapacity = 0;
            this.decorations = new List<IDecoration>();
            this.fish = new List<IFish>();
        }
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

        public int Capacity { get; private set; }

        public int Comfort => this.Decorations.Sum(x => x.Comfort);

        public ICollection<IDecoration> Decorations => this.decorations.ToList().AsReadOnly();

        public ICollection<IFish> Fish => this.fish;

        public void AddDecoration(IDecoration decoration)
        {
            this.decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            currCapacity++;
            if (this.Capacity == this.currCapacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
            this.fish.Add(fish);
        }

        public void Feed()
        {
            foreach (var fish in fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Name} ({GetType().Name}):");
            if (!this.fish.Any())
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

        public bool RemoveFish(IFish fish)
        {
            if (!this.fish.Any(x => x.GetType().Name == fish.GetType().Name))
            {
                return false;
            }
            this.fish.Remove(fish);
            return true;
        }
    }
}
