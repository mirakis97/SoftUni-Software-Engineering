using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Paths
{
    public class Program
    {

        private static List<int>[] graph;
        private static bool[] visited;
        static void Main(string[] args)
        {
            int numberOfNodes = int.Parse(Console.ReadLine());

            List<List<int>> graph = new List<List<int>>();

            for (int line = 0; line < numberOfNodes; line++)
            {
                string childNodes = Console.ReadLine();
                if (childNodes.Length == 0)
                {
                    graph.Add(new List<int>());
                }
                else
                {
                    graph.Add(childNodes.Split(" ").Select(int.Parse).ToList());
                }
            }
            for (int startNode = 0; startNode < graph.Count() - 1; startNode++)
            {
                List<int> path = new List<int>();
                bool[] visited = new bool[graph.Count()];
                path.Add(startNode);
                findAllPathsToLastNode(startNode, graph, visited, path);
            }

        }
        private static void findAllPathsToLastNode(int currentNode, List<List<int>> graph, bool[] visited, List<int> path)
        {
            if (currentNode >= graph.Count() - 1)
            {
                foreach (int? pathNode in path)
                {
                    Console.Write("{0:D} ", pathNode);
                }
                Console.WriteLine();
                return;
            }

            if (visited[currentNode])
            {
                return;
            }

            visited[currentNode] = true;
            foreach (var childNode in graph[currentNode])
            {
                path.Add(childNode);
                findAllPathsToLastNode(childNode, graph, visited, path);
                path.RemoveAt(path.Count() - 1);
            }
            visited[currentNode] = false;

        }
    }
}