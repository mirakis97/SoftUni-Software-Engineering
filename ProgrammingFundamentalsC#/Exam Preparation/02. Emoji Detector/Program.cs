using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Emoji_Detector
{
    class Program
    {
        static void Main(string[] args)
        {
            string numPattern = @"\d";
            string emojiPatern = @"(:{2}|\*{2})[A-Z][a-z]{2,}\1";
            Regex numReg = new Regex(numPattern);
            Regex emojiREg = new Regex(emojiPatern);

            string text = Console.ReadLine();
            long coolTreshold = 1;
            numReg.Matches(text)
                .Select(m => m.Value)
                .Select(int.Parse)
                .ToList()
                .ForEach(x => coolTreshold *= x);

            var mathes = emojiREg.Matches(text);
            int totalEmojis = mathes.Count;
            List<string> coolEmojis = new List<string>();


            foreach (Match match in mathes)
            {
                long coolIndex = match.Value
                    .Substring(2, match.Value.Length - 4)
                    .ToCharArray()
                    .Sum(x => (int)x);

                if (coolIndex > coolTreshold)
                {
                    coolEmojis.Add(match.Value);
                }
            }

            Console.WriteLine($"Cool threshold: {coolTreshold}");
            Console.WriteLine($"{totalEmojis} emojis found in the text. The cool ones are:");
            foreach (var item in coolEmojis)
            {
                Console.WriteLine(item);
            }
        }
    }
}
