using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        { Engine v12 = new Engine(560,6300);
            var tires = new Tire[4]
                {
                    new Tire(2018, 2.5),
                    new Tire(2018, 2.1),
                    new Tire(2018, 0.5),
                    new Tire(2018, 2.3),

            };

            Car bmw = new Car("BMW", "X6", 1993, 5000, -50, v12, tires);

            Console.WriteLine("Horse power: " + bmw.Engine.HorsePower);


            foreach (var tire in bmw.Tires)
            {
                Console.WriteLine($"{tire.Year} - {tire.Pressure}");
            }





            //Car defaultGolf = new Car();
            //Console.WriteLine($"Default golf: " + defaultGolf.WhoAmI());
            //Car car = new Car();

            //car.Make = "VW";
            //car.Model = "MK3";
            //car.Year = 1992;
            //car.FuelQuantity = 200;
            //car.FuelConsumption = 200;

            //car.Drive(2000);

            //Console.WriteLine(car.WhoAmI());
        }
    }
}
