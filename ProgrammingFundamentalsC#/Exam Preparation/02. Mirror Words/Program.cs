using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02._Mirror_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> mirrorWords = new List<string>();
            string input = Console.ReadLine();
           Regex pattern = new Regex(@"(@|#)(?<first>[A-Za-z]{3,})\1\1(?<second>[A-Za-z]{3,})\1");

            MatchCollection words = pattern.Matches(input);
            int matchCount = 0;

            foreach (Match match in words)
            {
                if (match.Success)
                {
                    string firstWord = match.Groups["first"].Value;
                    string secondWord = match.Groups["second"].Value;
                    char[] secondToChar = secondWord.ToCharArray();
                    Array.Reverse(secondToChar);
                    string secondReverst = new string(secondToChar);

                    if (firstWord == secondReverst)
                    {
                        string mirror = firstWord + " <=> " + secondWord;
                        mirrorWords.Add(mirror);
                    }
                    matchCount++;
                }
            }

            if (words.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
            }
            else
            {
                Console.WriteLine($"{matchCount} word pairs found!");
            }
            if (mirrorWords.Count == 0)
            {
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(string.Join(", ", mirrorWords));
            }
        }
    }
}
