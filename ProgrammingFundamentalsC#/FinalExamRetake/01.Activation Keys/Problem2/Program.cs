using System;
using System.Text.RegularExpressions;

namespace Problem2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string pattern = @"([A-Z][A-Za-z]{2,}\s[A-Z][A-Za-z]{2,})#+([A-Z][A-Za-z]+(?:&[A-Z][A-Za-z]+)?(?:&[A-Z][A-Za-z]+)?)\d{2}([A-Z][A-Za-z\d]+\s(?:(Ltd.|JSC)))";

            Regex regex = new Regex(pattern);

            for (int i = 0; i < n; i++)
            {
                string message = Console.ReadLine();

                Match match = regex.Match(message);

                if (match.Success)
                {

                    string name = match.Groups[1].Value;
                    string job = match.Groups[2].Value;
                    string company = match.Groups[3].Value;

                    job = job.Replace("&"," ");

                    Console.WriteLine($"{name} is {job} at {company}");
                }
                
            }
        }
    }
}
