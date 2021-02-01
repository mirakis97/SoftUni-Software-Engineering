using System;
using System.Collections.Generic;
using System.Linq;

namespace P08CarSalesman
{
   public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Engine> engines = new List<Engine>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] engineInfo = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);

                Engine engine = Engine.CreateEngine(engineInfo);
                engines.Add(engine);
            }

            List<Car> cars = new List<Car>();

            int m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                string[] carInfo = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);

                Engine engine = engines.First(c => c.Model == carInfo[1]);

                Car car = Car.CreateCar(carInfo,engine);

                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
