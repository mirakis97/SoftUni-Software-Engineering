using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Race
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] people = Console.ReadLine().Split(", ");
            Dictionary<string, int> dictionaruOfNames = new Dictionary<string, int>();

            foreach (var name in people)
            {
                dictionaruOfNames.Add(name, 0);
            }
            var namePattern = @"[\W\d]";
            var distancePattern = @"[\WA-Za-z]";

            string input = Console.ReadLine();

            while (input != "end of race")
            {
                string name = Regex.Replace(input, namePattern, "");
                string distance = Regex.Replace(input, distancePattern, "");
                int sum = 0;

                foreach (var digit in distance)
                {
                    int currDigit = int.Parse(digit.ToString());
                    sum += currDigit;
                }

                if (dictionaruOfNames.ContainsKey(name))
                {
                    dictionaruOfNames[name] += sum;
                }


                input = Console.ReadLine();
            }

            int count = 1;

            foreach (var kvp in dictionaruOfNames.OrderByDescending(x=>x.Value))
            {
                string text = count == 1 ? "st" : count == 2 ? "sd" : "rd";

                Console.WriteLine($"{count++}{text} place: {kvp.Key}");

                if (count == 4)
                {
                    break;
                }
           
            }
        }
    }
}
