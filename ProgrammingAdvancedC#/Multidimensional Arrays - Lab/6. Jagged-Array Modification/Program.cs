﻿using System;

namespace _6._Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                var input = Console.ReadLine().Split();
                for (int col = 0; col < input.Length; col++)
                {
                    matrix[row, col] = int.Parse(input[col]);
                }
            }

            string comand = Console.ReadLine();

            while (comand != "END")
            {
                var splitted = comand.Split();
                int row = int.Parse(splitted[1]);
                int col = int.Parse(splitted[2]);
                int value = int.Parse(splitted[3]);

                if (row >= 0 && col >= 0 && row < n && col < n)
                {
                    if (splitted[0] == "Add")
                    {
                        matrix[row, col] += value;
                    }
                    if (splitted[0] == "Subtract")
                    {
                        matrix[row, col] -= value;
                    }
                }
                else 
                {
                    Console.WriteLine("Invalid coordinates");
                }

                comand = Console.ReadLine();
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row,col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
