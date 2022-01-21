using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Climbing
{
    public class Program
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            var matrix = ReadMatrix(rows, cols);

            var sums = CalcSums(matrix);

            var startRow = 0;
            var startCol = 0;

            var result = new Stack<int>();
            result.Push(matrix[startRow, startCol]);

            while (startRow < rows - 1 && startCol < cols - 1)
            {
                if (sums[startRow + 1, startCol] > sums[startRow, startCol + 1])
                {
                    startRow++;
                }
                else
                {
                    startCol++;
                }

                result.Push(matrix[startRow, startCol]);
            }

            while (startRow < rows - 1)
            {
                startRow++;
                result.Push(matrix[startRow, startCol]);
            }

            while (startCol < cols - 1)
            {
                startCol++;
                result.Push(matrix[startRow, startCol]);
            }


            Console.WriteLine(sums[0, 0]);
            Console.WriteLine(String.Join(' ', result));

        }

        private static int[,] CalcSums(int[,] matrix)
        {
            var sums = new int[matrix.GetLength(0), matrix.GetLength(1)];

            sums[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1] = matrix[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];

            for (int row = matrix.GetLength(0) - 2; row >= 0; row--)
            {
                sums[row, matrix.GetLength(1) - 1]
                    = sums[row + 1, matrix.GetLength(1) - 1] + matrix[row, matrix.GetLength(1) - 1];
            }

            for (int col = matrix.GetLength(1) - 2; col >= 0; col--)
            {
                sums[matrix.GetLength(0) - 1, col]
                    = sums[matrix.GetLength(0) - 1, col + 1] + matrix[matrix.GetLength(0) - 1, col];
            }

            for (int row = matrix.GetLength(0) - 2; row >= 0; row--)
            {
                for (int col = matrix.GetLength(1) - 2; col >= 0; col--)
                {
                    sums[row, col] = matrix[row, col] + Math.Max(sums[row + 1, col], sums[row, col + 1]);
                }
            }

            return sums;
        }

        private static int[,] ReadMatrix(int rows, int cols)
        {
            var matrix = new int[rows, cols];


            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var rowData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            return matrix;
        }
    }
}