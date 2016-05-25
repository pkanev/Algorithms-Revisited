namespace Modified_Kruskal_Algorithm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class KruskalTest
    {
        static void Main()
        {
            int numberOfVertices = int.Parse(Console.ReadLine().Substring(7));
            int numberOfEdges = int.Parse(Console.ReadLine().Substring(7));
            var graphEdges = new List<Edge>();

            for (int i = 0; i < numberOfEdges; i++)
            {
                var tokens = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();
                graphEdges.Add(new Edge(tokens[0], tokens[1], tokens[2]));
            }

            var minimumSpanningForest = ModifiedKruskalAlgorithm.Kruskal(numberOfVertices, graphEdges);

            Console.WriteLine("Minimum spanning forest weight: " +
                            minimumSpanningForest.Sum(e => e.Weight));

            foreach (var edge in minimumSpanningForest)
            {
                Console.WriteLine(edge);
            }
        }
    }
}
