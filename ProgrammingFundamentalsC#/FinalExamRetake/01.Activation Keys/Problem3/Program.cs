using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem3
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, double> distributor = new SortedDictionary<string, double>();
            SortedDictionary<string, double> clients = new SortedDictionary<string, double>();

            var command = Console.ReadLine();
            double moneySpend = 0;
            double totalMoney = 0;
            while (command != "End")
            {
                var info = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                

                if (info[0] == "Deliver")
                {
                    var name = info[1];
                    var money = double.Parse(info[2]);
                    if (!distributor.ContainsKey(name))
                    {
                        distributor.Add(name, money);
                    }
                    else
                    {
                        distributor[name] += money;
                    }
                    totalMoney += money;
                }
                else if (info[0] == "Return")
                {
                    var name = info[1];
                    var money = double.Parse(info[2]);
                    if (!distributor.ContainsKey(name))
                    {
                       
                    }
                    else if (distributor[name] < money)
                    {

                    }
                    else
                    {
                        distributor[name] -= money;
                        if (distributor[name] == 0)
                        {
                            distributor.Remove(name);
                        }
                    }
                }
                else if (info[0] == "Sell")
                {
                    var name = info[1];
                    var money = double.Parse(info[2]);
                    if (!clients.ContainsKey(name))
                    {
                        clients.Add(name, money);
                    }
                    else
                    {
                        clients[name] += money;
                    }
                    moneySpend += money;
                }
                command = Console.ReadLine();
            }

            //clients = clients.OrderBy(x => x.Key).ToDictionary(x => x.Key , x => x.Value);
            foreach (var client in clients)
            {
                Console.WriteLine($"{client.Key}: {client.Value:f2}");
            }
            Console.WriteLine("-----------");
            //distributor = distributor.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var district in distributor)
            {
                Console.WriteLine($"{district.Key}: {district.Value:f2}");
            }
            Console.WriteLine("-----------");

            Console.WriteLine($"Total Income: {moneySpend:f2}");
        }
    }
}
