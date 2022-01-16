using System;

namespace _01._TBC
{
    public class Program
    {
        private const char visitedSymbol = 'v';
        private const char dirtSymbol = 'd';
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            var map = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var rowElements = Console.ReadLine();
                for (int col = 0; col < rowElements.Length; col++)
                {
                    map[row, col] = rowElements[col];
                }
            }
            var tunels = 0;
            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int col = 0; col < map.GetLength(1); col++)
                {
                    if (map[row,col] == visitedSymbol || map[row, col] == dirtSymbol)
                    {
                        continue;
                    }
                    ExploreTunnel(map, row, col);

                    tunels += 1;
                }
            }

            Console.WriteLine(tunels);
        }

        private static void ExploreTunnel(char[,] map, int row, int col)
        {
            if (IsOutSide(map, row, col))
            {
                return;
            }
            if (map[row,col] == visitedSymbol || map[row, col] == dirtSymbol)
            {
                return;
            }
            map[row,col] = visitedSymbol;

            ExploreTunnel(map,row - 1,col);
            ExploreTunnel(map,row + 1,col);
            ExploreTunnel(map,row,col - 1);
            ExploreTunnel(map,row,col + 1);
            ExploreTunnel(map,row - 1,col - 1);
            ExploreTunnel(map,row - 1,col + 1);
            ExploreTunnel(map,row + 1,col - 1);
            ExploreTunnel(map,row + 1,col + 1);
        }

        private static bool IsOutSide(char[,] map, int row, int col)
        {
            return row < 0 || col < 0 || row >= map.GetLength(0) || col >= map.GetLength(1); ;
        }
    }
}
