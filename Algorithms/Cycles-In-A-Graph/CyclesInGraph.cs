namespace Cycles_In_A_Graph
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class CyclesInGraph
    {
        private static Dictionary<char, List<char>> graph;
        private static Dictionary<char, int> edgesCountMap;

        public static void Main()
        {
            graph = new Dictionary<char, List<char>>();
            edgesCountMap = new Dictionary<char, int>();

            string line = Console.ReadLine();
            while (!string.IsNullOrEmpty(line))
            {
                var tokens = line.Split('-').Select(e => char.Parse(e.Trim())).ToArray(); ;
                var predecessor = tokens[0];
                var child = tokens[1];
                if (!graph.ContainsKey(predecessor))
                {
                    graph[predecessor] = new List<char>();
                    edgesCountMap[predecessor] = 0;
                }

                if (!graph.ContainsKey(child))
                {
                    graph[child] = new List<char>();
                    edgesCountMap[child] = 0;
                }

                graph[predecessor].Add(child);
                graph[child].Add(predecessor);
                edgesCountMap[predecessor]++;
                edgesCountMap[child]++;

                line = Console.ReadLine();
            }

            Console.WriteLine("Acyclic: {0}", IsAcyclic() ? "Yes" : "No");
        }

        private static bool IsAcyclic()
        {
            while (true)
            {
                char nodeToRemove = graph.Keys.FirstOrDefault(e => edgesCountMap[e] == 1);
                if (nodeToRemove == '\0')
                {
                    break;
                }

                foreach (var childNode in graph[nodeToRemove])
                {
                    edgesCountMap[childNode]--;
                }

                graph.Remove(nodeToRemove);
            }

            return graph.Count == 1;
        }
    }
}
