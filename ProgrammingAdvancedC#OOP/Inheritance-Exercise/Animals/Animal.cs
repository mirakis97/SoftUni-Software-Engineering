using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {
        public Animal(string name,int age,string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public virtual string ProduceSound()
        {
            return string.Empty;
        }

        public override string ToString()
        {
            return this.GetType().Name + Environment.NewLine +
                $"{this.Name} {this.Age} {this.Gender}";
        }
    }
}
