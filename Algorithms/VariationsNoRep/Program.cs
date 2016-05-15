namespace VariationsNoRep
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int n = 4;
            int k = 3;
            int[] array = new int[k];
            int[] free = Enumerable.Range(1, n).ToArray();
            VariationsNoRepetition(0, n, k, array, free);
        }

        private static void VariationsNoRepetition(
            int index, 
            int n, 
            int k, 
            int[] array, 
            int[] free)
        {
            if (index >= k)
            {
                Print(array);
            }
            else
            {
                for (int i = index; i < n; i++)
                {
                    array[index] = free[i];
                    Swap(ref free[i], ref free[index]);
                    VariationsNoRepetition(index + 1, n, k, array, free);
                    Swap(ref free[i], ref free[index]);
                }
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
            Console.WriteLine($"({string.Join(", ", arr)})");
        }
    }
}
