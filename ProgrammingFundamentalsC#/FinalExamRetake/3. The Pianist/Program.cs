using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3._The_Pianist
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Pianist pice = new Pianist();
            var pian = new List<Pianist>();
            for (int i = 0; i < n; i++)
            {
                string[] pices = Console.ReadLine().Split("|");
                
                pice.Pice += pices[0];
                pice.Composer += pices[1];
                pice.Key += pices[2];
                pian.Add(pice);
            }

            string comand = Console.ReadLine();

            while (comand != "Stop")
            {
                string[] cmdArgs = comand.Split("|");
                string cmd = cmdArgs[0];
                if (cmd == "Add")
                {
                    string newPice = cmdArgs[1];
                    string composer = cmdArgs[2];
                    string key = cmdArgs[3];
                    
                    if (pice.Pice.Contains(newPice))
                    {
                        Console.WriteLine($"{newPice} is already in the collection!");
                    }
                    else
                    {
                        pice.Pice += newPice;
                        pice.Composer += composer;
                        pice.Key += key;
                        Console.WriteLine($"{newPice} by {composer} in {key} added to the collection!");
                    }

                }
                else if (cmd == "Remove")
                {
                    string newPice = cmdArgs[1];
                    if (pice.Pice.Contains(newPice))
                    {
                        pice.Pice.Remove(newPice.Length);
                        Console.WriteLine($"Successfully removed {newPice}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {newPice} does not exist in the collection.");
                    }
                }
                else if (cmd == "ChangeKey")
                {
                    string oldPice = cmdArgs[1];
                    string newKey = cmdArgs[2];
                    if (pice.Pice.Contains(oldPice))
                    {
                        pice.Key.Replace(pice.Key, newKey);
                        Console.WriteLine($"Changed the key of {oldPice} to {newKey}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {oldPice} does not exist in the collection.");
                    }
                }


                comand = Console.ReadLine();
            }

            foreach (var item in pian)
            {
                Console.WriteLine($"{item.Pice} -> Composer: {item.Composer}, Key: {item.Key}");
            }
        }
    }
    class Pianist
    {
        public string Pice { get; set; }
        public string Composer { get; set; }
        public string Key { get; set; }

    }
}
