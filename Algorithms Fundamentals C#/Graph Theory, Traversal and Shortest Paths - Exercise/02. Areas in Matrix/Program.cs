using System;
using System.Collections.Generic;

namespace _02._Areas_in_Matrix
{
    public class Program
    {
        private static char[,] graph;
        private static bool[,] visited;
        private static SortedDictionary<char, int> areas;
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            graph = new char[rows, cols];
            visited = new bool[rows, cols];
            areas = new SortedDictionary<char, int>();
            var areasCount = 0;
            for (int r = 0; r < rows; r++)
            {
                var rowElements = Console.ReadLine();

                for (int c = 0; c < cols; c++)
                {
                    graph[r, c] = rowElements[c];
                }
            }

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (visited[r, c])
                    {
                        continue;
                    }
                    
                    var nodeValue = graph[r, c];
                    DFS(r, c,nodeValue);

                    areasCount += 1;

                    if (areas.ContainsKey(nodeValue))
                    {
                        areas[nodeValue] += 1;
                    }
                    else
                    {
                        areas[nodeValue] = 1;
                    }
                }
            }
            Console.WriteLine($"Areas: {areasCount}");
            foreach (var kvp in areas)
            {
                Console.WriteLine($"Letter '{kvp.Key}' -> {kvp.Value} ");
            }
        }

        private static void DFS(int row, int col, char nodeValue)
        {
            if (row < 0 || row >= graph.GetLength(0) || col < 0 || col >= graph.GetLength(1))
            {
                return;
            }
            if (visited[row,col])
            {
                return;
            }

            if (graph[row,col] != nodeValue)
            {
                return;
            }

            visited[row, col] = true;

            DFS(row,col - 1,nodeValue);
            DFS(row,col + 1,nodeValue);
            DFS(row + 1,col,nodeValue);
            DFS(row - 1,col,nodeValue);
        }
    }
}
