using System;
using System.Collections.Generic;
using System.Text;

namespace _7._Custom_Exception
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;

        public Person(string firstName ,string lastName ,int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }
        public string FirstName
        {
            get => firstName;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value", "This first name canot be null or empty.");
                }
                this.firstName = value;
            }
        }
        public string LastName
        {
            get => lastName;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value", "This last name canot be null or empty.");
                }
                this.lastName = value;
            }
        }
        public int Age
        {
            get => age;
            private set
            {
                if (value < 0 || 120 < value)
                {
                    throw new ArgumentOutOfRangeException("value", "Age should be in the range [0 ... 120].");
                }
            }
        }
    }
}
