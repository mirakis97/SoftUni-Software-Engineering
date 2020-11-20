using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listOfInt = Console.ReadLine()
                             .Split()
                             .Select(int.Parse)
                             .ToList();

            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] cmdArg = command.Split();
                string firstComand = cmdArg[0];
                int elemnt = int.Parse(cmdArg[1]);

                if (firstComand == "Delete")
                {
                    listOfInt.RemoveAll(x=>x == elemnt);
                }
                else if (firstComand == "Insert")
                {
                    int position = int.Parse(cmdArg[2]);
                    listOfInt.Insert(position, elemnt);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", listOfInt));
        }
    }
}
