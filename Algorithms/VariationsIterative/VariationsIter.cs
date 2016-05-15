namespace VariationsIterative
{
    using System;
    using System.Text;

    class VariationsIter
    {
        const int N = 50;
        const int K = 3;
        private static readonly int[] Arr = new int[K];
        private static readonly StringBuilder Output = new StringBuilder();

        static void Main()
        {
            do
            {
                GenerateOutput(Arr);

            } while (Increment(Arr));
            Console.WriteLine(Output.ToString());
        }

        private static bool Increment(int[] arr)
        {
            int digitIndex = arr.Length - 1;
            while (digitIndex >= 0)
            {
                arr[digitIndex]++;
                if (arr[digitIndex] == N)
                {
                    // no overflow
                    arr[digitIndex] = 0;
                    digitIndex--;
                }
                else
                {
                    // Overflow
                    return true;
                }
            }

            return false;
        }

        private static void GenerateOutput(int[] ints)
        {
            string line = string.Join(", ", Arr);
            Output.AppendLine(line);
        }
    }
}
