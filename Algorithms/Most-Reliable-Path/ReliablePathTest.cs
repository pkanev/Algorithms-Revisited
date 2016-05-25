namespace Most_Reliable_Path
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ReliablePathTest
    {
        static void Main()
        {
            int numberOfNodes = int.Parse(Console.ReadLine().Substring(7));
            var nodes = new Dictionary<int, Node>();
            for (int i = 0; i < numberOfNodes; i++)
            {
                nodes[i] = new Node(i);
            }

            var pathInfo = Console.ReadLine()
                .Substring(6)
                .Trim()
                .Split(new char[] {' ', '-'}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int startNode = pathInfo[0];
            int endNode = pathInfo[1];

            int numberOfEdges = int.Parse(Console.ReadLine().Substring(7));
            var graph = new Dictionary<Node, Dictionary<Node, int>>();
            for (int i = 0; i < numberOfEdges; i++)
            {
                var tokens = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();
                var start = tokens[0];
                var destination = tokens[1];
                var reliability = tokens[2];

                if (!graph.ContainsKey(nodes[start]))
                {
                    graph[nodes[start]] = new Dictionary<Node, int>();
                }

                if (!graph.ContainsKey(nodes[destination]))
                {
                    graph[nodes[destination]] = new Dictionary<Node, int>();
                }

                graph[nodes[start]][nodes[destination]] = reliability;
                graph[nodes[destination]][nodes[start]] = reliability;
            }
            
            var path = Dijkstra.DijkstraAlgorithm(graph, nodes[startNode], nodes[endNode]);

            if (path == null)
            {
                Console.WriteLine("no path");
            }
            else
            {
                Console.WriteLine("Most reliable path reliability: {0:F2}%", nodes[endNode].ReliabilityFromStart * 100);
                var formattedPath = string.Join(" -> ", path);
                Console.WriteLine(formattedPath);
            }
        }
    }
}
