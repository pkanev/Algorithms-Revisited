namespace Variations
{
    using System;
    using System.Collections;
    using System.Linq;

    class Variations
    {
        static void Main()
        {
            int n = 3;
            int k = 3;
            char[] letters = {'a', 'b', 'c'};
            var array = new char[k];
            
            GenerateVariations(0, k, n, array, letters);
        }

        static void GenerateVariations(int index, int k, int n, char[] array, char[] values)
        {
            if (index >= k)
            {
                Print(array);
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    array[index] = values[i];
                    GenerateVariations(index + 1, k, n, array, values);
                }
            }
        }

        private static void Print(char[] list)
        {
            Console.WriteLine(string.Join(", ", list));
        }
    }
}
