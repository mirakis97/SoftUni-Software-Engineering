using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._List_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> number = Console.ReadLine()
                            .Split()
                            .Select(int.Parse)
                            .ToList();
            string cmd = Console.ReadLine();

            while (cmd != "End")
            {
                string[] cmdArgs = cmd.Split(" ");
                string comand = cmdArgs[0];

                if (comand == "Add")
                {
                    int element = int.Parse(cmdArgs[1]);
                    number.Add(element);
                }
                else if (comand == "Insert")
                {
                    int num = int.Parse(cmdArgs[1]);
                    int index = int.Parse(cmdArgs[2]);
                    if (IsValidIndex(index, number.Count))
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        number.Insert(index, num);
                    }
                }
                else if (comand == "Remove")
                {
                    int index = int.Parse(cmdArgs[1]);
                    if (IsValidIndex(index, number.Count))
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        number.RemoveAt(index);
                    }

                }
                else if (comand == "Shift")
                {
                    int rotation = int.Parse(cmdArgs[2]);

                    if (cmdArgs[1] == "left")
                    {
                        for (int i = 0; i < rotation; i++)
                        {
                            int firstElement = number[0];
                            for (int j = 0; j < number.Count - 1; j++)
                            {
                                number[j] = number[j + 1];
                            }
                            number[number.Count - 1] = firstElement;
                        }
                    }
                    else
                    {
                        for (int j = 0; j < rotation; j++)
                        {
                            int lastElement = number[number.Count - 1];
                            for (int i = number.Count - 1; i > 0; i--)
                            {
                                number[i] = number[i - 1];
                            }
                            number[0] = lastElement;
                        }
                    }
                }
           
                cmd = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", number));
        }
        public static bool IsValidIndex(int index, int count)
        {
            return index > count || index < 0;
        }
    }
}
