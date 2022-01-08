using System;
using System.Collections.Generic;

namespace _03._Cycles_in_Graph
{
    public class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static HashSet<string> visited;
        private static HashSet<string> cycles;
        static void Main(string[] args)
        {
            graph = new Dictionary<string, List<string>>();
            visited = new HashSet<string>();
            cycles = new HashSet<string>();

            while (true)
            {
                var line = Console.ReadLine();
                if (line == "End")
                {
                    break;
                }
                var nodes = line.Split("-");
                var from = nodes[0];
                var to = nodes[1];

                if (!graph.ContainsKey(from))
                {
                    graph.Add(from, new List<string>());
                }
                if (!graph.ContainsKey(to))
                {
                    graph.Add(to, new List<string>());
                }
                graph[from].Add(to);
            }

            try
            {
                foreach (var node in graph.Keys)
                {
                    DFS(node);
                }
                Console.WriteLine("Acyclic: Yes");
            }
            catch (InvalidOperationException)
            {

                Console.WriteLine("Acyclic: No");
            }
        }

        private static void DFS(string node)
        {
            if (cycles.Contains(node))
            {
                throw new InvalidOperationException();
            }
            if (visited.Contains(node))
            {
                return;
            }
            visited.Add(node);
            cycles.Add(node);
            foreach (var child in graph[node])
            {
                DFS(child);
            }
            cycles.Remove(node);
        }
    }
}
