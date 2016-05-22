namespace Distance_Between_Vertices
{
    using System;
    using System.Collections.Generic;

    class DistanceBetweenVertices
    {
        private static List<int>[] graph;

        static void Main()
        {
            graph = new List<int>[]
            {
                new List<int>() {0}, //0
                new List<int> {4}, //1
                new List<int> {4}, //2
                new List<int> {4, 5}, //3
                new List<int> {6}, //4
                new List<int> {3, 7, 8}, //5
                new List<int>(), //6
                new List<int> {8}, //7
                new List<int>(), //8
            };
            
            var distancesToFind = new KeyValuePair<int, int>[]
            {
                new KeyValuePair<int, int>(1, 6),
                new KeyValuePair<int, int>(1, 5),
                new KeyValuePair<int, int>(5, 6),
                new KeyValuePair<int, int>(5, 8),
                new KeyValuePair<int, int>(0, 0),
            };

            foreach (var pair in distancesToFind)
            {
                var steps = CalculateSteps(pair.Key, pair.Value);
                Console.WriteLine("{{{0}}}, {{{1}}} -> {{{2}}}", pair.Key, pair.Value, steps);
            }
        }

        private static int CalculateSteps(int start, int target)
        {
            if (start == target)
            {
                return 0;
            }

            var queue = new Queue<int>();
            var visited = new bool[graph.Length];
            var previousNodes = new Dictionary<int, int>();
            bool isReached = false;

            queue.Enqueue(start);
            visited[start] = true;
            
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                foreach (var childNode in graph[node])
                {
                    if (!visited[childNode])
                    {
                        previousNodes[childNode] = node;

                        if (childNode == target)
                        {
                            isReached = true;
                            break;
                        }

                        queue.Enqueue(childNode);
                        visited[childNode] = true;
                    }
                }
            }

            if (isReached)
            {
                return CalculateSteps(start, target, previousNodes);
            }
            
            return -1;
        }

        private static int CalculateSteps(int start, int target, Dictionary<int, int> previousNodes)
        {
            int steps = 0;
            while (target != start)
            {
                target = previousNodes[target];
                steps++;
            }

            return steps;
        }
    }
}
