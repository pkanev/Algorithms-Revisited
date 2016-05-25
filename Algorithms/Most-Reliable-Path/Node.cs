namespace Most_Reliable_Path
{
    using System;

    public class Node : IComparable<Node>
    {
        // set default value for the reliability equal to positive infinity
        public Node(int id, double reliability = 0)
        {
            this.Id = id;
            this.ReliabilityFromStart = reliability;
        }

        public int Id { get; set; }

        public double ReliabilityFromStart { get; set; }

        public int CompareTo(Node other)
        {
            return this.ReliabilityFromStart.CompareTo(other.ReliabilityFromStart);
        }
    }
}