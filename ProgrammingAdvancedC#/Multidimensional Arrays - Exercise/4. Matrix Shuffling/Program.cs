using System;
using System.Linq;

namespace _4._Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] demensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int n = demensions[0];
            int m = demensions[1];


            string[,] matrix = new string[n,m];

            for (int row = 0; row < n; row++)
            {
                string[] rowData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < m; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            string comand = Console.ReadLine();

            while (comand != "END")
            {
                string[] comandData = comand.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (comandData.Length != 5 || comandData[0] != "swap")
                {
                    Console.WriteLine("Invalid input!");
                    comand = Console.ReadLine();
                    continue;
                }
                int rowOne = int.Parse(comandData[1]);
                int colOne = int.Parse(comandData[2]);
                int rowTwo = int.Parse(comandData[3]);
                int colTwo = int.Parse(comandData[4]);

                bool isValidOne = rowOne >= 0 && rowOne < n && colOne >= 0 && colOne < m;
                bool isValidTwo = rowTwo >= 0 && rowTwo < n && colTwo >= 0 && colTwo < m;


                if (!isValidOne || !isValidTwo)
                {
                    Console.WriteLine("Invalid input!");
                    comand = Console.ReadLine();
                    continue;
                }
                string valueOne = matrix[rowOne, colOne];
                string valueTwo = matrix[rowTwo, colTwo];

                matrix[rowOne, colOne] = valueTwo;
                matrix[rowTwo, colTwo] = valueOne;

                for (int row = 0; row < n; row++)
                {

                    for (int col = 0; col < m; col++)
                    {
                        Console.Write(matrix[row, col] + " ");
                    }
                    Console.WriteLine();
                }
                comand = Console.ReadLine();
            }
        }
    }
}
