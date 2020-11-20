using System;

namespace _9._Palindrome_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "END")
            {
                string  result = IsPalindrom(input).ToString().ToLower();

                Console.WriteLine(result);
                input = Console.ReadLine();
            }
        }

        private static bool IsPalindrom(string input)
        {
            string first = input.Substring(0, input.Length / 2);
            char[] arr = input.ToCharArray();

            Array.Reverse(arr);

            string temp = new string(arr);
            string second = temp.Substring(0, temp.Length / 2);

            return first.Equals(second);
        }
    }
}
