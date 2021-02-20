using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> players;
        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.players = new List<Player>(Capacity);
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get => players.Count; }

        public void AddPlayer(Player player)
        {
            if (this.Count < this.Capacity)
            {
                players.Add(player);
            }
        }
        public bool RemovePlayer(string name)
        {
            Player playerToRemove = this.players.FirstOrDefault(p => p.Name == name);
            if (this.players.Exists(p => p.Name == name))
            {
                players.Remove(playerToRemove);
                return true;
            }
            return false;
        }

        public void PromotePlayer(string name)
        {
            Player playerToPromote = this.players.FirstOrDefault(p => p.Name == name);
            if (players.Contains(playerToPromote) && playerToPromote.Rank != "Member")
            {
                playerToPromote.Rank = "Member";
            }
            
        }
        public void DemotePlayer(string name)
        {
            Player playerToDemote = this.players.FirstOrDefault(p => p.Name == name);
            if (players.Contains(playerToDemote) && playerToDemote.Rank != "Trial")
            {
                playerToDemote.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string @class)
        {
            Player[] result = players.Where(p =>p.Class == @class).ToArray();
            players.RemoveAll(p => p.Class == @class);
            return result;
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {Name}");
            foreach (var player in players)
            {
                sb.AppendLine(player.ToString());
            }
            return sb.ToString().Trim();
        }
    }

}
