namespace Shortest_Path_Between_All_Nde_Pairs
{
    using System;
    using System.Linq;

    class ShortestPath
    {
        private const double Inf = double.PositiveInfinity;

        static void Main()
        {
            int verticeCount = int.Parse(Console.ReadLine().Substring(7));
            var graph = new double[verticeCount, verticeCount];
            for (int row = 0; row < verticeCount; row++)
            {
                for (int col = 0; col < verticeCount; col++)
                {
                    graph[row, col] = Inf;
                }
            }

            int edges = int.Parse(Console.ReadLine().Substring(7));
            for (int i = 0; i < edges; i++)
            {
                var tokens = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                graph[tokens[0], tokens[1]] = tokens[2];
                graph[tokens[1], tokens[0]] = tokens[2];
            }

            var distances = graph.Clone() as double[,];
            var v = graph.GetLength(0);
            for (int k = 0; k < v; k++)
            {
                for (int i = 0; i < v; i++)
                {
                    for (int j = 0; j < v; j++)
                    {
                        if (i == j)
                        {
                            distances[i, j] = 0;
                        }
                        else if (distances[i, k] + distances[k, j] < distances[i, j])
                        {
                            distances[i, j] = distances[i, k] + distances[k, j];
                        }
                    }
                }
            }

            Console.WriteLine("Shortest paths matrix:");
            for (int i = 0; i < verticeCount; i++)
            {
                Console.Write("{0,4}", i);
            }

            Console.WriteLine();
            Console.WriteLine(new String('-', verticeCount*4));

            for (int row = 0; row < verticeCount; row++)
            {
                for (int col = 0; col < verticeCount; col++)
                {
                    Console.Write("{0,4}", distances[row, col]);
                }

                Console.WriteLine();
            }

        }
    }
}
