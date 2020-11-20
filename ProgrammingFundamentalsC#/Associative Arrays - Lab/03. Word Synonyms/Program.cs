using System;
using System.Collections.Generic;

namespace _03._Word_Synonyms
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersOfWords = int.Parse(Console.ReadLine());

            Dictionary<string, List<string>> dictionart = new Dictionary<string, List<string>>();
            for (int i = 0; i < numbersOfWords; i++)
            {
                string word = Console.ReadLine();
                string synonim = Console.ReadLine();
                if (dictionart.ContainsKey(word))
                {
                    dictionart[word].Add(synonim);
                }
                else
                {
                    dictionart.Add(word, new List<string>() { synonim });
                }
            }

            foreach (var word in dictionart)
            {

                Console.WriteLine($"{word.Key} - {string.Join(", ", word.Value )}");
            }
        }
    }
}
