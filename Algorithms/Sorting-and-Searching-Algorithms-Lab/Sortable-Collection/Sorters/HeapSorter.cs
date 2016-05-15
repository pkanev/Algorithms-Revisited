namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class HeapSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            var heap = new BinaryHeap(collection.ToArray());
            collection.Clear();
            while (heap.Count > 0)
            {
                collection.Add(heap.ExtractMin());
            }
        }

        internal class BinaryHeap
        {
            private List<T> heap;

            public BinaryHeap()
            {
                this.heap = new List<T>();
            }

            public BinaryHeap(T[] elements)
            {
                this.heap = new List<T>(elements);
                for (int i = this.heap.Count / 2; i >= 0; i--)
                {
                    this.HeapifyDown(i);
                }
            }

            public int Count
            {
                get { return this.heap.Count; }
            }

            public T ExtractMin()
            {
                T min = this.heap[0];
                this.heap[0] = this.heap[heap.Count - 1];
                this.heap.RemoveAt(this.heap.Count - 1);
                if (this.heap.Count > 0)
                {
                    this.HeapifyDown(0);
                }
                return min;
            }

            public T PeekMin()
            {
                return this.heap[0];
            }

            public void Insert(T node)
            {
                this.heap.Add(node);
                this.HeapifyUp(this.Count - 1);
            }

            private void HeapifyDown(int i)
            {
                var left = 2 * i + 1;
                var right = 2 * i + 2;
                var smallest = i;
                if (left < this.heap.Count && this.heap[left].CompareTo(this.heap[smallest]) < 0)
                {
                    smallest = left;
                }
                if (right < this.heap.Count && this.heap[right].CompareTo(this.heap[smallest]) < 0)
                {
                    smallest = right;
                }
                if (smallest != i)
                {
                    T old = this.heap[i];
                    this.heap[i] = this.heap[smallest];
                    this.heap[smallest] = old;
                    this.HeapifyDown(smallest);
                }
            }

            private void HeapifyUp(int i)
            {
                var parent = (i - 1) / 2;
                while (i > 0 && this.heap[i].CompareTo(this.heap[parent]) > 0)
                {
                    T old = this.heap[i];
                    this.heap[i] = this.heap[parent];
                    this.heap[parent] = old;

                    i = parent;
                    parent = (i - 1) / 2;
                }
            }

        }
    }
}
