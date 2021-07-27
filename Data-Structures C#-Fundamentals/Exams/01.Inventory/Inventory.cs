namespace _01.Inventory
{
    using _01.Inventory.Interfaces;
    using _01.Inventory.Models;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Inventory : IHolder
    {
        private List<IWeapon> weapons;
        public Inventory()
        {
            weapons = new List<IWeapon>();
        }
        public int Capacity => weapons.Count;

        public void Add(IWeapon weapon)
        {
            weapons.Add(weapon);
        }

        public void Clear()
        {
            weapons.Clear();
        }

        public bool Contains(IWeapon weapon)
        {
            var elementIndex = FindById(weapon.Id);

            if (elementIndex == null)
            {
                return false;
            }

            return true;
        }

        public void EmptyArsenal(Category category)
        {
            List<IWeapon> withoutSold = new List<IWeapon>();

            for (int i = 0; i < weapons.Count; i++)
            {
                if (weapons[i].Category != category)
                {
                    withoutSold.Add(weapons[i]);
                }
            }
            weapons = withoutSold;
        }

        public bool Fire(IWeapon weapon, int ammunition)
        {
            var index = this.FindById(weapon.Id);
            this.EnsureIndexIsCorrect(index.Id);

            if (weapons[index.Id].Ammunition - ammunition >= 0)
            {
                weapons[index.Id].Ammunition -= ammunition;
                return true;
            }

            return false;

        }

        public IWeapon GetById(int id)
        {
            IWeapon weapon = FindById(id);
            if (weapon == null)
            {
                return null;
            }
            return weapon;
        }

        public IEnumerator GetEnumerator()
        {
            return weapons.GetEnumerator();
        }

        public int Refill(IWeapon weapon, int ammunition)
        {
            var index = this.FindById(weapon.Id);
            this.EnsureIndexIsCorrect(index.Id);

            if (weapons[index.Id].Ammunition + ammunition >= weapons[index.Id].MaxCapacity)
            {
                weapons[index.Id].Ammunition = weapons[index.Id].MaxCapacity;
            }
            else
            {
                weapons[index.Id].Ammunition += ammunition;
            }
            return weapons[index.Id].Ammunition;
        }

        public IWeapon RemoveById(int id)
        {
            IWeapon entity = FindById(id);
            if (entity != null)
            {
                weapons.Remove(entity);
            }
            else
            {
                return null;
            }

            return entity;
        }

        public int RemoveHeavy()
        {
            int count = weapons.RemoveAll(w => w.Category == Category.Heavy);
            return count;
        }

        public List<IWeapon> RetrieveAll()
        {
            return new List<IWeapon>(weapons);
        }

        public List<IWeapon> RetriveInRange(Category lower, Category upper)
        {
            List<IWeapon> inBount = new List<IWeapon>();

            for (int i = 0; i < weapons.Count; i++)
            {
                if (weapons[i].Category >= lower && weapons[i].Category <= upper)
                {
                    inBount.Add(weapons[i]);
                }
            }
            return inBount;
        }

        public void Swap(IWeapon firstWeapon, IWeapon secondWeapon)
        {
            var firstEntitiyIndex = weapons.IndexOf(firstWeapon);
            var secondEntitiyIndex = weapons.IndexOf(secondWeapon);

            CheckValidIndex(firstEntitiyIndex, "Weapon does not exist in inventory!");
            CheckValidIndex(secondEntitiyIndex, "Weapon does not exist in inventory!");
            if (firstWeapon.Category == secondWeapon.Category)
            {
                IWeapon temp = weapons[firstEntitiyIndex];
                weapons[firstEntitiyIndex] = weapons[secondEntitiyIndex];
                weapons[secondEntitiyIndex] = temp;
            }
            
        }

        private IWeapon FindById(int id)
        {

            for (int i = 0; i < weapons.Count; i++)
            {
                if (weapons[i].Id == id)
                {
                    return weapons[i];
                }
            }

            return null;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return weapons.GetEnumerator();
        }
     
        private void CheckValidIndex(int index, string message)
        {
            if (index < 0 || index >= this.Capacity)
            {
                throw new InvalidOperationException(message);
            }
        }
        private void EnsureIndexIsCorrect(int id)
        {
            if (id < 0 || id >= this.Capacity)
            {
                throw new InvalidOperationException("Weapon does not exist in inventory!");
            }
        }
    }
}
