namespace Shortest_Paths_With_Negative_Edges
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ShortestPathsWithNegativeEdges
    {
        private static int[] previous;

        static void Main()
        {
            int nodesCount = int.Parse(Console.ReadLine().Substring(7));
            var pathInfo = Console.ReadLine()
                .Substring(6)
                .Split(new char[] {' ', '-'}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int start = pathInfo[0];
            int destination = pathInfo[1];
            int edgesCount = int.Parse(Console.ReadLine().Substring(7));
            var edges = new List<Edge>();
            for (int i = 0; i < edgesCount; i++)
            {
                var tokens = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();
                var edge = new Edge(tokens[0], tokens[1], tokens[2]);
                edges.Add(edge);
            }

            FindShortestPathBellmanFord(start, destination, nodesCount, edges);
        }

        private static int[] ReconstructPath(int start, int destination)
        {
            var path = new List<int>();
            int currentNode = destination;
            path.Add(currentNode);
            while (currentNode != start)
            {
                path.Add(previous[currentNode]);
                currentNode = previous[currentNode];
            }

            path.Reverse();
            return path.ToArray();
        }

        private static void FindShortestPathBellmanFord(int startNode, int destination, int verticeCount, List<Edge> edges)
        {
            var distance = new double[verticeCount];
            previous = new int[verticeCount];
            for (int i = 0; i < verticeCount; i++)
            {
                previous[i] = -1;
            }

            for (int i = 0; i < distance.Length; i++)
            {
                distance[i] = double.PositiveInfinity;
            }

            distance[startNode] = 0;

            for (int i = 0; i < verticeCount - 1; i++)
            {
                foreach (Edge edge in edges)
                {
                    if (distance[edge.Start] + edge.Distance < distance[edge.End])
                    {
                        distance[edge.End] = distance[edge.Start] + edge.Distance;
                        previous[edge.End] = edge.Start;
                    }
                }
            }

            for (int i = 0; i < verticeCount - 1; i++)
            {
                foreach (Edge edge in edges)
                {
                    if (distance[edge.Start] + edge.Distance < distance[edge.End])
                    {
                        int[] cycle = ReconstructPath(edge.End, edge.Start);
                        Console.WriteLine("Negative cycle detected: {0}", string.Join(" -> ", cycle));
                        return;
                    }
                }
            }

            Console.WriteLine("Distance [{0} -> {1}]: {2}", startNode, destination, (int)distance[destination]);
            int[] path = ReconstructPath(startNode, destination);
            Console.WriteLine("Path: {0}", string.Join(" -> ", path));
        }
    }
}
