using System;
using System.Collections.Generic;

namespace _8._Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int carPassOnGreen = int.Parse(Console.ReadLine());

            string comand = Console.ReadLine();
            Queue<string> cars = new Queue<string>();
            int count = 0;
            while (comand != "end")
            {
                if (comand == "green")
                {
                    for (int i = 0; i < carPassOnGreen; i++)
                    {
                        if (cars.Count > 0)
                        {
                            Console.WriteLine(cars.Dequeue() + " passed!");
                            count++;
                        }
                    }
                }
                else
                {
                    cars.Enqueue(comand);
                }
                comand = Console.ReadLine();
            }

            Console.WriteLine($"{count} cars passed the crossroads.");
        }
    }
}
