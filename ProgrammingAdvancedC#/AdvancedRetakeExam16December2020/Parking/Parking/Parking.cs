using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Parking
{
   public class Parking
    {
        private List<Car> cars;

        public string Type { get; set; }
        public int Capacity { get; set; }
        
        public Parking(string type,int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            this.cars = new List<Car>(Capacity);
        }
        public int Count { get => cars.Count; }
        public void Add(Car car)
        {
            if (this.cars.Count < this.Capacity)
            {
                cars.Add(car);
            }
        }
        public bool Remove(string manufacturer,string model)
        {
            Car carToBeRemoved = this.cars.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);
            if (cars.Contains(carToBeRemoved))
            {
                this.cars.Remove(carToBeRemoved);
                return true;
            }

                return false;
        }
        public Car GetLatestCar()
        {
            if (cars.Count > 0)
            {
                return cars.OrderByDescending(c=>c.Year).First();
            }
            return null;
        }
        public Car GetCar(string manufacturer,string model)
        {
            if (this.cars.Exists(c => c.Manufacturer == manufacturer && c.Model == model))
            {
                return this.cars.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);
            }
            else
            {
                return null;
            }
        }
        public string GetStatistics()
        {
            var result = new StringBuilder();
            result.AppendLine($"The cars are parked in {Type}:");
            foreach (var car in this.cars)
            {
                result.AppendLine($"{car}");
            }
            return result.ToString().Trim();
        }
    }
}
