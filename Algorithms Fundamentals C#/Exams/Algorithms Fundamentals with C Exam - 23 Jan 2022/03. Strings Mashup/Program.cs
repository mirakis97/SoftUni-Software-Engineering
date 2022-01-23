using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03._Strings_Mashup
{
    public class Program
    {
        static void Main(string[] args)
        {
            String input = Console.ReadLine();
            char[] str = input.ToCharArray();
            printPermutation(str, 0);
        }
        public static void printPermutation(char[] str, int pos)
        {
            if (pos == str.Length)
            {
                for (int i = 0; i < pos; i++)
                    Console.Write(str[i]);

                Console.WriteLine();
                return;
            }

            if (str[pos] >= '0' && str[pos] <= '9')
            {
                printPermutation(str, pos + 1);
                return;
            }

            str[pos] = Char.ToLower(str[pos]);
            printPermutation(str, pos + 1);

            str[pos] = Char.ToUpper(str[pos]);
            printPermutation(str, pos + 1);
        }
    }
}