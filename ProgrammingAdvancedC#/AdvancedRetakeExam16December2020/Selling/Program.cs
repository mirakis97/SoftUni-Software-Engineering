using System;

namespace Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            for (int row = 0; row < n; row++)
            {
                string currentRow = Console.ReadLine();
                for (int col = 0; col < currentRow.Length; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            int bakeryRow = 0;
            int bakeryCol = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == 'S')
                    {
                        bakeryRow = row;
                        bakeryCol = col;
                    }
                }
            }

            string input = Console.ReadLine();
            int money = 0;
            while (true)
            {
                matrix[bakeryRow, bakeryCol] = '-';
                bakeryRow = MoveRow(bakeryRow, input);
                bakeryCol = MoveCol(bakeryCol, input);
                if (!IsPositionValid(bakeryRow, bakeryCol, n, n))
                {
                    Console.WriteLine("Bad news, you are out of the bakery.");
                    Console.WriteLine($"Money: {money}");
                    break;
                }

                if (char.IsDigit(matrix[bakeryRow, bakeryCol]))
                {
                    money += int.Parse(matrix[bakeryRow, bakeryCol].ToString());
                }
                else if (matrix[bakeryRow, bakeryCol] == 'O')

                {
                    matrix[bakeryRow, bakeryCol] = '-';
                    for (int rows = 0; rows < n; rows++)
                    {
                        for (int cols = 0; cols < n; cols++)
                        {
                            if (matrix[rows, cols] == 'O')
                            {
                                matrix[rows, cols] = '-';
                                bakeryRow = rows;
                                bakeryCol = cols;
                            }
                        }
                    }
                }
                if (money >= 50)
                {
                    Console.WriteLine("Good news! You succeeded in collecting enough money!");
                    Console.WriteLine($"Money: {money}");
                    matrix[bakeryRow, bakeryCol] = 'S';
                    break;
                }
                input = Console.ReadLine();
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
        public static int MoveRow(int row, string movement)
        {
            if (movement == "up")
            {
                return row - 1;
            }
            if (movement == "down")
            {
                return row + 1;
            }

            return row;
        }
        public static bool IsPositionValid(int row, int col, int rows, int cols)
        {
            if (row < 0 || row >= rows)
            {
                return false;
            }
            if (col < 0 || col >= cols)
            {
                return false;
            }

            return true;
        }
        public static int MoveCol(int col, string movement)
        {
            if (movement == "left")
            {
                return col - 1;
            }
            if (movement == "right")
            {
                return col + 1;
            }

            return col;
        }
    }
}
