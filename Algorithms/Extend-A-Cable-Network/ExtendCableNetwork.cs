namespace Extend_A_Cable_Network
{
    using System;
    using System.Collections.Generic;

    class ExtendCableNetwork
    {
        static void Main()
        {
            int budgetCount = int.Parse(Console.ReadLine().Substring(7));
            int nodesCount = int.Parse(Console.ReadLine().Substring(7));
            int edgesCount = int.Parse(Console.ReadLine().Substring(7));
            var connectedNodes = new HashSet<int>();
            var edges = new Edge[edgesCount];

            var graph = BuildGraph(nodesCount, edgesCount, connectedNodes);

            var priorityQueue = CreateInitialPriorityQueue(graph, connectedNodes);

            int budgetUsed = 0;
            while (priorityQueue.Count > 0)
            {
                var smallestEdge = priorityQueue.ExtractMin();
                if (smallestEdge.Cost > budgetCount)
                {
                    break;
                }

                if (connectedNodes.Contains(smallestEdge.EndNode))
                {
                    continue;
                }

                budgetCount -= smallestEdge.Cost;
                budgetUsed += smallestEdge.Cost;
                connectedNodes.Add(smallestEdge.EndNode);
                Console.WriteLine(smallestEdge);
                foreach (var edge in graph[smallestEdge.EndNode])
                {
                    if (!connectedNodes.Contains(edge.EndNode))
                    {
                        priorityQueue.Enqueue(edge);
                    }
                }
            }

            Console.WriteLine("Budget used: {0}", budgetUsed);
        }

        private static PriorityQueue<Edge> CreateInitialPriorityQueue(List<Edge>[] graph, HashSet<int> connectedNodes)
        {
            var priorityQueue = new PriorityQueue<Edge>();
            for (int i = 0; i < graph.Length; i++)
            {
                if (connectedNodes.Contains(i))
                {
                    foreach (var edge in graph[i])
                    {
                        if (!connectedNodes.Contains(edge.EndNode))
                        {
                            priorityQueue.Enqueue(edge);
                        }
                    }
                }
            }
            return priorityQueue;
        }

        private static List<Edge>[] BuildGraph(int nodesCount, int edgesCount, HashSet<int> connectedNodes)
        {
            var graph = new List<Edge>[nodesCount];

            for (int i = 0; i < edgesCount; i++)
            {
                string line = Console.ReadLine();

                var tokens = line.Split(' ');
                var start = int.Parse(tokens[0]);
                var end = int.Parse(tokens[1]);
                var cost = int.Parse(tokens[2]);

                if (tokens.Length == 4)
                {
                    if (!connectedNodes.Contains(start))
                    {
                        connectedNodes.Add(start);
                    }

                    if (!connectedNodes.Contains(end))
                    {
                        connectedNodes.Add(end);
                    }
                }

                if (graph[start] == null)
                {
                    graph[start] = new List<Edge>();
                }

                if (graph[end] == null)
                {
                    graph[end] = new List<Edge>();
                }

                graph[start].Add(new Edge(start, end, cost));
                graph[end].Add(new Edge(end, start, cost));
            }
            return graph;
        }

        private static Edge CreateEdgeFromInput(string line, HashSet<int> connectedNodes)
        {
            var input = line.Split(' ');
            var start = int.Parse(input[0]);
            var end = int.Parse(input[1]);
            var cost = int.Parse(input[2]);

            if (input.Length == 4)
            {
                if (!connectedNodes.Contains(start))
                {
                    connectedNodes.Add(start);
                }

                if (!connectedNodes.Contains(end))
                {
                    connectedNodes.Add(end);
                }
            }

            var edge = new Edge(start, end, cost);
            return edge;
        }
    }
}
