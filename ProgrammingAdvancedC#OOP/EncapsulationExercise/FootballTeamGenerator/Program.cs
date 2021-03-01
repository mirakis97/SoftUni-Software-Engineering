using System;
using System.Collections.Generic;

namespace FootballTeamGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            var teamsByName = new Dictionary<string, Team>();

            while (true)
            {
                var lines = Console.ReadLine();
                if (lines == "END")
                {
                    break;;
                }

                var parts = lines.Split(';',StringSplitOptions.RemoveEmptyEntries);
                var comadn = parts[0];
                try
                {
                    if (comadn =="Add")
                    {
                        var teamName = parts[1];
                        if (!teamsByName.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            continue;
                        }
                        var playerName = parts[2];
                        var endurance = int.Parse(parts[3]);
                        var sprint = int.Parse(parts[4]);
                        var dribble = int.Parse(parts[5]);
                        var passing = int.Parse(parts[6]);
                        var shooting = int.Parse(parts[7]);

                        var team = teamsByName[teamName];
                        var player = new Player(playerName,endurance,sprint,dribble,passing,shooting);
                        team.AddPlayer(player);
                    }
                    else if (comadn == "Remove")
                    {
                        var teamName = parts[1];
                        var playerName = parts[2];

                        var team = teamsByName[teamName];
                        team.RemovePlayer(playerName);
                    }
                    else if (comadn == "Rating")
                    {
                        var teamName = parts[1];
                        if (!teamsByName.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            continue;
                        }
                        var team = teamsByName[teamName];
                        Console.WriteLine($"{teamName} - {team.AverageRating}");
                    }
                    else if (comadn == "Team")
                    {
                        var teamName = parts[1];
                        var team = new Team(teamName);

                        teamsByName.Add(teamName,team);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
