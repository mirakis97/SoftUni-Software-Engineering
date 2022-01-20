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
            var n = int.Parse(Console.ReadLine());

            graph = new List<int>[n];
            visited = new bool[n];
            IList<IList<int>> set;
            for (int node = 0; node < n; node++)
            {
                var line = Console.ReadLine();

                if (string.IsNullOrEmpty(line))
                {
                    graph[node] = new List<int>();
                }
                else
                {
                    var childer = line.Split()
                        .Select(int.Parse)
                        .ToList();

                    graph[node] = childer;
                }
                
            }


            set = AllPathsSourceTarget(graph);
            foreach (var item in set)
            {
                Console.WriteLine(string.Join(" ", item));
            }

        }
        public static IList<IList<int>> AllPathsSourceTarget(List<int>[] graph)
        {

            List<IList<int>> res = new List<IList<int>>();
            if (graph == null || graph.Length == 0)
                return res;

            DFS(graph, res, new List<int>() { 0 }, 0);
            DFS(graph, res, new List<int>() , 0);
            DFS(graph, res, new List<int>(), 1);

            return res;
        }

        private static void DFS(List<int>[] graph, List<IList<int>> res, List<int> path, int i)
        {
            if (i == graph.Length - 1)
            {
                res.Add(new List<int>(path));
                return;
            }

            foreach (var next in graph[i])
            {
                path.Add(next);
                DFS(graph, res, path, next);
                path.RemoveAt(path.Count - 1);
            }
        }
    }
}
