using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private const int DefaultCapacity = 100;
        private int capacity;
        private int load;
        private ICollection<Item> item;
        protected Bag(int capacity)
        {
            this.capacity = capacity;
            this.item = new List<Item>();
        }
        public int Capacity
        {
            get { return this.capacity; }
            set
            {
                if (value < 0 || value > DefaultCapacity)
                {
                    this.capacity = DefaultCapacity;
                }
                else
                {
                    this.capacity = value;
                }
            }
        }

        public int Load => this.Items.Sum(i => i.Weight);

        public IReadOnlyCollection<Item> Items => this.item.ToList().AsReadOnly();
        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }

            this.item.Add(item);
        }

        public Item GetItem(string name)
        {
            if (!this.item.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }
            if (!this.item.Any(x => x.GetType().Name == name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag,name));
            }

            Item item = this.item.FirstOrDefault(x => x.GetType().Name == name);

            return item;
        }
    }
}
