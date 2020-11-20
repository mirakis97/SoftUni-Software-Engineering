using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _02._Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Regex patternComand = new Regex(@"!(?<first>[A-Za-z]{3,})!:\[(?<second>[A-Za-z]{8,}\])");
            string input = Console.ReadLine();
            for (int i = 0; i < n; i++)
            {
                 input = Console.ReadLine();    
            }
            
            
            MatchCollection matchesss = patternComand.Matches(input);

            foreach (Match matchs in matchesss)
            {
                if (matchs.Success)
                {
                    string comand = matchs.Groups["first"].Value;
                    string encritpted = matchs.Groups["second"].Value.ToString();
                    byte[] ascciBytes = Encoding.ASCII.GetBytes(encritpted);
                    Console.Write($"{comand}: {ascciBytes}");

                }
                else
                {
                    Console.WriteLine("The message is invalid");
                }
            }

        }
    }
}
