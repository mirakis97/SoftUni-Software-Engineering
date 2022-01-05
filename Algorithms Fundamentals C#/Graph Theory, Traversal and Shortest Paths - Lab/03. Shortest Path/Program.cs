using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Shortest_Path
{
    public class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;
        private static int[] parents;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            int e = int.Parse(Console.ReadLine());

            graph = ReadGraph(n, e);
            visited = new bool[graph.Length];
            parents = new int[graph.Length];
            Array.Fill(parents, -1);

            var start = int.Parse(Console.ReadLine());
            var end = int.Parse(Console.ReadLine());

            FindShortestPath(start, end);
        }

        private static Stack<int> ReconstructPath(int destination)
        {
            var path = new Stack<int>();
            var index = destination;

            while (index != -1)
            {
                path.Push(index);
                index = parents[index];
            }

            return path;
        }

        private static void FindShortestPath(int startNode, int endNode)
        {
            var queue = new Queue<int>();

            queue.Enqueue(startNode);
            visited[startNode] = true;

            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();

                if (currentNode == endNode)
                {
                    var path = ReconstructPath(endNode);
                    Print(path);
                    return;
                }

                foreach (var child in graph[currentNode])
                {
                    if (!visited[child])
                    {
                        parents[child] = currentNode;
                        queue.Enqueue(child);
                        visited[child] = true;
                    }
                }
            }
        }

        private static void Print(Stack<int> path)
        {
            Console.WriteLine($"Shortest path length is: {path.Count - 1}");
            Console.WriteLine(string.Join(" ", path));
        }

        private static List<int>[] ReadGraph(int n, int e)
        {
            var result = new List<int>[n + 1];

            for (int i = 1; i < result.Length; i++)
            {
                result[i] = new List<int>();
            }

            for (int i = 0; i < e; i++)
            {
                var edge = Console.ReadLine()
                     .Split()
                     .Select(int.Parse)
                     .ToArray();

                var source = edge[0];
                var destination = edge[1];

                result[source].Add(destination);
            }

            return result;
        }
    }
}
