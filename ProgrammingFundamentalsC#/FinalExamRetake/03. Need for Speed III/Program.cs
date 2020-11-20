using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Need_for_Speed_III
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var carsMileage = new Dictionary<string, int>();
            var carsFuel = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                var cars = Console.ReadLine().Split("|").ToArray();

                string carName = cars[0];
                int miliage = int.Parse(cars[1]);
                int fuel = int.Parse(cars[2]);

                carsMileage[carName] = miliage;
                carsFuel[carName] = fuel;

            }

            string comand = Console.ReadLine();

            while (comand != "Stop")
            {
                string[] cmdArgs = comand.Split(" : ");
                string cmd = cmdArgs[0];
                string car = cmdArgs[1];
                if (cmd == "Drive")
                {
                    int maxMilege = 100000;
                    int distance = int.Parse(cmdArgs[2]);
                    int fuel = int.Parse(cmdArgs[3]);

                    if (fuel > carsFuel[car])
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    else
                    {
                        carsMileage[car] += distance;
                        carsFuel[car] -= fuel;
                        Console.WriteLine($"{car} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                    }
                    if (carsMileage[car] >= maxMilege)
                    {
                        Console.WriteLine($"Time to sell the {car}!");
                        carsFuel.Remove(car);
                        carsMileage.Remove(car);
                    }
                }
                else if (cmd == "Refuel")
                {
                    int fuel = int.Parse(cmdArgs[2]);
                    int maxFuel = 75;
                    int neededFuel = maxFuel - carsFuel[car];
                    carsFuel[car] += fuel;

                    if (carsFuel[car] > maxFuel)
                    {
                        Console.WriteLine($"{car} refueled with {neededFuel} liters");
                        carsFuel[car] = maxFuel;
                    }
                    else
                    {
                        Console.WriteLine($"{car} refueled with {fuel} liters");
                    }
                }
                else if (cmd == "Revert")
                {
                    int miliageMax = 10000;
                    int kilometers = int.Parse(cmdArgs[2]);

                    carsMileage[car] -= kilometers;
                    if (carsMileage[car] < miliageMax)
                    {
                        carsMileage[car] = miliageMax;
                    }
                    else
                    {
                        Console.WriteLine($"{car} mileage decreased by {kilometers} kilometers");
                    }

                }


                comand = Console.ReadLine();
            }

            Console.WriteLine(string.Join($"{Environment.NewLine}", carsMileage.
                OrderByDescending(x=>x.Value)
                .ThenBy(x=>x.Key)
                .Select(x => $"{x.Key} -> Mileage: {x.Value} kms, Fuel in the tank: {carsFuel[x.Key]} lt.")));
        }
    }
}
