using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var hashSet = new HashSet<string>();

            while (input != "END")
            {
                string[] cmdArgs = input.Split(",");
                string comand = cmdArgs[0];
                string carNum = cmdArgs[1];

                if (comand == "IN")
                {
                    hashSet.Add(carNum);
                }
                else if (comand == "OUT")
                {
                    hashSet.Remove(carNum);
                }

                
                input = Console.ReadLine();
            }
            if (!hashSet.Any())
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            foreach (var item in hashSet)
            {
                
                Console.WriteLine(item);
            }
        }
    }
}
