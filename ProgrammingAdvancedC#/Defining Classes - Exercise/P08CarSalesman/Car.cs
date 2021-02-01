using System;
using System.Collections.Generic;
using System.Text;

namespace P08CarSalesman
{
    public class Car
    {
        private string model;
        private Engine engine;
        private int weight;
        private string color;
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
        }

        public Car(string model, Engine engine, int weight)
            : this(model, engine)
        {
            this.Weight = weight;
        }
        public Car(string model, Engine engine, string color)
            : this(model, engine)
        {
            this.Color = color;
        }
        public Car(string model, Engine engine, int weight, string color)
            : this(model, engine, weight)
        {
            this.Color = color;
        }

        public static Car CreateCar(string[] carInfo, Engine engine)
        {
            Car car = null;
            string model = carInfo[0];

            if (carInfo.Length == 2)
            {
                car = new Car(model, engine);
            }
            else if (carInfo.Length == 3)
            {
                if (char.IsDigit(carInfo[2][0]))
                {
                    int weight = int.Parse(carInfo[2]);
                    car = new Car(model, engine, weight);
                }
                else
                {
                    string color = carInfo[2];
                    car = new Car(model, engine, color);
                }
            }

            else if (carInfo.Length == 4)
            {
                int weight = int.Parse(carInfo[2]);
                string color = carInfo[3];
                car = new Car(model, engine, weight, color);
            }
            return car;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Model}:");
            sb.AppendLine($"  {this.Engine.Model}:");
            sb.AppendLine($"    Power: {this.Engine.Power}");

            if (this.Engine.Displacment == 0)
            {
                sb.AppendLine($"    Displacement: n/a");
            }
            else
            {
                sb.AppendLine($"    Displacement: {this.Engine.Displacment}");
            }

            if (this.Engine.Efficiency == null)
            {
                sb.AppendLine($"    Efficiency: n/a");
            }
            else
            {
                sb.AppendLine($"    Efficiency: {this.Engine.Efficiency}");
            }

            if (this.Weight == 0)
            {
                sb.AppendLine($"  Weight: n/a");
            }
            else
            {
                sb.AppendLine($"  Weight: { this.Weight}");
            }

            if (this.Color == null)
            {
                sb.Append($"  Color: n/a");
            }
            else
            {
                sb.Append($"  Color: {this.Color}");
            }

            return sb.ToString();
        }
    }
}
