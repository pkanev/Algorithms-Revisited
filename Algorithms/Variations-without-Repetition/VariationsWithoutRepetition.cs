namespace Variations_without_Repetition
{
    using System;
    using System.Linq.Expressions;

    class VariationsWithoutRepetition
    {
        static void Main()
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("k = ");
            int k = int.Parse(Console.ReadLine());

            bool[] used = new bool[n + 1];
            int[] array = new int[k];

            GenerateVariationsWithRepetition(array, n, used);
        }

        private static void GenerateVariationsWithRepetition(int[] array, int sizeOfSet, bool[] used, int index = 0)
        {
            if (index >= array.Length)
            {
                Print(array);
            }
            else
            {
                for (int i = 1; i <= sizeOfSet; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        array[index] = i;
                        GenerateVariationsWithRepetition(array, sizeOfSet, used, index + 1);
                        used[i] = false;
                    }
                }
            }
        }

        private static void Print(int[] array)
        {
            Console.WriteLine("({0})", string.Join(", ", array));
        }
    }
}
