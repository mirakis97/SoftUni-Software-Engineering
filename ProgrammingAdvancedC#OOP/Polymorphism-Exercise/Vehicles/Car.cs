using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double TruckAirConditionerModifier = 0.9;
        public Car(double fuel, double fuelConsumption,double tankCapacaty)
            : base(fuel, fuelConsumption,tankCapacaty, TruckAirConditionerModifier)
        {
        }
    }
}
