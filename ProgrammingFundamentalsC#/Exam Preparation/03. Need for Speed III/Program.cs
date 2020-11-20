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
            var carMileage = new Dictionary<string, int>();
            var carFuel = new Dictionary<string, int>();


            for (int i = 0; i < n; i++)
            {
                string[] car = Console.ReadLine().Split("|");
                string carName = car[0];
                int mileage = int.Parse(car[1]);
                int fuel = int.Parse(car[2]);
                carMileage[carName] = mileage;
                carFuel[carName] = fuel;
            }

            string comand = Console.ReadLine();

            while (comand != "Stop")
            {
                
                string[] cmdArgs = comand.Split(" : ");
                string cmd = cmdArgs[0];
                string car = cmdArgs[1];
                

                if (cmd == "Drive")
                {
                    int amMileage = 100000;
                    int distance = int.Parse(cmdArgs[2]);
                    int fuel = int.Parse(cmdArgs[3]);

                    if (fuel > carFuel[car])
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    else
                    {
                        carMileage[car] += distance;
                        carFuel[car] -= fuel;

                        Console.WriteLine($"{car} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                    }

                    if (carMileage[car] >= amMileage)
                    {
                        Console.WriteLine($"Time to sell the {car}!");

                        carMileage.Remove(car);
                        carFuel.Remove(car);
                    }
                }

                else if (cmd == "Refuel")
                {
                    int maxRefill = 75;
                    int fuel = int.Parse(cmdArgs[2]);
                    int actualFuel = maxRefill - carFuel[car];
                    carFuel[car] += fuel;
                    if (carFuel[car] > maxRefill)
                    {
                        Console.WriteLine($"{car} refueled with {actualFuel} liters");
                        carFuel[car] = maxRefill;
                    }
                    else
                    {
                        Console.WriteLine($"{car} refueled with {fuel} liters");
                    }
                }
                else if (cmd == "Revert")
                {
                    int amMileage = 100000;
                    int kilometers = int.Parse(cmdArgs[2]);

                    carMileage[car] -= kilometers;
                    

                    if (carMileage[car] > amMileage)
                    {
                        Console.WriteLine($"{car} mileage decreased by {kilometers} kilometers");
                    }
                    else
                    {
                        carMileage[car] = amMileage;
                    }
                }


                comand = Console.ReadLine();
            }

            foreach (var car in carMileage.OrderByDescending(x => x.Value).ThenBy(y => y.Key))
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value} kms, Fuel in the tank: {carFuel[car.Key]} lt.");
            }
        }
    }
}
