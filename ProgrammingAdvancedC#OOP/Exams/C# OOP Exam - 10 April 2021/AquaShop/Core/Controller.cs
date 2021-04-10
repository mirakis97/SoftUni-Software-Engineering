using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Repositories.Contracts;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private IRepository<IDecoration> decorations;
        private List<IAquarium> aquariums;
        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium = null;


            if (aquariumType == "FreshwaterAquarium")

            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidAquariumType);
            }

            aquariums.Add(aquarium);

            return $"Successfully added {aquariumType}.";
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration = null;


            if (decorationType == "Ornament")

            {
                decoration = new Ornament();
            }
            else if (decorationType == "Plant")
            {
                decoration = new Plant();
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidDecorationType);
            }

            this.decorations.Add(decoration);

            return $"Successfully added {decorationType}.";
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
            var aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);

            var fishPrice = aquarium.Fish.Sum(x => x.Price);
            var decorationPrice = aquarium.Decorations.Sum(x => x.Price);

            var result = fishPrice + decorationPrice;

            return $"The value of Aquarium {aquariumName} is {result:f2}.";
        }

        public string FeedFish(string aquariumName)
        {
            var aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);

            aquarium.Feed();
            var count = aquarium.Fish.Count();
            return $"Fish fed: {count}";
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var decoration = this.decorations.FindByType(decorationType);

            if (decoration is null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }
            var aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);

            aquarium.AddDecoration(decoration);
            this.decorations.Remove(decoration);

            return $"Successfully added {decorationType} to {aquariumName}.";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var aquaruim in aquariums)
            {
                sb.AppendLine(aquaruim.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public void Exit()
        {
            Environment.Exit(0);
        }
    }
}
