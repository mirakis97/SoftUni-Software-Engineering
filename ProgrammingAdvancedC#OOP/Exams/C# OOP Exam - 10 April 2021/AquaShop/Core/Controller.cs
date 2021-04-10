namespace AquaShop.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Models.Aquariums;
    using Models.Aquariums.Contracts;
    using Models.Decorations;
    using Models.Decorations.Contracts;
    using Models.Fish;
    using Models.Fish.Contracts;
    using Repositories;
    using Repositories.Contracts;
    using Utilities.Messages;

    public class Controller : IController
    {
        private readonly IRepository<IDecoration> decorations;
        private readonly List<IAquarium> aquariums;

        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium = null;

            switch (aquariumType)
            {
                case "FreshwaterAquarium":
                    aquarium = new FreshwaterAquarium(aquariumName);
                    break;
                case "SaltwaterAquarium":
                    aquarium = new SaltwaterAquarium(aquariumName);
                    break;
            }

            if (aquarium is null)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            this.aquariums.Add(aquarium);

            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration = null;

            switch (decorationType)
            {
                case "Ornament":
                    decoration = new Ornament();
                    break;
                case "Plant":
                    decoration = new Plant();
                    break;
            }

            if (decoration is null)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            this.decorations.Add(decoration);

            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish = null;
            var aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);

            switch (fishType)
            {
                case "FreshwaterFish":
                    fish = new FreshwaterFish(fishName, fishSpecies, price);
                    break;
                case "SaltwaterFish":
                    fish = new SaltwaterFish(fishName, fishSpecies, price);
                    break;
            }

            if (fish is null)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            var fishWaterType = fish.GetType().Name.Contains("Fresh") ? "Fresh" : "Salt";

            if (!aquarium.GetType().Name.StartsWith(fishWaterType))
            {
                return string.Format(OutputMessages.UnsuitableWater);
            }

            aquarium.AddFish(fish);

            return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
        }

        public string CalculateValue(string aquariumName)
        {
            var aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);

            var sum = aquarium.Fish.Sum(f => f.Price) + aquarium.Decorations.Sum(d => d.Price);

            return string.Format(OutputMessages.AquariumValue, aquariumName, sum);
        }

        public string FeedFish(string aquariumName)
        {
            var aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);

            aquarium.Feed();

            var fishCount = aquarium.Fish.Count;

            return string.Format(OutputMessages.FishFed, fishCount);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var decoration = this.decorations.FindByType(decorationType);

            if (decoration is null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            var aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);

            aquarium.AddDecoration(decoration);
            this.decorations.Remove(decoration);

            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string Report()
        {
            var sb = new StringBuilder();

            foreach (var aquarium in this.aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
