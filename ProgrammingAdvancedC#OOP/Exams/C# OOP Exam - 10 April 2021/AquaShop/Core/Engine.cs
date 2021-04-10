namespace AquaShop.Core
{
    using System;

    using Core.Contracts;
    using IO;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;
        private IController controller;

        public Engine()
        {
            this.writer = new Writer();
            this.reader = new Reader();
            this.controller = new Controller();
        }

        public void Run()
        {
            while (true)
            {
                string[] input = this.reader.ReadLine().Split();

                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }

                try
                {
                    string result = string.Empty;

                    if (input[0] == "AddAquarium")
                    {
                        string aquariumType = input[1];
                        string aquariumName = input[2];

                        result = this.controller.AddAquarium(aquariumType, aquariumName);
                    }
                    else if (input[0] == "AddDecoration")
                    {
                        string decorationType = input[1];

                        result = this.controller.AddDecoration(decorationType);
                    }
                    else if (input[0] == "InsertDecoration")
                    {
                        string aquariumName = input[1];
                        string decorationType = input[2];

                        result = this.controller.InsertDecoration(aquariumName, decorationType);
                    }
                    else if (input[0] == "AddFish")
                    {
                        string aquariumName = input[1];
                        string fishType = input[2];
                        string fishName = input[3];
                        string fishSpecies = input[4];
                        decimal price = decimal.Parse(input[5]);

                        result = this.controller.AddFish(aquariumName, fishType, fishName, fishSpecies, price);
                    }
                    else if (input[0] == "FeedFish")
                    {
                        string aquariumName = input[1];

                        result = this.controller.FeedFish(aquariumName);
                    }
                    else if (input[0] == "CalculateValue")
                    {
                        string aquariumName = input[1];

                        result = this.controller.CalculateValue(aquariumName);
                    }
                    else if (input[0] == "Report")
                    {
                        result = this.controller.Report();
                    }

                    this.writer.WriteLine(result);
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
