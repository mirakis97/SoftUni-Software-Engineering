using System;
using System.Collections.Generic;
using System.Text;

namespace Guild
{
    public class Player
    {
        public Player(string name, string classs)
        {
            this.Name = name;
            this.Class = classs;
            this.Rank = "Trail";
            this.Description = "n/a";
        }
        public string Name { get; set; }
        public string Class { get; set; }
        public string Rank { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Player {Name}: {Class}");
            sb.AppendLine($"Rank: {Rank}");
            sb.Append($"Description: {Description}");

            return sb.ToString();
        }
    }
}
