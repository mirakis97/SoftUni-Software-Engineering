using System;

namespace _03._CelsiustoFahrenheit
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            double celsius = double.Parse(Console.ReadLine());
            //Calculations
            double fahrenheit = celsius * 1.8 + 32 ;
            //Output
            Console.WriteLine($"{fahrenheit:f2}");
        }
    }
}
