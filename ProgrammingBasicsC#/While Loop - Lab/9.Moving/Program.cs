using System;

namespace _9.Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());
            int hight = int.Parse(Console.ReadLine());
            
            int cubicMEters = width * lenght * hight;
            string name = Console.ReadLine();
            while (name != "Done")
            {
                int boxs = int.Parse(name);
                cubicMEters -= boxs;
                name = Console.ReadLine();
                if (cubicMEters < 0 )
                {
                    Console.WriteLine($"No more free space! You need {cubicMEters * - 1} Cubic meters more.");
                    Environment.Exit(0);
                }
             }
            Console.WriteLine($"{cubicMEters} Cubic meters left.");
        }
    }
}
