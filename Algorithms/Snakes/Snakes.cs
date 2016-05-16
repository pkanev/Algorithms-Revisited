namespace Snakes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class Snakes
    {
        private static HashSet<string> collection = new HashSet<string>();
        private static int count = 0;
        private static StringBuilder output = new StringBuilder();
        private static readonly char[] directions = { 'R', 'D', 'L', 'U' };
        private const int DirectionsCount = 4;

        static void Main()
        {
            int sizeOfSnake = int.Parse(Console.ReadLine());
            int k = sizeOfSnake - 1;
            int[] array = new int[k];

            GenerateVariations(0, array);
            Console.Write(output.ToString());
            Console.WriteLine("Snakes count = {0}", count);
        }

        private static void GenerateVariations(int index, int[] array)
        {
            if (index >= array.Length)
            {
                string result = GenerateResult(array);
                if (!collection.Contains(result))
                {
                    bool isValid = CheckValidity(result);
                    if (isValid)
                    {
                        RotateAndSave(result);
                        string verticalFlip = FlipX(result);
                        RotateAndSave(verticalFlip);
                        string horizontalFlip = FlipY(result);
                        RotateAndSave(horizontalFlip);
                        string reversed = Reverse(result);
                        RotateAndSave(reversed);
                        verticalFlip = FlipX(reversed);
                        RotateAndSave(verticalFlip);

                        output.AppendLine(result);
                        count++;
                    }
                }
            }
            else
            {
                for (int i = 0; i < DirectionsCount; i++)
                {
                    array[index] = i;
                    GenerateVariations(index + 1, array);
                }
            }
        }

        private static string Reverse(string result)
        {
            var sb = new StringBuilder("S");
            for (int i = result.Length - 1; i >= 1; i--)
            {
                switch (result[i])
                {
                    case 'U':
                        sb.Append('D');
                        break;
                    case 'D':
                        sb.Append('U');
                        break;
                    case 'R':
                        sb.Append('L');
                        break;
                    case 'L':
                        sb.Append('R');
                        break;
                    default:
                        break;
                }
            }

            return sb.ToString();
        }

        private static string FlipY(string result)
        {
            var sb = new StringBuilder("S");

            for (int i = 1; i < result.Length; i++)
            {
                switch (result[i])
                {
                    case 'L':
                        sb.Append('R');
                        break;
                    case 'R':
                        sb.Append('L');
                        break;
                    default:
                        sb.Append(result[i]);
                        break;
                }
            }

            return sb.ToString();
        }

        private static void RotateAndSave(string result)
        {
            collection.Add(result);
            string r1 = RotateSnake(result);
            collection.Add(r1);
            string r2 = RotateSnake(r1);
            collection.Add(r2);
            string r3 = RotateSnake(r2);
            collection.Add(r3);
        }

        private static bool CheckValidity(string result)
        {
            int length = result.Length;

            var matrix = new bool[2 * length - 1, 2 * length - 1];
            int currentRow = length - 1;
            int currentColumn = length - 1;
            matrix[currentRow, currentColumn] = true;
            for (int i = 1; i < length; i++)
            {
                switch (result[i])
                {
                    case 'U':
                        currentRow--;
                        break;
                    case 'D':
                        currentRow++;
                        break;
                    case 'L':
                        currentColumn--;
                        break;
                    case 'R':
                        currentColumn++;
                        break;
                    default:
                        break;
                }

                if (matrix[currentRow, currentColumn])
                {
                    return false;
                }

                matrix[currentRow, currentColumn] = true;
            }

            return true;
        }

        private static string FlipX(string result)
        {
            var sb = new StringBuilder("S");
            for (int i = 1; i < result.Length; i++)
            {
                switch (result[i])
                {
                    case 'D':
                        sb.Append('U');
                        break;
                    case 'U':
                        sb.Append('D');
                        break;
                    default:
                        sb.Append(result[i]);
                        break;
                }
            }

            return sb.ToString();
        }

        private static string RotateSnake(string result)
        {
            var sb = new StringBuilder("S");
            for (int i = 1; i < result.Length; i++)
            {
                switch (result[i])
                {
                    case 'R':
                        sb.Append('D');
                        break;
                    case 'D':
                        sb.Append('L');
                        break;
                    case 'L':
                        sb.Append('U');
                        break;
                    case 'U':
                        sb.Append('R');
                        break;
                    default:
                        break;
                }
            }

            return sb.ToString();
        }

        private static string GenerateResult(int[] array)
        {
            var sb = new StringBuilder("S");
            for (int i = 0; i < array.Length; i++)
            {
                sb.Append(directions[array[i]]);
            }
            return sb.ToString();
        }
    }
}
