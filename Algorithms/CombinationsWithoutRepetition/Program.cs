namespace CombinationsWithoutRepetition
{
    using System;

    class Program
    {
        static void Main()
        {
            int k = 3;
            int n = 5;
            int[] arr = new int[k];
            CombNoRepetition(0, 0, n, k, arr);
            Console.WriteLine("==============");
            CombWithRepetition(0, 0, n, k, arr);
        }

        static void CombNoRepetition(int index, int start, int n, int k, int[] arr)
        {
            if (index >= k)
            {
                Print(arr);
            }
            else
            {
                for (int i = start; i < n; i++)
                {
                    arr[index] = i;
                    CombNoRepetition(index + 1, i + 1, n, k, arr);
                }
            }
        }

        static void CombWithRepetition(int index, int start, int n, int k, int[] arr)
        {
            if (index >= k)
            {
                Print(arr);
            }
            else
            {
                for (int i = start; i < n; i++)
                {
                    arr[index] = i;
                    CombWithRepetition(index + 1, i, n, k, arr);
                }
            }
        }

        private static void Print(int[] arr)
        {
            Console.WriteLine($"({string.Join(", ", arr)})");
        }
    }
}
