using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern
{
    public class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public Product(string name, int price)
        {
            this.Name = name;
            this.Price = price;
        }

        public void IncreasePrice(int amount)
        {
            this.Price += amount;
            Console.WriteLine($"This price for the {Name} has been increased by {amount}$.");
        }

        public void DecreasePrice(int amount)
        {
            if (amount < this.Price)
            {
                this.Price -= amount;
                Console.WriteLine($"This price for the {Name} has been decreased by {amount}$.");
            }
        }

        public override string ToString() => $"Current price for the {Name} product is {Price}$.";
        
    }
}
