namespace Move_Down_Right_Sum_Problem
{
    using System;

    class MoveDownRightSum
    {
        static void Main()
        {
            int[,] matrix =
            {
                {2, 6, 1, 8, 9, 4, 2},
                {1, 8, 0, 3, 5, 6, 7},
                {3, 4, 8, 7, 2, 1, 8},
                {0, 9, 2, 8, 1, 7, 9},
                {2, 7, 1, 9, 7, 8, 2}, 
                {4, 5, 6, 1, 2, 5, 6},
                {9, 3, 5, 2, 8, 1, 9},
                {2, 3, 4, 1, 7, 2, 8}
            };

            int totalRows = matrix.GetLength(0);
            int totalCols = matrix.GetLength(1);

            var sums = CalculateSums(totalRows, totalCols, matrix);

            var path = MarkPath(totalRows, totalCols, sums);

            PrintPath(totalRows, totalCols, path, matrix);
            Console.WriteLine("{0}======================{0}", Environment.NewLine);
            PrintPath(totalRows, totalCols, path, sums );
            Console.WriteLine();
        }

        private static int[,] CalculateSums(int totalRows, int totalCols, int[,] matrix)
        {
            int[,] sums = new int[totalRows, totalCols];
            sums[0, 0] = matrix[0, 0];

            for (int row = 1; row < totalRows; row++)
            {
                sums[row, 0] = sums[row - 1, 0] + matrix[row, 0];
            }

            for (int column = 1; column < totalCols; column++)
            {
                sums[0, column] = sums[0, column - 1] + matrix[0, column];
            }

            for (int row = 1; row < totalRows; row++)
            {
                for (int column = 1; column < totalCols; column++)
                {
                    int highSum = Math.Max(sums[row, column - 1], sums[row - 1, column]);
                    sums[row, column] = highSum + matrix[row, column];
                }
            }
            return sums;
        }

        private static bool[,] MarkPath(int totalRows, int totalCols, int[,] sums)
        {
            var path = new bool[totalRows, totalCols];
            int currentRow = totalRows - 1;
            int currentCol = totalCols - 1;
            path[currentRow, currentCol] = true;
            while (currentRow != 0 && currentCol != 0)
            {
                if (currentRow == 0)
                {
                    currentCol--;
                }
                else if (currentCol == 0)
                {
                    currentRow--;
                }
                else if (sums[currentRow - 1, currentCol] > sums[currentRow, currentCol - 1])
                {
                    currentRow--;
                }
                else
                {
                    currentCol--;
                }
                path[currentRow, currentCol] = true;
            }
            path[0, 0] = true;
            return path;
        }

        private static void PrintPath(int totalRows, int totalCols, bool[,] path, int[,] sums)
        {
            for (int i = 0; i < totalRows; i++)
            {
                for (int j = 0; j < totalCols; j++)
                {
                    if (path[i, j])
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Write("{0, 3}", sums[i, j]);
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Black;
        }
    }
}
