using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carData = Console.ReadLine().Split();
                string model = carData[0];
                double fuelAmount = double.Parse(carData[1]);
                double fuelConsumptionForOneKm = double.Parse(carData[2]);


                Car currCar = new Car()
                {
                    
                    Model = model,
                    FuelAmount = fuelAmount,
                    FuelConsumptionPerKilometer = fuelConsumptionForOneKm
                };
                cars.Add(currCar);
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] cmdData = command.Split();
                string model = cmdData[1];
                double distanceTravled = double.Parse(cmdData[2]);

                Car car = cars.FirstOrDefault(c => c.Model == model);

                bool isDrive =car.Drive(distanceTravled);

                if (isDrive == false)
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
                command = Console.ReadLine();
            }

            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TraelledDistance}");
            }
        }
    }
}
