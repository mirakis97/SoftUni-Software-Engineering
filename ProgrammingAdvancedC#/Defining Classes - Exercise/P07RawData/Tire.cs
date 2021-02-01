using System;
using System.Collections.Generic;
using System.Text;

namespace P07RawData
{
    public class Tire
    {
        private double presure;
        private int age;
        public double Pressure { get; set; }
        public int Age { get; set; }

        public Tire(double pressure, int age)
        {
            this.Pressure = pressure;
            this.Age = age;
        }
    }
}
