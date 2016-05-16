namespace Generate_Subsets_Of_String_Array
{
    using System;

    class SubsetsOfString
    {
        static void Main()
        {
            string[] s = {"test", "rock", "fun"};
            int k = 2;
            int[] array = new int[k];

            GenerateCombinations(s, array, s.Length, 0);

        }

        private static void GenerateCombinations(string[] collection, int[] array, int sizeOfSet, int index, int start = 0)
        {
            if (index >= array.Length)
            {
                Print(array, collection);
            }
            else
            {
                for (int i = start; i < sizeOfSet; i++)
                {
                    array[index] = i;
                    GenerateCombinations(collection, array, sizeOfSet, index + 1, i + 1);
                }
            }
        }

        private static void Print(int[] array, string[] collection)
        {
            var result = new string[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                result[i] = collection[array[i]];
            }
            Console.WriteLine("({0})", string.Join(" ", result));
        }
    }
}
