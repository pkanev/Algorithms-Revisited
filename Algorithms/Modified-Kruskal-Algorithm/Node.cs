namespace Modified_Kruskal_Algorithm
{
    using System.Collections.Generic;

    public class Node
    {
        public Node(int value)
        {
            this.Value = value;
            this.Parent = this;
            this.Children = new List<Node>();
        }

        public int Value { get; set; }
        public Node Parent { get; set; }
        public List<Node> Children { get; set; } 
    }
}