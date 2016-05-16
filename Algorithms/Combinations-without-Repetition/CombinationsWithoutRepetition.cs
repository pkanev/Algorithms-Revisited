namespace Combinations_without_Repetition
{
    using System;

    class CombinationsWithoutRepetition
    {
        public static void Main()
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("k = ");
            int k = int.Parse(Console.ReadLine());
            int[] array = new int[k];

            GenerateCombinationWithoutRepetition(array, n, 0);
        }

        private static void GenerateCombinationWithoutRepetition(int[] array, int sizeOfSet, int index, int start = 1)
        {
            if (index >= array.Length)
            {
                Print(array);
            }
            else
            {
                for (int i = start; i <= sizeOfSet; i++)
                {
                    array[index] = i;
                    GenerateCombinationWithoutRepetition(array, sizeOfSet, index + 1, i + 1);
                }
            }
        }

        private static void Print(int[] array)
        {
            Console.WriteLine("({0})", string.Join(", ", array));
        }
    }
}
