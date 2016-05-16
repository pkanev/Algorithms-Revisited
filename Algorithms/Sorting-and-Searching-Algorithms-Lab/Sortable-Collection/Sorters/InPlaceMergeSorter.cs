namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class InPlaceMergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            this.InPlaceMergeSort(collection, 0, collection.Count - 1);
        }

        private void InPlaceMergeSort(List<T> array, int start, int end)
        {
            if (start < end)
            {
                int middle = (start + end) / 2;
                this.InPlaceMergeSort(array, start, middle);
                this.InPlaceMergeSort(array, middle + 1, end);

                int left = start;
                int right = middle + 1;

                while (left <= middle && right <= end)
                {
                    // Select from left:  no change, just advance left
                    if (array[left].CompareTo(array[right]) <= 0)
                        left++;
                    // Select from right:  rotate [left..right] and correct
                    else
                    {
                        T temp = array[right];     // Will move to [left]
                        array.RemoveAt(right);
                        array.Insert(left, temp);
                        array[left] = temp;
                        // EVERYTHING has moved up by one
                        left++;
                        middle++;
                        right++;
                    }
                }
            }
        }
    }
}
