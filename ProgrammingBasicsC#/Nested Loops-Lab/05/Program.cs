using System;

namespace _05
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string destination = Console.ReadLine();
                

                if (destination == "End")
                {
                    break;
                }
                double budjet = double.Parse(Console.ReadLine());
                double savedMoney = 0;
                while (savedMoney < budjet)
                {
                    double inputMoney = double.Parse(Console.ReadLine());
                    savedMoney += inputMoney;
                }
                Console.WriteLine($"Going to {destination}!");
            }
            
        }
    }
}
