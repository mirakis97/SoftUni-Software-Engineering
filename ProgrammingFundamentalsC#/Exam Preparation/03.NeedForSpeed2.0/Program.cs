using System;
using System.Collections.Generic;
using System.Linq;

namespace NeedForSpeedIII
{
    class Program
    {
        static void Main(string[] args)
        {
            int times = int.Parse(Console.ReadLine());

            var carsDistance = new Dictionary<string, int>();
            var carsFuel = new Dictionary<string, int>();

            for (int i = 0; i < times; i++)
            {
                var car = Console.ReadLine().Split('|').ToArray();

                string carName = car[0];
                int mileage = int.Parse(car[1]);
                int fuel = int.Parse(car[2]);

                carsDistance[carName] = mileage;
                carsFuel[carName] = fuel;
            }

            var command = Console.ReadLine().Split(" : ").ToArray();

            while (command[0] != "Stop")
            {
                if (command[0] == "Drive")
                {
                    int amortizationMileage = 100000;
                    int distance = int.Parse(command[2]);
                    int fuelCommand = int.Parse(command[3]);

                    if (fuelCommand > carsFuel[command[1]])
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    else
                    {
                        carsDistance[command[1]] += distance;
                        carsFuel[command[1]] -= fuelCommand;

                        Console.WriteLine($"{command[1]} driven for {distance} kilometers. {fuelCommand} liters of fuel consumed.");
                    }

                    if (carsDistance[command[1]] >= amortizationMileage)
                    {
                        Console.WriteLine($"Time to sell the {command[1]}!");

                        carsDistance.Remove(command[1]);
                        carsFuel.Remove(command[1]);
                    }
                }

                if (command[0] == "Refuel")
                {
                    int maxRefillLevel = 75;
                    int fuelCommand = int.Parse(command[2]);
                    int actualNeededFuelAmount = maxRefillLevel - carsFuel[command[1]];

                    carsFuel[command[1]] += fuelCommand;

                    if (carsFuel[command[1]] > maxRefillLevel)
                    {
                        Console.WriteLine($"{command[1]} refueled with {actualNeededFuelAmount} liters");

                        carsFuel[command[1]] = maxRefillLevel;
                    }
                    else
                    {
                        Console.WriteLine($"{command[1]} refueled with {fuelCommand} liters");
                    }
                }

                if (command[0] == "Revert")
                {
                    int minimumMileageLevel = 10000;
                    int revert = int.Parse(command[2]);

                    carsDistance[command[1]] -= revert;

                    if (carsDistance[command[1]] >= minimumMileageLevel)
                    {
                        Console.WriteLine($"{command[1]} mileage decreased by {revert} kilometers");
                    }
                    else
                    {
                        carsDistance[command[1]] = minimumMileageLevel;
                    }
                }

                command = Console.ReadLine().Split(" : ").ToArray();
            }

            Console.WriteLine(string.Join($"{Environment.NewLine}", carsDistance
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .Select(x => $"{x.Key} -> Mileage: {x.Value} kms, Fuel in the tank: {carsFuel[x.Key]} lt.")));
        }
    }
}