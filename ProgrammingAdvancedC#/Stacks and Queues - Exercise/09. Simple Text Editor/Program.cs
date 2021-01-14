using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace _09._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<string> texts = new Stack<string>();
            texts.Push("");
            for (int i = 0; i < n; i++)
            {
                var cmd = Console.ReadLine().Split();

                switch (cmd[0])
                {
                    case "1":
                        string newText = texts.Peek() + cmd[1];
                        texts.Push(newText);
                        break;
                    case "2":
                        string previous = texts.Peek();
                        int charsToCut = int.Parse(cmd[1]);
                        string substring = previous.Substring(0, previous.Length - charsToCut);
                        texts.Push(substring);
                        break;
                    case "3":
                        string current = texts.Peek();
                        int index = int.Parse(cmd[1]);
                        Console.WriteLine(current[index - 1]);
                        break;
                    case "4":
                        texts.Pop();
                        break;

                }
            }
        }
    }
}
