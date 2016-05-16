namespace Needles
{
    using System;
    using System.Linq;
    using System.Text;

    class Needles
    {
        static void Main()
        {
            var sb = new StringBuilder();
            Console.ReadLine();
            int[] sequence = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int[] needles = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            foreach (var needle in needles)
            {
                int index = FindIndex(needle, sequence);
                sb.Append(string.Format("{0} ", index));
            }

            Console.WriteLine(sb.ToString());
        }

        private static int FindIndex(int needle, int[] sequence)
        {
            int lastNonZeroIndex = 0;
            for (int currentIndex = 0; currentIndex < sequence.Length; currentIndex++)
            {
                if (sequence[currentIndex] < needle && sequence[currentIndex] != 0)
                {
                    lastNonZeroIndex = currentIndex + 1;
                }

                if (sequence[currentIndex] >= needle)
                {
                    break;
                }
            }

            return lastNonZeroIndex;
        }
    }
}
