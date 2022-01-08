using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Road_Reconstruction
{
    public class Program
    {
        public class Edge
        {
            public int First { get; set; }
            public int Second { get; set; }
            public override string ToString()
            {
                return $"{First} {Second}";
            }
        }
        private static List<int>[] graph;
        private static List<Edge> edges;
        private static bool[] visited;
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var e = int.Parse(Console.ReadLine());

            graph = new List<int>[n];
            edges = new List<Edge>();

            for (int node = 0; node < graph.Length; node++)
            {
                graph[node] = new List<int>();
            }

            for (int i = 0; i < e; i++)
            {
                var edgeParts = Console.ReadLine()
                    .Split(" - ")
                    .Select(int.Parse)
                    .ToArray();

                var firstNode = edgeParts[0];
                var secondNode = edgeParts[1];

                graph[firstNode].Add(secondNode);
                graph[secondNode].Add(firstNode);

                edges.Add(new Edge { First = firstNode, Second = secondNode });
            }

            Console.WriteLine("Important streets:");
            foreach (var edge in edges)
            {
                graph[edge.First].Remove(edge.Second);
                graph[edge.Second].Remove(edge.First);

                visited = new bool[graph.Length];

                DFS(0);

                if (visited.Contains(false))
                {
                    var newEdge = new Edge
                    {
                        First = Math.Min(edge.First,edge.Second),
                        Second = Math.Max(edge.First, edge.Second),
                    };
                    Console.WriteLine(newEdge);
                }

                graph[edge.First].Add(edge.Second);
                graph[edge.Second].Add(edge.First);
            }

        }

        private static void DFS(int node)
        {
            if (visited[node])
            {
                return;
            }
            visited[node] = true;

            foreach (var child in graph[node])
            {
                DFS(child);
            }
        }
    }
}