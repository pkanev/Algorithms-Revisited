namespace Most_Reliable_Path
{
    using System.Collections.Generic;

    public class Dijkstra
    {
        public static List<int> DijkstraAlgorithm(
            Dictionary<Node, Dictionary<Node, int>> graph,
            Node sourceNode,
            Node destinationNode)
        {
            int nodesCount = graph.Count;
            int[] previous = new int[nodesCount];
            bool[] visited = new bool[nodesCount];
            PriorityQueue<Node> priorityQueue = new PriorityQueue<Node>();

            int index = 0;
            foreach (var pair in graph)
            {
                // set distance from start to infinity
                pair.Key.ReliabilityFromStart = double.NegativeInfinity;

                // prepare the previous array
                previous[index] = -1;
                index++;
            }

            sourceNode.ReliabilityFromStart = 1;
            priorityQueue.Enqueue(sourceNode);
            visited[sourceNode.Id] = true;

            while (priorityQueue.Count > 0)
            {
                var currentNode = priorityQueue.ExtractMax();

                if (currentNode.Id == destinationNode.Id)
                {
                    break;
                }

                foreach (var edge in graph[currentNode])
                {
                    if (!visited[edge.Key.Id])
                    {
                        priorityQueue.Enqueue(edge.Key);
                        visited[edge.Key.Id] = true;
                    }

                    var reliability = currentNode.ReliabilityFromStart * edge.Value/100d;
                    if (reliability > edge.Key.ReliabilityFromStart)
                    {
                        edge.Key.ReliabilityFromStart = reliability;
                        previous[edge.Key.Id] = currentNode.Id;
                        priorityQueue.DecreaseKey(edge.Key);
                    }
                }
            }

            if (double.IsInfinity(destinationNode.ReliabilityFromStart))
            {
                return null;
            }

            List<int> path = new List<int>();
            int current = destinationNode.Id;
            while (current != -1)
            {
                path.Add(current);
                current = previous[current];
            }

            path.Reverse();
            return path;
        }
    }
}