using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Path_Finder
{
    public class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;
        static void Main(string[] args)
        {
            var nodes = int.Parse(Console.ReadLine());

            graph = new List<int>[nodes];


            for (int node = 0; node < nodes; node++)
            {
                var line = Console.ReadLine();

                if (string.IsNullOrEmpty(line))
                {
                    graph[node] = new List<int>();
                }
                else
                {
                    var children = line.Split()
                        .Select(int.Parse)
                        .ToList();
                    graph[node] = children;
                }
            }

            var pathsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < pathsCount; i++)
            {
                var path = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                visited = new bool[nodes];

                var startPathIdx = 0;
                var startNode = path[0];

                DFS(startNode, path, startPathIdx);
                if (PathxExist(path, visited))
                {
                    Console.WriteLine("yes");
                }
                else
                {
                    Console.WriteLine("no");
                }
            }
        }

        private static bool PathxExist(int[] path, bool[] visited)
        {
            foreach (var node in path)
            {
                if (!visited[node])
                {
                    return false;
                }
            }
            return true;
        }

        private static void DFS(int startNode, int[] path, int startPathIdx)
        {
            if (visited[startNode] || startPathIdx >= path.Length || startNode != path[startPathIdx])
            {
                return;
            }
            visited[startNode] = true;

            foreach (var child in graph[startNode])
            {
                DFS(child,path,startPathIdx + 1);
            }
        }
    }
}
