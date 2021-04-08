using System;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;
        private double health;
        private double armor;
        protected Character(string name, double baseHealth, double baseArmor, double abilityPoints, Bag bag)
        {
            this.Name = name;

            this.BaseHealth = baseHealth;

            this.BaseArmor = baseArmor;

            this.Health = BaseHealth;

            this.AbilityPoints = abilityPoints;

            this.Armor = BaseArmor;

            this.Bag = bag;
        }

        public string Name
        {
            get { return this.name; }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                this.name = value;
            }
        }
        public double BaseHealth { get; }
        public double BaseArmor { get; }
        public double Health
        {
            get { return this.health; }
            set
            {
                if (value > this.BaseHealth)
                {
                    this.health = this.BaseHealth;
                }
                else if (this.health < 0)
                {
                    this.health = 0;
                }
                else
                {
                    this.health = value;
                }
            }
        }

        public double Armor
        {
            get { return this.armor; }
            private set
            {
                if (value < 0)
                {
                    this.armor = 0;
                }
                else
                {
                    this.armor = value;
                }
            }
        }
        public double AbilityPoints { get; private set; } 
        public IBag Bag { get; private set; }
        public bool IsAlive { get; set; } = true;

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }

        public void TakeDamage(double hitPoints)
        {
            EnsureAlive();
            if (this.Armor < hitPoints)
            {
                hitPoints -= this.Armor;
                this.armor = 0;
                if (this.Health > hitPoints)
                {
                    this.Health -= hitPoints;
                }
                else
                {
                    this.health = 0;
                    this.IsAlive = false;
                }
            }
            else
            {
                this.armor -= hitPoints;
            }
        }
        public void UseItem(Item item)
        {
            EnsureAlive();
            item.AffectCharacter(this);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            string isAlive = this.IsAlive == true ? "Alive" : "Dead";
            sb.AppendLine($"{Name} - HP: {Health}/{BaseHealth}, AP: {Armor}/{BaseArmor}, Status: {isAlive}");
            return sb.ToString().TrimEnd();
        }
    }
}