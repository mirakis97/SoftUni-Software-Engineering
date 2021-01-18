using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double[][] jaggedMatrix = new double[n][];

            for (int row = 0; row < n; row++)
            {
                double[] rowData = Console.ReadLine().Split().Select(double.Parse).ToArray();
                jaggedMatrix[row] = rowData;
            }
            for (int row = 0; row < n - 1; row++)
            {
                double[] firstArr = jaggedMatrix[row];
                double[] secindArr = jaggedMatrix[row + 1];
                if (firstArr.Length == secindArr.Length)
                {
                    jaggedMatrix[row] = firstArr.Select(e => e * 2).ToArray();
                    jaggedMatrix[row + 1] = secindArr.Select(e => e * 2).ToArray();
                }
                else
                {
                    jaggedMatrix[row] = firstArr.Select(e => e / 2).ToArray();
                    jaggedMatrix[row + 1] = secindArr.Select(e => e / 2).ToArray();
                }
            }


            string comand = Console.ReadLine();

            while (comand != "End")
            {
                string[] comandData = comand.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                int rowIndex = int.Parse(comandData[1]);
                int colIndex = int.Parse(comandData[2]);
                int value = int.Parse(comandData[3]);

                bool isValidCell = rowIndex >= 0 && rowIndex < n && colIndex >= 0 && colIndex < jaggedMatrix[rowIndex].Length;

                if (!isValidCell)
                {
                    comand = Console.ReadLine();
                    continue;
                }
                if (comandData[0] == "Add")
                {
                    jaggedMatrix[rowIndex][colIndex] += value;
                }
                else if (comandData[0] == "Subtract")
                {
                    jaggedMatrix[rowIndex][colIndex] -= value;
                }

                comand = Console.ReadLine();
            }

            for (int row = 0; row < n; row++)
            {
                Console.WriteLine(string.Join(" ", jaggedMatrix[row]));
            }
        }
    }
}
