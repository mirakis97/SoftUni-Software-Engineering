using System;
using System.Text.RegularExpressions;

namespace _01._Match_Full_Name
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";

            Regex regex = new Regex(pattern);

            string text = Console.ReadLine();

            var matches = regex.Matches(text);

            foreach (Match item in matches)
            {
                Console.Write(item.Value + " ");
            }
            Console.WriteLine();
        }
    }
}
