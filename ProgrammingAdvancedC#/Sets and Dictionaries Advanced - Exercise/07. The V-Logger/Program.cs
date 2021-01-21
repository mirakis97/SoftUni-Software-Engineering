using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, SortedSet<string>>> app = new Dictionary<string, Dictionary<string, SortedSet<string>>>();

            string comandInput = Console.ReadLine();

            while (comandInput != "Statistics")
            {
                string[] comandData = comandInput.Split(" ");
                string vloggerName = comandData[0];
                string comand = comandData[1];

                if (comand == "joined")
                {
                    if (!app.ContainsKey(vloggerName))
                    {
                        app.Add(vloggerName, new Dictionary<string, SortedSet<string>>());

                        app[vloggerName].Add("following", new SortedSet<string>());
                        app[vloggerName].Add("followers", new SortedSet<string>());

                    }
                }
                else if (comand == "followed")
                {
                    string vloggarNameTwo = comandData[2];
                    if (app.ContainsKey(vloggerName) && app.ContainsKey(vloggarNameTwo) && vloggerName != vloggarNameTwo)
                    {
                        app[vloggerName]["following"].Add(vloggarNameTwo);
                        app[vloggarNameTwo]["followers"].Add(vloggerName);
                    }
                }


                comandInput = Console.ReadLine();
            }

            Dictionary<string, Dictionary<string, SortedSet<string>>> sortedDataApp = app.OrderByDescending(x => x.Value["followers"].Count)
                .ThenBy(x => x.Value["following"].Count).ToDictionary(x=>x.Key,x=>x.Value);
            Console.WriteLine($"The V-Logger has a total of {app.Count} vloggers in its logs.");
            int counter = 0;
            foreach (KeyValuePair<string, Dictionary<string, SortedSet<string>>> item in sortedDataApp)
            {
                int followersCount = item.Value["followers"].Count;
                int followingCount = item.Value["following"].Count;
                Console.WriteLine($"{++counter}. {item.Key} : {followersCount} followers, {followingCount} following");

                if (counter == 1)
                {
                    foreach (string follower in item.Value["followers"])
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
            }

        }
    }
}
