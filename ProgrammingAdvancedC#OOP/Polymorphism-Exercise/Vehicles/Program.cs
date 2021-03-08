using System;

namespace Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {
            Vehicle car = CreateVehicle();
            Vehicle truck = CreateVehicle();
            Vehicle bus = CreateVehicle();


            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] parts = Console.ReadLine().Split();

                string comand = parts[0];
                string vehicleType = parts[1];
                double parameter = double.Parse(parts[2]);

                try
                {
                    if (vehicleType == nameof(Car))
                    {
                        ProcessComand(car, comand, parameter);

                    }
                    else if (vehicleType == nameof(Bus))
                    {
                        ProcessComand(bus, comand, parameter);
                    }
                    else
                    {
                        ProcessComand(truck, comand, parameter);

                    }
                }
                catch (Exception ex)
                   when(ex is InvalidOperationException || ex is ArgumentException)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        private static void ProcessComand(Vehicle vehicle, string comand, double parameter)
        {
            if (comand == "Drive")
            {

                vehicle.Drive(parameter);

                Console.WriteLine($"{vehicle.GetType().Name} travelled {parameter} km");

            }
            else if (comand == "DriveEmpty")
            {

                ((Bus)vehicle).DriveEmpty(parameter);
                Console.WriteLine($"{vehicle.GetType().Name} travelled {parameter} km");

            }
            else
            {
                vehicle.Refuel(parameter);
            }
        }

        private static Vehicle CreateVehicle()
        {
            string[] parts = Console.ReadLine().Split();

            string type = parts[0];
            double fuel = double.Parse(parts[1]);
            double fuelConsuption = double.Parse(parts[2]);
            double tankCapacity = double.Parse(parts[3]);
            Vehicle vehicle = null;

            if (type == nameof(Car))
            {
                vehicle = new Car(fuel, fuelConsuption, tankCapacity);
            }
            else if (type == nameof(Truck))
            {
                vehicle = new Truck(fuel, fuelConsuption, tankCapacity);

            }
            else if (type == nameof(Bus))
            {
                vehicle = new Bus(fuel, fuelConsuption, tankCapacity);

            }
            return vehicle;
        }
    }
}
