namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Sortable_Collection.Contracts;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            this.MergeSort(collection, new T[collection.Count], 0, collection.Count - 1);
        }

        private void MergeSort(List<T> array, T[] tempArray, int start, int end)
        {
            if (start < end)
            {
                int middle = (start + end)/2;
                this.MergeSort(array, tempArray, start, middle);
                this.MergeSort(array, tempArray, middle + 1, end);

                int leftMinIndex = start;
                int rightMinIndex = middle + 1;
                int tempIndex = 0;

                while (leftMinIndex <= middle && rightMinIndex <= end)
                {
                    if (array[leftMinIndex].CompareTo(array[rightMinIndex]) <= 0)
                    {
                        tempArray[tempIndex] = array[leftMinIndex];
                        leftMinIndex++;
                    }
                    else
                    {
                        tempArray[tempIndex] = array[rightMinIndex];
                        rightMinIndex++;
                    }

                    tempIndex++;
                }

                while (leftMinIndex <= middle)
                {
                    tempArray[tempIndex] = array[leftMinIndex];
                    leftMinIndex++;
                    tempIndex++;
                }

                while (rightMinIndex <= end)
                {
                    tempArray[tempIndex] = array[rightMinIndex];
                    rightMinIndex++;
                    tempIndex++;
                }
                
                tempIndex = 0;
                leftMinIndex = start;
                while (tempIndex < tempArray.Length && leftMinIndex <= end)
                {
                    array[leftMinIndex] = tempArray[tempIndex];
                    leftMinIndex++;
                    tempIndex++;
                }
            }
        }
    }
}
