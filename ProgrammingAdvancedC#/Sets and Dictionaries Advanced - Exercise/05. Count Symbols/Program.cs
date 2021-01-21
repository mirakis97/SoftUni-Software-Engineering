using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var charDictionary = new Dictionary<char, int>();

            foreach (var letter in input)
            {
                if (!charDictionary.ContainsKey(letter))
                {
                    charDictionary.Add(letter,0);
                }
                charDictionary[letter]++;
            }
            foreach (var leter in charDictionary.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{leter.Key}: {leter.Value} time/s ");
            }
        }
    }
}
