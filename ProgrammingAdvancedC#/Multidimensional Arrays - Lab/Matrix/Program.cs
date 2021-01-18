using System;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[,]
            {
                {1,2,34,5 },
                {1,2,12,5}
            };
            matrix[0, 0] = 5;
            matrix[0, 1] = 7;
            matrix[1, 0] = 3;
            matrix[1, 1] = 4;

            int[,,,,] nDimension = new int[2, 2, 2, 2,2];
        }
    }
}
