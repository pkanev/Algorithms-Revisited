namespace PermutationsWithRepetitions
{
    using System;

    class Program
    {
        static void Main()
        {
            var arr = new int[] { 3, 5, 1, 5, 5 };
            Array.Sort(arr);
            PermuteRep(arr, 0, arr.Length - 1);

        }

        static void PermuteRep(int[] arr, int start, int end)
        {
            Print(arr);
            for (int left = end - 1; left >= start; left--)
            {
                for (int right = left + 1; right <= end; right++)
                    if (arr[left] != arr[right])
                    {
                        Swap(ref arr[left], ref arr[right]);
                        PermuteRep(arr, left + 1, end);
                    }
                var firstElement = arr[left];
                for (int i = left; i <= end - 1; i++)
                    arr[i] = arr[i + 1];
                arr[end] = firstElement;
            }
        }

        private static void Swap<T>(ref T x, ref T y)
        {
            T old = x;
            x = y;
            y = old;
        }

        private static void Print<T>(T[] arr)
        {
            Console.WriteLine("({0})", string.Join(", ", arr));
        }

    }
}
