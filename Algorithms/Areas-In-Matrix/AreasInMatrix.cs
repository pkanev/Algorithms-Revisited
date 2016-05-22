namespace Areas_In_Matrix
{
    using System;
    using System.Collections.Generic;

    class AreasInMatrix
    {
        private static char[,] matrix;
        private static bool[,] visited;

        static void Main()
        {
            int rows = int.Parse(Console.ReadLine().Substring(16));
            string[] lines = new string[rows];
            for (int i = 0; i < rows; i++)
            {
                lines[i] = Console.ReadLine();
            }

            //int rows = int.Parse("Number of rows: 6".Substring(16));
            //var lines = new string[]
            //{
            //    "aacccaac",
            //    "baaaaccc", 
            //    "baabaccc",
            //    "bbdaaccc",
            //    "ccdccccc",
            //    "ccdccccc"
            //};

            int cols = lines[0].Length;
            matrix = new char[rows, cols];
            visited = new bool[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = lines[row][col];
                }
            }

            var mappedAreas = new SortedDictionary<char, int>();
            int areas = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (!visited[row, col])
                    {
                        char label = matrix[row, col];
                        if (!mappedAreas.ContainsKey(label))
                        {
                            mappedAreas[label] = 0;
                        }

                        mappedAreas[label] ++;

                        MarkArea(label, row, col);
                        areas++;
                    }
                }
            }

            Console.WriteLine("Areas: {0}", areas);
            foreach (var area in mappedAreas)
            {
                Console.WriteLine("Letter '{0}' -> {1}", area.Key, area.Value);
            }

        }

        private static void MarkArea(char label, int row, int col)
        {
            if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1))
            {
                return;
            }

            if (matrix[row, col] != label)
            {
                return;
            }

            if (visited[row, col])
            {
                return;
            }

            visited[row, col] = true;
            MarkArea(label, row - 1, col);
            MarkArea(label, row + 1, col);
            MarkArea(label, row, col - 1);
            MarkArea(label, row, col + 1);
        }
    }
}
