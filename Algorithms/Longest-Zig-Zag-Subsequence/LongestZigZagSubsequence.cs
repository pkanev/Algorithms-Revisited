namespace Longest_Zig_Zag_Subsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class LongestZigZagSubsequence
    {
        private static int maxLenBeginHi = 0;
        private static int maxLenBeginLo = 0;
        private static int lastIndexBeginHi = -1;
        private static int lastIndexBeginLo = -1;
        private static int[] prevBeginHi;
        private static int[] lenBeginHi;
        private static int[] prevBeginLo;
        private static int[] lenBeginLo;

        static void Main()
        {
            int[] sequence = Console.ReadLine()
                .Split(',')
                .Select(int.Parse)
                .ToArray();

            prevBeginHi = new int[sequence.Length];
            lenBeginHi = new int[sequence.Length];
            prevBeginLo = new int[sequence.Length];
            lenBeginLo = new int[sequence.Length];
            
            FindZigZigSequence(sequence);

            int[] restoredSequence = 
                maxLenBeginHi >= maxLenBeginLo ? 
                    RestoreSequence(sequence, prevBeginHi,lastIndexBeginHi) :
                    RestoreSequence(sequence, prevBeginLo, lastIndexBeginLo);

            Console.WriteLine(string.Join(" ", restoredSequence));
        }

        private static void FindZigZigSequence(int[] sequence)
        {
            for (int i = 0; i < sequence.Length; i++)
            {
                prevBeginHi[i] = -1;
                prevBeginLo[i] = -1;
                lenBeginHi[i] = 1;
                lenBeginLo[i] = 1;

                for (int x = 0; x < i; x++)
                {
                    if (lenBeginHi[x]%2 == 1)
                    {
                        // odd: down
                        if (sequence[x] > sequence[i] && 
                            lenBeginHi[x] + 1 > lenBeginHi[i])
                        {
                            lenBeginHi[i] = lenBeginHi[x] + 1;
                            prevBeginHi[i] = x;
                        }
                    }
                    else
                    {
                        // even: up
                        if (sequence[x] < sequence[i] && 
                            lenBeginHi[x] + 1 > lenBeginHi[i])
                        {
                            lenBeginHi[i] = lenBeginHi[x] + 1;
                            prevBeginHi[i] = x;
                        }
                    }

                    if (lenBeginLo[x]%2 == 1)
                    {
                        // odd: up
                        if (sequence[x] < sequence[i] && 
                            lenBeginLo[x] + 1 > lenBeginLo[i])
                        {
                            lenBeginLo[i] = lenBeginLo[x] + 1;
                            prevBeginLo[i] = x;
                        }
                    }
                    else
                    {
                        // even: up
                        if (sequence[x] > sequence[i] && 
                            lenBeginLo[x] + 1 > lenBeginLo[i])
                        {
                            lenBeginLo[i] = lenBeginLo[x] + 1;
                            prevBeginLo[i] = x;
                        }
                    }
                }

                if (lenBeginHi[i] > maxLenBeginHi)
                {
                    maxLenBeginHi = lenBeginHi[i];
                    lastIndexBeginHi = i;
                }

                if (lenBeginLo[i] > maxLenBeginLo)
                {
                    maxLenBeginLo = lenBeginLo[i];
                    lastIndexBeginLo = i;
                }
            }
        }

        private static int[] RestoreSequence(int[] sequence, int[] previous, int lastIndex)
        {
            var longestSeq = new List<int>();
            while (lastIndex != -1)
            {
                longestSeq.Add(sequence[lastIndex]);
                lastIndex = previous[lastIndex];
            }

            longestSeq.Reverse();
            return longestSeq.ToArray();
        }
    }
}
