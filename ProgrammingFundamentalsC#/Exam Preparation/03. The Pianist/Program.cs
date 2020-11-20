using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03._The_Pianist
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<string>> pieces = new Dictionary<string, List<string>>();

            for (int i = 0; i < n; i++)
            {
                string[] comand = Console.ReadLine().Split("|").ToArray();
                string piece = comand[0];
                string composer = comand[1];
                string key = comand[2];

                if (!pieces.ContainsKey(piece))
                {
                    pieces[piece] = new List<string>() { "","" };
                }

                pieces[piece][0] = composer;
                pieces[piece][1] = key;
            }

            string cmd = Console.ReadLine();

            while (cmd != "Stop")
            {
                string[] cmdArgs = cmd.Split("|");
                string newComand = cmdArgs[0];
                
                if (newComand.Equals("Add"))
                {
                    string pices = cmdArgs[1];
                    string composer = cmdArgs[2];
                    string key = cmdArgs[3];

                    if (pieces.ContainsKey(pices))
                    {
                        Console.WriteLine($"{pices} is already in the collection!");
                    }
                    else
                    {
                        pieces[pices] = new List<string>() { "", "" };
                        pieces[pices][0] = composer;
                        pieces[pices][1] = key;

                        Console.WriteLine($"{pices} by {composer} in {key} added to the collection!");
                    }
                    
                }
                else if (newComand == "Remove")
                {
                    string pices = cmdArgs[1];
                    if (pieces.ContainsKey(pices))
                    {
                        pieces.Remove(pices);
                        Console.WriteLine($"Successfully removed {pices}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {pices} does not exist in the collection.");
                    }
                }
                else if (newComand == "ChangeKey")
                {
                    string pices = cmdArgs[1];
                    string newKey = cmdArgs[2];
                    if (pieces.ContainsKey(pices))
                    {
                        pieces[pices][1] = newKey;
                        Console.WriteLine($"Changed the key of {pices} to {newKey}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {pices} does not exist in the collection.");
                    }
                }


                cmd = Console.ReadLine();
            }

            foreach (var (pices,value) in pieces.OrderBy(x=>x.Key).ThenBy(x=>x.Value[0]))
            {
                Console.WriteLine($"{pices} -> Composer: {value[0]}, Key: {value[1]}");
            }
        }
    }
}
