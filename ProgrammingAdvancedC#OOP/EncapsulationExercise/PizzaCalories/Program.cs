using System;

namespace PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var pizzaName = Console.ReadLine().Split()[1];
                var doughDate = Console.ReadLine().Split();

                var flourType = doughDate[1];
                var bakingTechnique = doughDate[2];
                var weight = int.Parse(doughDate[3]);

                var dough = new Dough(flourType,bakingTechnique,weight);
                var pizza = new Pizza(pizzaName, dough);

                while (true)
                {
                    var line = Console.ReadLine();

                    if (line == "END")
                    {
                        break;
                    }

                    var parts = line.Split();
                    var toppingName = parts[1];
                    var toppingWeight = int.Parse(parts[2]);

                    var topping = new Topping(toppingName, toppingWeight);

                    pizza.AddTopping(topping);
                }

                Console.WriteLine($"{pizza.Name} - {pizza.GetCalories():F2} Calories.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
