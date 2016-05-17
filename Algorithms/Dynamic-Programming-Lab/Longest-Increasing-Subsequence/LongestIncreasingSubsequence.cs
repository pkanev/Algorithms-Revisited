namespace Longest_Increasing_Subsequence
{
    using System;
    using System.Collections.Generic;

    public class LongestIncreasingSubsequence
    {
        public static void Main()
        {
            var sequence = new[] { 3, 14, 5, 12, 15, 7, 8, 9, 11, 10, 1 };
            var longestSeq = FindLongestIncreasingSubsequence(sequence);
            Console.WriteLine("Longest increasing subsequence (LIS)");
            Console.WriteLine("  Length: {0}", longestSeq.Length);
            Console.WriteLine("  Sequence: [{0}]", string.Join(", ", longestSeq));
        }

        public static int[] FindLongestIncreasingSubsequence(int[] sequence)
        {
            int lastIndex = -1;
            int maxLength = 0;
            int totalElements = sequence.Length;
            int[] lengths = new int[totalElements];
            int[] previousIndexes = new int [totalElements];

            for (int x = 0; x < totalElements; x++)
            {
                lengths[x] = 1;
                previousIndexes[x] = -1;
                for (int i = 0; i < x; i++)
                {
                    if (sequence[x] > sequence[i] && lengths[i] + 1 > lengths[x])
                    {
                        lengths[x] = lengths[i] + 1;
                        previousIndexes[x] = i;
                    }
                }

                if (lengths[x] > maxLength)
                {
                    maxLength = lengths[x];
                    lastIndex = x;
                }
            }

            return RecoverSequence(sequence, previousIndexes, lastIndex);
        }

        private static int[] RecoverSequence(int[] sequence, int[] previousIndexes, int lastIndex)
        {
            var longestSequence = new List<int>();

            while (lastIndex != -1)
            {
                longestSequence.Add(sequence[lastIndex]);
                lastIndex = previousIndexes[lastIndex];
            }

            longestSequence.Reverse();

            return longestSequence.ToArray();
        }
    }
}
