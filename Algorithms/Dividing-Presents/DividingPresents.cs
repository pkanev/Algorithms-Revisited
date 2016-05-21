namespace Dividing_Presents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class DividingPresents
    {
        static void Main()
        {
            var presents = Console.ReadLine()
                .Split(',')
                .Select(int.Parse)
                .ToArray();

            var possibleDifferences = CalculatePossibleDifferences(presents);
            var minDifference = FindMinDifference(possibleDifferences);
            RecoverPresents(possibleDifferences, minDifference);
        }

        private static void RecoverPresents(SortedDictionary<int, List<int>> possibleDifferences, int minDifference)
        {
            var presentsTaken = new List<int>();
            int alanSum = 0;
            int bobSum = 0;
            possibleDifferences[minDifference].Reverse();

            foreach (var present in possibleDifferences[minDifference])
            {
                if (present > 0)
                {
                    presentsTaken.Add(present);
                    alanSum += present;
                }
                else
                {
                    bobSum += present;
                }
            }

            bobSum *= -1;
            PrintOutput(minDifference, alanSum, bobSum, presentsTaken);
        }

        private static void PrintOutput(int minDifference, int alanSum, int bobSum, List<int> presentsTaken)
        {
            Console.WriteLine("Difference: {0}", minDifference*-1);
            Console.WriteLine("Alan:{0} Bob:{1}", alanSum, bobSum);
            Console.WriteLine("Alan takes: {0}", string.Join(" ", presentsTaken));
            Console.WriteLine("Bob takes the rest.");
        }

        private static int FindMinDifference(SortedDictionary<int, List<int>> possibleDifferences)
        {
            int minDifference = 0;
            while (true)
            {
                if (possibleDifferences.ContainsKey(minDifference))
                {
                    break;
                }

                minDifference--;
            }

            return minDifference;
        }

        private static SortedDictionary<int, List<int>> CalculatePossibleDifferences(int[] presents)
        {
            var possibleDifferences = new SortedDictionary<int, List<int>>();
            possibleDifferences.Add(0, new List<int>());

            foreach (int present in presents)
            {
                var newDifferences = new SortedDictionary<int, List<int>>();
                foreach (var difference in possibleDifferences.Keys)
                {
                    int newSumDifference = difference + present;
                    if (!newDifferences.ContainsKey(newSumDifference))
                    {
                        newDifferences.Add(newSumDifference, new List<int>());
                        newDifferences[newSumDifference].AddRange(possibleDifferences[difference]);
                        newDifferences[newSumDifference].Add(present);
                    }

                    newSumDifference = difference - present;
                    if (!newDifferences.ContainsKey(newSumDifference))
                    {
                        newDifferences.Add(newSumDifference, new List<int>());
                        newDifferences[newSumDifference].AddRange(possibleDifferences[difference]);
                        newDifferences[newSumDifference].Add(present*-1);
                    }
                }

                possibleDifferences = newDifferences;
            }

            return possibleDifferences;
        }
    }
}
