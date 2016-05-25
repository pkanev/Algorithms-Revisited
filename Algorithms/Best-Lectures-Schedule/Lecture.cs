namespace Best_Lectures_Schedule
{
    using System;

    public class Lecture : IComparable<Lecture>
    {
        public Lecture(string name, int start, int end)
        {
            this.Name = name;
            this.Start = start;
            this.End = end;
        }

        public string Name { get; set; }
        public int Start { get; set; }
        public int End { get; set; }

        public int CompareTo(Lecture other)
        {
            return this.End.CompareTo(other.End);
        }

        public override string ToString()
        {
            return string.Format("{0}-{1} -> {2}", this.Start, this.End, this.Name);
        }
    }
}