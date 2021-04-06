using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product,IComputer
    {
        private decimal computerPrice;
        private double computerPerformance;
        private List<IComponent> components;
        private List<IPeripheral> peripherals;
        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.computerPrice = price;
            this.computerPerformance = overallPerformance;
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components => this.components;

        public IReadOnlyCollection<IPeripheral> Peripherals => this.peripherals;

        public override double OverallPerformance
        {
            get
            {
                return GetPerformance();
            }
        }

        public override decimal Price
        {
            get
            {
                return GetPrice();
            }
        }
        private double GetPerformance()
        {
            if (components.Count <= 0)
            {
                return computerPerformance;
            }

            return computerPerformance + components.Average(x => x.OverallPerformance);
        }

        private decimal GetPrice()
        {
            return computerPrice + components.Sum(x => x.Price) + peripherals.Sum(x => x.Price);
        }

        public void AddComponent(IComponent component)
        {
            if (components.Any(x => x.GetType() == component.GetType()))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent, component, GetType().Name, Id));
            }

            components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (peripherals.Any(x => x.GetType() == peripheral.GetType()))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheral, peripheral, GetType().Name, Id));
            }

            peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (!components.Any())
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent , componentType,GetType().Name, Id));
            }

            IComponent component = components.First(c => c.GetType().Name == componentType);

            components.Remove(component);

            return component;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (!peripherals.Any())
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent, peripheralType, GetType().Name, Id));
            }

            IPeripheral peripheral = peripherals.First(c => c.GetType().Name == peripheralType);

            peripherals.Remove(peripheral);

            return peripheral;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Overall Performance: {OverallPerformance:f2}. Price: {Price:f2} - {GetType().Name}: {Manufacturer} {Model} (Id: {Id})");
            sb.AppendLine($" Components ({components.Count})");
            foreach (var component in components)
            {
                sb.AppendLine($"  {component}");
            }

            sb.AppendLine($" Peripherals ({peripherals.Count}); Average Overall Performance ({peripherals.Average(x =>x.OverallPerformance):F2}):");

            foreach (var peripheral in peripherals)
            {
                sb.AppendLine($"  {peripheral}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
