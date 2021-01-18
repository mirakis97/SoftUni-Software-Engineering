using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Radioactive_Mutant_Vampire_Bunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] demensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int n = demensions[0];
            int m = demensions[1];
            char[,] field = new char[n, m];

            int playerRow = -1;
            int playerCol = -1;
            for (int row = 0; row < n; row++)
            {
                char[] rowData = Console.ReadLine().ToCharArray();
                for (int col = 0; col < m; col++)
                {
                    field[row, col] = rowData[col];

                    if (field[row, col] == 'p')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }
            char[] directions = Console.ReadLine().ToCharArray();
            bool isWon = false;
            bool isDead = false;
            foreach (char direction in directions)
            {
                int newPlayerRow = playerRow;
                int newPlayerCol = playerCol;


                if (direction == 'U')
                {
                    newPlayerRow--;
                }
                else if (direction == 'D')
                {
                    newPlayerRow++;
                }
                else if (direction == 'L')
                {
                    newPlayerCol--;
                }
                else if (direction == 'R')
                {
                    newPlayerCol++;
                }


                if (isValidCell(newPlayerRow, newPlayerCol, n ,m))
                {
                    isWon = true;

                }
                else if (field[newPlayerRow,newPlayerCol] == '-')
                {
                    field[playerRow, playerCol] = '-';
                    field[newPlayerRow, newPlayerCol] = 'P';
                    playerRow = newPlayerRow;
                    playerCol = newPlayerCol;
                }
                else if (field[newPlayerRow, newPlayerCol] == 'B')
                {
                    isDead = true;
                    field[playerRow, playerCol] = '-';
                    playerRow = newPlayerRow;
                    playerCol = newPlayerCol;
                }

                List<int[]> bunniesCordinates = GetBunniesCoordinates(field);
                SpreadBunnies(bunniesCordinates, field);
            }
        }

        private static List<int[]> GetBunniesCoordinates(char[,] field)
        {
            List<int[]> bunniesCordinates = new List<int[]>();
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {

                        playerRow = row;
                        playerCol = col;
                }
            }


        }

        private static bool isValidCell(int row, int col, int n, int m)
        {
            return row >= 0 && row < n && col >= 0 && col < m;
        }
    }
}
