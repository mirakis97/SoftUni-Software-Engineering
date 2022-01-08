using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Distance_Between_Vertices
{
    public class Program
    {
        private static Dictionary<int, List<int>> graph;
        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());
            int pairs = int.Parse(Console.ReadLine());

            graph = new Dictionary<int, List<int>>();

            for (int i = 0; i < nodes; i++)
            {
                var nodeAndChildren = Console.ReadLine()
                    .Split(":", StringSplitOptions.RemoveEmptyEntries);
                var node = int.Parse(nodeAndChildren[0]);

                if (nodeAndChildren.Length == 1)
                {
                    graph[node] = new List<int>();
                }
                else
                {
                    var childer = nodeAndChildren[1]
                                .Split()
                                .Select(int.Parse)
                                .ToList();

                    graph[node] = childer;
                }
            }

            for (int i = 0; i < pairs; i++)
            {
                var pair = Console.ReadLine().Split("-")
                    .Select(int.Parse).ToArray();

                var start = pair[0];

                var destination = pair[1];

                var steps = BFS(start, destination);

                Console.WriteLine($"{{{start}, {destination}}} -> {steps}");
            }

        }

        private static int BFS(int start, int destination)
        {
            var queue = new Queue<int>();
            queue.Enqueue(start);

            var visited = new HashSet<int> { start};
            var parent = new Dictionary<int, int> { { start,- 1} };
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == destination)
                {
                    return GetSteps(parent, destination);
                }

                foreach (var child in graph[node])
                {
                    if (visited.Contains(child))
                    {
                        continue;
                    }

                    visited.Add(child);
                    queue.Enqueue(child);
                    parent[child] = node;
                }
            }

            return -1;
        }

        private static int GetSteps(Dictionary<int, int> parent, int destination)
        {
            var steps = 0;
            var node = destination;

            while (node != -1)
            {
                node = parent[node];
                steps += 1;
            }

            return steps - 1;
        }
    }
}
