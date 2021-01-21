using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestsData = new Dictionary<string, string>();

            string contestInput = Console.ReadLine();

            while (contestInput != "end of contests")
            {
                string[] contestData = contestInput.Split(":");
                contestsData.Add(contestData[0],contestData[1]);


                contestInput = Console.ReadLine();
            }

            SortedDictionary<string, Dictionary<string, int>> usersSubm = new SortedDictionary<string, Dictionary<string, int>>();
            string submInput = Console.ReadLine();
            while (submInput != "end of submissions")
            {
                string[] subData = submInput.Split("=>");
                string contest = subData[0];
                string password = subData[1];
                string username = subData[2];
                int points = int.Parse(subData[3]);

                if (!contestsData.ContainsKey(contest) || contestsData[contest] != password)
                {
                    submInput = Console.ReadLine();
                    continue;
                }

                if (!usersSubm.ContainsKey(username))
                {
                    usersSubm.Add(username, new Dictionary<string, int>());
                }

                if (!usersSubm[username].ContainsKey(contest))
                {
                    usersSubm[username].Add(contest, points);
                }
                else
                {
                    int oldPoints = usersSubm[username][contest];
                    if (points > oldPoints)
                    {
                        usersSubm[username][contest] = points;
                    }
                }
                submInput = Console.ReadLine();
            }

            KeyValuePair<string, Dictionary<string,int>> bestCandidate = usersSubm.OrderByDescending(x => x.Value.Values.Sum()).First();
            int totalPoints = bestCandidate.Value.Values.Sum();
            Console.WriteLine($"Best candidate is {bestCandidate.Key} with total {totalPoints} points.");
            Console.WriteLine("Ranking:");

            foreach (var user in usersSubm)
            {
                Console.WriteLine(user.Key);

                foreach (var contestData in user.Value.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"#  {contestData.Key} -> {contestData.Value}");
                }
            }
        }
    }
}
