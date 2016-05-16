namespace Sortable_Collection
{
    using System;
    using System.Linq;
    using Sortable_Collection.Sorters;

    public class SortableCollectionPlayground
    {
        private static Random Random = new Random();

        public static void Main()
        {
            const int NumberOfElementsToSort = 100;
            const int MaxValue = 999;

            var array = new int[NumberOfElementsToSort];

            for (int i = 0; i < NumberOfElementsToSort; i++)
            {
                array[i] = Random.Next(MaxValue);
            }

            var collectionToSort = new SortableCollection<int>(array);
            collectionToSort.Sort(new BucketSorter { Max = MaxValue });

            Console.WriteLine(collectionToSort);

            var collection = new SortableCollection<int>(2, -1, 5, 0, -3);
            Console.WriteLine(collection);

            collection.Sort(new HeapSorter<int>());
            Console.WriteLine(collection);
            
            Console.WriteLine(collection.BinarySearch(5));
            Console.WriteLine(collection.BinarySearch(20));

            collection = new SortableCollection<int>(Enumerable.Range(1, 20).ToList());
            Console.WriteLine(collection);
            collection.Shuffle();
            Console.WriteLine(collection);
            collection.Shuffle();
            Console.WriteLine(collection);
            collection.Shuffle();
            Console.WriteLine(collection);
            collection.Shuffle();
            Console.WriteLine(collection);

        }
    }
}
