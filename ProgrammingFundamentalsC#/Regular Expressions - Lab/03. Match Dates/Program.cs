using System;
using System.Text.RegularExpressions;
using System.Text;
namespace _03._Match_Dates
{
    class Program
    {
        static void Main(string[] args)
        {
            var pattern = new Regex(@"\b(?<day>\d{2})([-.\/])(?<month>[A-Z][a-z]{2})\1(?<year>\d{4})+\b");

            
            string date = Console.ReadLine();
            var dates = pattern.Matches(date);

            foreach  (Match item in dates)
            {
                var day = item.Groups["day"].Value;
                var month = item.Groups["month"].Value;
                var year = item.Groups["year"].Value;
                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
             
            }
        }
    }
}
