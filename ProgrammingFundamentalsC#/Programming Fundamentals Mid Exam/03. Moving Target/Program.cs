using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Moving_Target
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            string cmd ;

            while ((cmd = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = cmd.Split();
                string comand = cmdArgs[0];
                int index = int.Parse(cmdArgs[1]);
                int value = int.Parse(cmdArgs[2]);

                if (index < 0 || index >= targets.Count)
                {
                    if (comand == "Add")
                    {
                        Console.WriteLine("Invalid placement!");
                    }
                    else if (comand == "Strike")
                    {
                        Console.WriteLine("Strike missed!");
                    }
                    continue;
                }
                switch (comand)
                {
                    case "Shoot":
                        targets[index] -= value;
                        if (targets[index] <= 0)
                        {
                            targets.RemoveAt(index);
                        }
                        break;
                    case "Add":
                        targets.Insert(index, value);
                        break;
                    case "Strike":
                        if (index - value < 0 || index + value >= targets.Count)
                        {
                            Console.WriteLine("Strike missed!");
                            continue;
                        }
                        for (int i = index - value; i <= index + value ; i++)
                        {
                            targets.RemoveAt(index - value);
                        }
                        break;
                }
            }

            Console.WriteLine(string.Join('|', targets));
        }
    }
}
