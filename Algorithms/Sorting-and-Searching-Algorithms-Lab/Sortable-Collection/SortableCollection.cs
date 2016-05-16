namespace Sortable_Collection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Sortable_Collection.Contracts;

    public class SortableCollection<T> where T : IComparable<T>
    {
        public SortableCollection()
        {
            this.Items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.Items = new List<T>(items);
        }

        public SortableCollection(params T[] items)
            : this(items.AsEnumerable())
        {
        }

        // C# 6 feature
        // public List<T> Items { get; } = new List<T>();

        public List<T> Items { get; private set; }

        // C# 6 feature
        // public int Count => this.Items.Count;

        public int Count
        {
            get { return this.Items.Count; }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.Items);
        }

        public int BinarySearch(T item)
        {
            return this.BinarySearchProcedure(item, 0, this.Items.Count - 1);
        }

        private int BinarySearchProcedure(T item, int startIndex, int endIndex)
        {
            if (endIndex < startIndex)
            {
                return -1;
            }

            int midPoint = (startIndex + endIndex) / 2;

            if (this.Items[midPoint].CompareTo(item) > 0)
            {
                return this.BinarySearchProcedure(item, startIndex, midPoint - 1);
            }

            if (this.Items[midPoint].CompareTo(item) < 0)
            {
                return this.BinarySearchProcedure(item, midPoint + 1, endIndex);
            }

            return midPoint;
        }

        public int InterpolationSearch(T item)
        {
            throw new NotImplementedException();
        }

        public void Shuffle()
        {
            Random rnd = new Random();
            var n = this.Count;
            for (var i = 0; i < n; i++)
            {
                // Exchange array[i] with random element in array[i … n-1]
                int r = i + rnd.Next(0, n - i);
                var temp = this.Items[i];
                this.Items[i] = this.Items[r];
                this.Items[r] = temp;
            }

        }

        public T[] ToArray()
        {
            return this.Items.ToArray();
        }

        public override string ToString()
        {
            return string.Format("[{0}]", string.Join(", ", this.Items));
        }        
    }
}