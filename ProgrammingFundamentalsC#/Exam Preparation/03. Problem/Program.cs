using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> messegeSend = new Dictionary<string, List<int>>();
            int cap = int.Parse(Console.ReadLine());
            
            string comand = Console.ReadLine();
            int count = 0;
            while (comand != "Statistics")
            {
                string[] cmdArgs = comand.Split("=",StringSplitOptions.RemoveEmptyEntries);
                string cmd = cmdArgs[1];
                
                if (cmd == "Add")
                {
                   
                    
                    string name = cmdArgs[1];
                    count++;
                    if (messegeSend.ContainsKey(name))
                    {
                        continue;
                    }
                    int mesegeSent = int.Parse(cmdArgs[2]);
                    int mesegeRecived = int.Parse(cmdArgs[3]);
                    messegeSend[name] = new List<int> { mesegeSent,mesegeRecived};
                   
                    
                }
                else if (cmd == "Message")
                {
                    string sender = cmdArgs[1];
                    string receiver = cmdArgs[2];
                    if (messegeSend.ContainsKey(sender)&& messegeSend.ContainsKey(receiver))
                    {
                        messegeSend[sender][0] += 1;
                        messegeSend[receiver][1] += 1;
                    }
                    if (messegeSend[sender][0] >= cap)
                    {
                        messegeSend.Remove(sender);
                        Console.WriteLine($"{sender} reached the capacity!");
                    }
                    else if (messegeSend[receiver][1] >= cap)
                    {
                        messegeSend.Remove(receiver);
                        Console.WriteLine($"{receiver} reached the capacity!");
                    }

                }
                else if (cmd == "Empty")
                {
                    string username = cmdArgs[1];
                    if (messegeSend.ContainsKey(username))
                    {
                        messegeSend.Remove(username);
                    }
                    else if (username == "All")
                    {
                        messegeSend.Clear();
                    }
                    
                }
                comand = Console.ReadLine();
            }
            
            foreach (var (mesege, recived) in messegeSend.OrderByDescending(x=>x.Value[1]).ThenBy(x=>x.Key[0]))
            {
                Console.WriteLine($"Users count: {count}");
                Console.WriteLine($"{mesege.Key[0]} - {recived.Value[0]}");
            }
        }
    }
}
