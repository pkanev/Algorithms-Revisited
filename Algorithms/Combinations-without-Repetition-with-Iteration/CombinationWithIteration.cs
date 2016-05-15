namespace Combinations_without_Repetition_with_Iteration
{
    using System;
    using System.Collections.Generic;

    class CombinationWithIteration
    {
        static void Main()
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("k = ");
            int k = int.Parse(Console.ReadLine());
            
            foreach (int[] combination in Combinations(k, n))
            {
                Console.WriteLine(string.Join(", ", combination));
            }
        }

        private static IEnumerable<int[]> Combinations(int k, int n)
        {
            int[] result = new int[k];
            Stack<int> stack = new Stack<int>();
            stack.Push(1);

            while (stack.Count > 0)
            {
                int index = stack.Count - 1;
                int value = stack.Pop();

                while (value <= n)
                {
                    result[index++] = value++;
                    stack.Push(value);
                    if (index == k)
                    {
                        yield return result;
                        break;
                    }
                }
            }

        }
    }
}
