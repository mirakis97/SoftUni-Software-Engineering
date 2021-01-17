using System;
using System.Text;

namespace _05._Easter_Eggs
{
    class Program
    {
        static void Main(string[] args)
        {
            int eggs = int.Parse(Console.ReadLine());

            int redEggs = 0;
            int orangeEggs = 0;
            int blueEggs = 0;
            int greenEggs = 0;

            int redSum = 0;
            int orangeSum = 0;
            int blueSum = 0;
            int greenSum = 0;
            int totalSum = 0;
            while (true)
            {
                string eggColor = Console.ReadLine();


                if (eggColor == "red")
                {
                    redEggs++;
                    eggs--;
                    redSum++;
                }
                else if (eggColor == "orange")
                {
                    orangeEggs++;
                    eggs--;
                    orangeSum++;
                }
                else if (eggColor == "blue")
                {
                    blueEggs++;
                    eggs--;
                    blueSum++;
                }
                else if (eggColor == "green")
                {
                    greenEggs++;
                    eggs--;
                    greenSum++;
                }

                if (eggs == 0)
                {
                    break;
                }

               
            }

            if (redSum > orangeSum && redSum > blueSum && redSum > greenSum)
            {
                totalSum = redSum;
            }
            if (orangeSum > redSum && orangeSum > blueSum && orangeSum > greenSum)
            {
                totalSum = orangeSum;
            }
            if (blueSum > redSum && blueSum > orangeSum && blueSum > greenSum)
            {
                totalSum = blueSum;
            }
            if (greenSum > redSum && greenSum > orangeSum && greenSum > blueSum)
            {
                totalSum = greenSum;
            }
            Console.WriteLine($"Red eggs: {redEggs}");
            Console.WriteLine($"Orange eggs: {orangeEggs}");
            Console.WriteLine($"Blue eggs: {blueEggs}");
            Console.WriteLine($"Green eggs: {greenEggs}");
            if (totalSum == redSum)
            {
                Console.WriteLine($"Max eggs: {redSum} -> red");
            }
            if (totalSum == orangeSum)
            {
                Console.WriteLine($"Max eggs: {orangeSum} -> orange");
            }
            if (totalSum == blueSum)
            {
                Console.WriteLine($"Max eggs: {blueSum} -> blue");
            }
            if (totalSum == greenSum)
            {
                Console.WriteLine($"Max eggs: {greenSum} -> green");
            }


        }
    }
}
