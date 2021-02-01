using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
        public string RegistrationNumber { get; set; }

        public Car (string make,string model, int horsePower, string registationNumber)
        {
            this.Make = make;
            this.Model = model;
            this.HorsePower = horsePower;
            this.RegistrationNumber = registationNumber;
        }

        public override string ToString()
        {
            string res = $"Make: {this.Make}" + Environment.NewLine;
            res += $"Model: {this.Model}" + Environment.NewLine;
            res += $"HorsePower: {this.HorsePower}" + Environment.NewLine;
            res += $"RegistrationNumber: {this.RegistrationNumber}" + Environment.NewLine;

            return res;
        }
    }
}
