using System;
using System.Linq;

namespace Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int row = dimensions[0];
            int col = dimensions[1];
            int[,] matrix = new int[row, col];
            string input;
            while ((input = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                int[] numbers = input.Split().Select(int.Parse).ToArray();
                int currRow = numbers[0];
                int currCol = numbers[1];

                int rowToChange = currRow;
                int colToChange = currCol;
                if (Check(row, col, currRow, currCol))
                {
                    while (rowToChange >= 0) //up
                    {
                        matrix[rowToChange, colToChange]++;
                        rowToChange--;
                    }
                    rowToChange = currRow + 1;
                    while (rowToChange < row) //down
                    {
                        matrix[rowToChange, colToChange]++;
                        rowToChange++;
                    }
                    rowToChange = currRow;
                    colToChange--;
                    while (colToChange >= 0)//left
                    {
                        matrix[rowToChange, colToChange]++;
                        colToChange--;
                    }
                    colToChange = currCol + 1;
                    while (colToChange < col)//right
                    {
                        matrix[rowToChange, colToChange]++;
                        colToChange++;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }
            }
            PrintMatrix(matrix);
        }
        public static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
        public static bool Check(int row, int col, int initialRow, int initialCol)
        {
            if ((initialRow >= 0 && initialRow < row) && (initialCol >= 0 && initialCol < col))
            {
                return true;
            }
            return false;
        }
    }
}