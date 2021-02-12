using System;

namespace _02Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matirx = new char[n,n];

            for (int row = 0; row < n; row++)
            {
                string currentRow = Console.ReadLine();

                for (int col = 0; col < currentRow.Length; col++)
                {
                    matirx[row, col] = currentRow[col];
                }
            }
            int beeRow = 0;
            int beeCol = 0;
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matirx[row,col] == 'B')
                    {
                        beeRow = row;
                        beeCol = col;
                    }
                }
            }

            string input = Console.ReadLine();
            int flowers = 0;
            while (input != "End")
            {
                matirx[beeRow, beeCol] = '.';
                beeRow = MoveRow(beeRow, input);
                beeCol = MoveCol(beeCol, input);

                if (!IsPositionValid(beeRow,beeCol,n,n))
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }

                if (matirx[beeRow,beeCol] == 'f')
                {
                    flowers++;
                }
                if (matirx[beeRow, beeCol] == 'O')
                {
                    matirx[beeRow, beeCol] = '.';
                    beeRow = MoveRow(beeRow, input);
                    beeCol = MoveCol(beeCol, input);
                    if (matirx[beeRow, beeCol] == 'f')
                    {
                        flowers++;
                    }
                }
                matirx[beeRow, beeCol] = 'B';
                input = Console.ReadLine();
            }


            if (flowers < 5)
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - flowers} flowers more");
            }
            else
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {flowers} flowers!");
            }
            for (int row = 0; row < matirx.GetLength(0); row++)
            {
                for (int col = 0; col < matirx.GetLength(1); col++)
                {
                    Console.Write(matirx[row,col]);
                }
                Console.WriteLine();
            }
        }
        public static bool IsPositionValid(int row,int col,int rows,int cols)
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
        public static int MoveRow(int row,string movement)
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
