using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _3._Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();
            string[] words = File.ReadAllText("../../../words.txt").Split();

            using (var reader = new StreamReader("../../../text.txt"))
            {

                string line = reader.ReadLine();

                while (line != null)
                {
                    string[] curWords = line.ToLower().
                        Split(new[] { ' ', '.', ',', '-', '?', '!', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var word in words)
                    {
                        foreach (var item in curWords)
                        {
                            if (word == item)
                            {
                                if (!wordsCount.ContainsKey(item))
                                {
                                    wordsCount.Add(item, 0);
                                }
                                wordsCount[item]++;
                            }
                        }
                    }
                    line = reader.ReadLine();
                }
            }
            foreach (var item in wordsCount.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }
    }
}
