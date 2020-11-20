using System;

namespace _02._Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            int period = int.Parse(Console.ReadLine());
            int numberOfPatiens = int.Parse(Console.ReadLine());
            int doctors = 7;
            int treatedPatiens = 0;
            for (int i = 1; i < period; i++)
            {
                treatedPatiens = doctors * numberOfPatiens;
                
                if (period > 3)
                {
                    doctors++;
                }
                else
                {

                }
            }
        }
    }
}
