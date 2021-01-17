using System;

namespace FirstStepsInCodingExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            double radians = double.Parse(Console.ReadLine());
           //Caulculations
            double degrees = radians * 180 / Math.PI;
            //Output
            Console.WriteLine(Math.Round(degrees));
        }
    }
}
