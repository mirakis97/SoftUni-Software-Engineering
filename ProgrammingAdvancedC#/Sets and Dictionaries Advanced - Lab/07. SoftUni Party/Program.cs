using System;
using System.Collections.Generic;

namespace _07._SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int count = 0;

            var hashSet = new HashSet<string>();

            while (input != "END")
            {
                var guest = input;
                count++;
                if (input == "PARTY")
                {
                    while (input != "END")
                    {
                        count--;
                        
                        hashSet.Remove(input);
                        input = Console.ReadLine();
                    }
                    break;
                }
                hashSet.Add(guest);
                
                input = Console.ReadLine();
            }
            Console.WriteLine(count);
            foreach (var item in hashSet)
            {
                Console.WriteLine(item);
            }
        }
    }
}
