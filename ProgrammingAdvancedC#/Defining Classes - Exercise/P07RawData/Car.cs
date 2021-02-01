using System;
using System.Collections.Generic;
using System.Text;

namespace P07RawData
{
    public class Car
    {
        private string model;
        private Engine engine;
        private Cargo cargo;
        private Tire[] tires;
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tire[] Tires { get; set; }

        public Car (string model,int speed,int power, int weight,string type,
            double pressureOne,int ageOne
            , double pressureTwo, int ageTwo
            , double pressureThree, int ageThree
            , double pressureFour, int ageFour)
        {
            this.Model = model;
            this.Engine = new Engine(speed,power);
            this.Cargo = new Cargo(weight, type);
            this.Tires = new Tire[]
            {
                new Tire(pressureOne,ageOne),
                new Tire(pressureTwo,ageTwo),
                new Tire(pressureThree,ageThree),
                new Tire(pressureFour,ageFour)
            };
        }
    }
}
