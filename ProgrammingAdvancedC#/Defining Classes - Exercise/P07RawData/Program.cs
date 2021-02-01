using System;
using System.Collections.Generic;
using System.Linq;

namespace P07RawData
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                string[] comand = Console.ReadLine().Split();
                string model = comand[0];
                int speed = int.Parse(comand[1]);
                int power = int.Parse(comand[2]);
                int weight = int.Parse(comand[3]);
                string type = comand[4];
                double pressureOne = double.Parse(comand[5]);
                int ageOne = int.Parse(comand[6]);
                double pressureTwo = double.Parse(comand[7]);
                int ageTwo = int.Parse(comand[8]);
                double pressureThree = double.Parse(comand[9]);
                int ageThree = int.Parse(comand[10]);
                double pressureFour = double.Parse(comand[11]);
                int ageFour = int.Parse(comand[12]);

                Car car = new Car(model, speed,
                    power, weight, type
                      , pressureOne, ageOne
                      , pressureTwo, ageTwo
                      , pressureThree, ageThree
                      , pressureFour, ageFour);
                cars.Add(car);
            }
            string cmd = Console.ReadLine();

            if (cmd == "fragile")
            {
                foreach (var car in cars.Where(c => c.Cargo.Type == "fragile"))
                {
                    if (car.Tires.Any(t => t.Pressure < 1))
                    {
                        Console.WriteLine($"{car.Model}");
                    }
                }
            }

            else if (cmd == "flamable")
            {
                foreach (var car in cars.Where(c=> c.Cargo.Type == "flamable").Where(c => c.Engine.Power > 250))
                {
                    Console.WriteLine($"{car.Model}");

                }
            }
        }
    }
}
