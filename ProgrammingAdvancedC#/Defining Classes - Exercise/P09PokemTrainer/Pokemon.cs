using System;
using System.Collections.Generic;
using System.Text;

namespace P09PokemTrainer
{
    public class Pokemon
    {
        private string name;
        private string element;
        private int health;

        public string Name { get; set; }
        public string Element { get; set; }
        public int Health { get; set; }

        public Pokemon(string name,string element,int health)
        {
            this.Name = name;
            this.Element = element;
            this.Health = health;
        }

        

    }
}
