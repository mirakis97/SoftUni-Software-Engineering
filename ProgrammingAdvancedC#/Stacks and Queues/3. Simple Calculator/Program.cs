using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            Stack<string> expression = new Stack<string>();
            for (int i = input.Length - 1; i >= 0 ; i--)
            {
                expression.Push(input[i]);
            }

            while (expression.Count > 1)
            {
                int leftnum = int.Parse(expression.Pop());
                string sign = expression.Pop();
                int rightNum = int.Parse(expression.Pop());

                if (sign == "+")
                {
                    expression.Push((leftnum + rightNum).ToString());
                }
                else if (sign == "-")
                {
                    expression.Push((leftnum - rightNum).ToString());
                }
               
            }
            Console.WriteLine(expression.Pop());
        }
    }
}
