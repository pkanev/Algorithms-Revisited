namespace Modified_Kruskal_Algorithm
{
    using System.Collections.Generic;

    public class ModifiedKruskalAlgorithm
    {
        public static List<Edge> Kruskal(int numberOfVertices, List<Edge> edges)
        {
            var spanningTree = new List<Edge>();
            edges.Sort();
            var nodes = new Node[numberOfVertices];
            for (int i = 0; i < numberOfVertices; i++)
            {
                nodes[i] = new Node(i);
            }

            foreach (var edge in edges)
            {
                Node firstNode = nodes[edge.StartNode];
                Node secondNode = nodes[edge.EndNode];

                if (firstNode.Parent.Value != secondNode.Parent.Value)
                {
                    spanningTree.Add(edge);
                    if (IsRoot(firstNode) && !IsRoot(secondNode))
                    {
                        MergeTrees(firstNode, secondNode);
                    }
                    else
                    {
                        MergeTrees(secondNode, firstNode);
                    }
                }

            }
            
            return spanningTree;
        }

        private static void MergeTrees(Node firstNode, Node secondNode)
        {
            firstNode.Parent = secondNode.Parent;
            secondNode.Parent.Children.Add(firstNode);

            foreach (var child in firstNode.Children)
            {
                child.Parent = secondNode.Parent;
                secondNode.Parent.Children.Add(child);
            }
            firstNode.Children = new List<Node>();
        }

        private static bool IsRoot(Node node)
        {
            return node.Value == node.Parent.Value;

        }

        public static int FindRoot(int node, int[] parent)
        {
            int root = node;
            while (parent[root] != root)
            {
                root = parent[root];
            }

            while (node != root)
            {
                var oldParent = parent[node];
                parent[node] = root;
                node = oldParent;
            }

            return root;
        }
    }
}