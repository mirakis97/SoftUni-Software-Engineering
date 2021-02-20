using System;
using System.Linq;

namespace Warships
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            string[] coordinates = Console.ReadLine()
                .Split(",");

            int firstPlayerShip = 0;
            int secondPlayerShip = 0;

            for (int row = 0; row < n; row++)
            {
                string[] rowData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < n; col++)
                {
                    char element = char.Parse(rowData[col]);

                    if (element == '<')
                    {
                        firstPlayerShip++;
                    }

                    if (element == '>')
                    {
                        secondPlayerShip++;
                    }

                    matrix[row, col] = element;
                }
            }

            int startCountShipFirst = firstPlayerShip;
            int startCountShipSecond = secondPlayerShip;

            for (int i = 0; i < coordinates.Length; i++)
            {

                if (firstPlayerShip <= 0 || secondPlayerShip <= 0)
                {
                    break;
                }

                string[] coordinate = coordinates[i]
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                int row = int.Parse(coordinate[0]);
                int col = int.Parse(coordinate[1]);

                if (IsValidCoordinates(row, col, n) == false)
                {
                    continue;
                }

                if (i % 2 == 0) //first
                {
                    if (matrix[row, col] == '>')
                    {
                        matrix[row, col] = 'X';
                        secondPlayerShip--;
                    }

                    if (matrix[row, col] == '#')
                    {
                        matrix = Mine(ref firstPlayerShip, ref secondPlayerShip, row, col, matrix, n);
                    }
                }
                else //second
                {
                    if (matrix[row, col] == '<')
                    {
                        matrix[row, col] = 'X';
                        firstPlayerShip--;
                    }

                    if (matrix[row, col] == '#')
                    {
                        matrix = Mine(ref firstPlayerShip, ref secondPlayerShip, row, col, matrix, n);
                    }
                }
            }

            //ouPut
            if (firstPlayerShip <= 0 || secondPlayerShip <= 0)
            {
                if (firstPlayerShip > 0)
                {
                    int allDestroy = startCountShipSecond + (startCountShipFirst - firstPlayerShip);
                    Console.WriteLine($"Player One has won the game! {allDestroy} ships have been sunk in the battle.");
                }
                else
                {
                    int allDestroy = startCountShipFirst + (startCountShipSecond - secondPlayerShip);
                    Console.WriteLine($"Player Two has won the game! {allDestroy} ships have been sunk in the battle.");
                }
            }
            else
            {
                Console.WriteLine($"It's a draw! Player One has {firstPlayerShip} ships left. Player Two has {secondPlayerShip} ships left.");
            }


        }

        static bool IsValidCoordinates(int row, int col, int n)
        {
            return row >= 0 && row < n && col >= 0 && col < n;
        }

        static void IsHaveAShip(ref int firstShips, ref int secondShips, char character)
        {
            if (character == '<')
            {
                firstShips--;
            }

            if (character == '>')
            {
                secondShips--;
            }
        }

        static char[,] Mine(ref int firstPlayerShip, ref int secondPlayerShip, int row, int col, char[,] matrix, int n)
        {
            int coordinateRow;
            int coordinateCol;

            if (IsValidCoordinates(row - 1, col, n)) //up
            {
                coordinateRow = row - 1;
                IsHaveAShip(ref firstPlayerShip, ref secondPlayerShip, matrix[coordinateRow, col]);
                matrix[coordinateRow, col] = 'X';
            }

            if (IsValidCoordinates(row + 1, col, n)) //down
            {
                coordinateRow = row + 1;
                IsHaveAShip(ref firstPlayerShip, ref secondPlayerShip, matrix[coordinateRow, col]);
                matrix[coordinateRow, col] = 'X';
            }

            if (IsValidCoordinates(row, col + 1, n)) //right
            {
                coordinateCol = col + 1;
                IsHaveAShip(ref firstPlayerShip, ref secondPlayerShip, matrix[row, coordinateCol]);
                matrix[row, coordinateCol] = 'X';
            }

            if (IsValidCoordinates(row, col - 1, n)) //left
            {
                coordinateCol = col - 1;
                IsHaveAShip(ref firstPlayerShip, ref secondPlayerShip, matrix[row, coordinateCol]);
                matrix[row, coordinateCol] = 'X';
            }

            if (IsValidCoordinates(row - 1, col - 1, n)) //leftUp
            {
                coordinateRow = row - 1;
                coordinateCol = col - 1;
                IsHaveAShip(ref firstPlayerShip, ref secondPlayerShip, matrix[coordinateRow, coordinateCol]);
                matrix[coordinateRow, coordinateCol] = 'X';
            }

            if (IsValidCoordinates(row - 1, col + 1, n)) //rightUp
            {
                coordinateRow = row - 1;
                coordinateCol = col + 1;
                IsHaveAShip(ref firstPlayerShip, ref secondPlayerShip, matrix[coordinateRow, coordinateCol]);
                matrix[coordinateRow, coordinateCol] = 'X';
            }

            if (IsValidCoordinates(row + 1, col - 1, n)) //downleft
            {
                coordinateRow = row + 1;
                coordinateCol = col - 1;
                IsHaveAShip(ref firstPlayerShip, ref secondPlayerShip, matrix[coordinateRow, coordinateCol]);
                matrix[coordinateRow, coordinateCol] = 'X';
            }

            if (IsValidCoordinates(row + 1, col + 1, n)) //downRight
            {
                coordinateRow = row + 1;
                coordinateCol = col + 1;
                IsHaveAShip(ref firstPlayerShip, ref secondPlayerShip, matrix[coordinateRow, coordinateCol]);
                matrix[coordinateRow, coordinateCol] = 'X';
            }

            matrix[row, col] = 'X';

            return matrix;
        }
    }
}