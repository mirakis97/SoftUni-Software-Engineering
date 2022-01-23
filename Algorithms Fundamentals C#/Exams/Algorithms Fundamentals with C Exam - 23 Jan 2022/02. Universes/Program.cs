using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Universes
{
    public class Program
    {
        private static int counter;
        private static HashSet<string> visited;
        private static Dictionary<string, List<string>> graph;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            graph = ReadGraph(n);
            visited = new HashSet<string>();

            foreach (var key in graph.Keys)
            {
                if (visited.Contains(key))
                {
                    continue;
                }
                counter++;
                DFS(key);
               
            }

            Console.WriteLine(counter);
        }

        public static void DFS(string node)
        {
            if (visited.Contains(node))
            {
                return;
            }

            visited.Add(node);
            
            foreach (var child in graph[node])
            {
                DFS(child);
            }
        }

        public static Dictionary<string, List<string>> ReadGraph(int n)
        {
            Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();

            for (int j = 0; j < n; j++)
            {
                string[] input = Console.ReadLine()
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                if (string.IsNullOrEmpty(input[0]))
                {
                    continue;
                }
                if (!graph.ContainsKey(input[0]))
                {
                    graph[input[0]] = new List<string>();
                }
                if (!graph.ContainsKey(input[1]))
                {
                    graph[input[1]] = new List<string>();
                }
                graph[input[0]].Add(input[1]);
            }

            return graph;
        }
    }
}