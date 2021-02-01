using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    public class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TraelledDistance { get; set; }

        public bool Drive (double distanceTraveled)
        {
            double neededFuel = distanceTraveled * this.FuelConsumptionPerKilometer;

            if (neededFuel > this.FuelAmount)
            {
                return false;
            }
            this.FuelAmount -= neededFuel;
            this.TraelledDistance += distanceTraveled;
            return true;
        }
    }
}
