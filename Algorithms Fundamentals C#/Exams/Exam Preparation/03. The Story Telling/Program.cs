using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._The_Story_Telling
{
    public class Program
    {
        static void Main(string[] args)
        {
            var graph = ReadGraph();
            var stack = new Stack<string>();
            var visited = new HashSet<string>();

            foreach (var node in graph.Keys)
            {
                if (!visited.Contains(node))
                {
                    DFS(node, graph, visited, stack);
                }
            }

            Console.WriteLine(string.Join(" ", stack));
        }

        private static Dictionary<string, List<string>> ReadGraph()
        {
            var graph = new Dictionary<string, List<string>>();

            string line = Console.ReadLine();

            while (line != "End")
            {
                var data = line.Split("->", StringSplitOptions.RemoveEmptyEntries);
                var node = data[0].TrimEnd();

                if (!graph.ContainsKey(node))
                {
                    graph.Add(node, new List<string>());
                }
                if (data.Length > 1)
                {
                    graph[node].AddRange(data[1].Trim().Split());
                }

                line = Console.ReadLine();
            }

            return graph;
        }

        private static void DFS(string node, Dictionary<string, List<string>> graph, HashSet<string> visited, Stack<string> stack)
        {
            if (visited.Contains(node))
            {
                return;
            }

            foreach (var child in graph[node])
            {
                if (!visited.Contains(child))
                {
                    DFS(child, graph, visited, stack);
                }
            }
            visited.Add(node);
            stack.Push(node);

        }

    }
}
