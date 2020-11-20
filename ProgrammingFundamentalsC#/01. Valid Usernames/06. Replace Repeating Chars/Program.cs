using System;
using System.Text;

namespace _06._Replace_Repeating_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            var sb = new StringBuilder();
            var input = Console.ReadLine().ToCharArray();

            for (int i = 0; i < input.Length - 1 ; i++)
            {
                if (input[i] != input[i+1])
                {
                    sb.Append(input[i]);
                }
            }
            var lastSymp = input[input.Length - 1];
            sb.Append(lastSymp);
            Console.WriteLine(sb.ToString());
        }
    }
}
