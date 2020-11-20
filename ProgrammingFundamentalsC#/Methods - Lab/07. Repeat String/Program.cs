using System;
using System.Text;

namespace _07._Repeat_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int period = int.Parse(Console.ReadLine());
            RepeatString(text , period);
            
        }

        private static void RepeatString(string str, int count)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < count; i++)
            {
                result.Append(str);
            }
            Console.WriteLine(result.ToString());
        }
    }
}
