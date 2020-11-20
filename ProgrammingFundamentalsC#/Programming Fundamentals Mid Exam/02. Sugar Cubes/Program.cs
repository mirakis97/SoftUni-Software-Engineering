using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _02._Sugar_Cubes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> integers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            string cmd = Console.ReadLine();

            while (cmd != "Mort")
            {
                string[] cmdArgs = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string comand = cmdArgs[0];
                int value = int.Parse(cmdArgs[1]);
                if (comand == "Add")
                {
                    integers.Add(value);
                }
                else if (comand == "Remove")
                {
                    int indexForChange = integers.IndexOf(value);
                    integers.RemoveAt(indexForChange);
                }
                else if (comand == "Replace")
                {
                    int replecment = int.Parse(cmdArgs[2]);
                    int indexForChange = integers.IndexOf(value);
                    integers.Remove(value);
                    integers.Insert(indexForChange, replecment);
                }
                else if (comand == "Collapse")
                {
                    integers.RemoveAll(x => x < value);
                }
                cmd = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", integers));
        }
    }
}
