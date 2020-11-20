using System;
using System.Text;

namespace _05._Digits__Letters_and_Other
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var nums = new StringBuilder();

            var letters = new StringBuilder();

            var other = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                var charText = input[i];

                if (char.IsDigit(charText))
                {
                    nums.Append(charText);
                }
                else if (char.IsLetter(charText))
                {
                    letters.Append(charText);
                }
                else 
                {
                    other.Append(charText);
                }
            }
            Console.WriteLine($"{nums}\n{letters}\n{other}");
        }
    }
}
