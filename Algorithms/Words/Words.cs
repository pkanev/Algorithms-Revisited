namespace Words
{
    using System;

    class Words
    {
        private static int count = 0;

        static void Main()
        {
            string input = Console.ReadLine();
            GenerateWords(input);
            Console.WriteLine(count);
        }

        private static void GenerateWords(string input)
        {
            char[] array = input.ToCharArray();
            Array.Sort(array);

            Permutate(array, 0, array.Length - 1);
        }

        private static void Permutate(char[] array, int start, int end)
        {
            CheckValidity(array);
            for (int left = end - 1; left >= start; left--)
            {
                for (int right = left + 1; right <= end; right++)
                    if (array[left] != array[right])
                    {
                        Swap(ref array[left], ref array[right]);
                        Permutate(array, left + 1, end);
                    }
                var firstElement = array[left];
                for (int i = left; i <= end - 1; i++)
                    array[i] = array[i + 1];
                array[end] = firstElement;
            }
        }

        private static void Swap(ref char first, ref char second)
        {
            first ^= second;
            second ^= first;
            first ^= second;
        }

        private static void CheckValidity(char[] array)
        {
            int arrayLength = array.Length;

            for (int i = 1; i < arrayLength; i++)
            {
                if (array[i] == array[i - 1])
                {
                    return;
                }
            }

            count ++;
        }
    }
}
