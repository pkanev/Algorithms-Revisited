namespace Cubes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Cubes
    {
        private static readonly HashSet<string> CubeSet = new HashSet<string>();
        private static int count = 0;

        static void Main()
        {
            int[] sides = Console.ReadLine().Split(' ').Select(x =>int.Parse(x)).ToArray();
            Array.Sort(sides);
            PermuteRep(sides, 0, sides.Length - 1);
            Console.WriteLine(count);
        }

        static void PermuteRep(int[] arr, int start, int end)
        {
            BuildCube(arr);
            for (int left = end - 1; left >= start; left--)
            {
                for (int right = left + 1; right <= end; right++)
                    if (arr[left] != arr[right])
                    {
                        Swap(ref arr[left], ref arr[right]);
                        PermuteRep(arr, left + 1, end);
                    }
                var firstElement = arr[left];
                for (int i = left; i <= end - 1; i++)
                    arr[i] = arr[i + 1];
                arr[end] = firstElement;
            }
        }

        private static void Swap(ref int x, ref int y)
        {
            x ^= y;
            y ^= x;
            x ^= y;
        }

        private static void BuildCube(int[] arr)
        {
            string cube = string.Join(string.Empty, arr);
            if (!CubeSet.Contains(cube))
            {
                CubeSet.Add(cube);
                int[] copyCube = arr;
                for (int i = 0; i < 4; i++)
                {
                    copyCube = RotateX(copyCube);
                    CubeSet.Add(string.Join(string.Empty, copyCube));
                }

                copyCube = RotateY(copyCube);
                for (int i = 0; i < 4; i++)
                {
                    copyCube = RotateX(copyCube);
                    CubeSet.Add(string.Join(string.Empty, copyCube));
                    copyCube = RotateY(copyCube);
                    CubeSet.Add(string.Join(string.Empty, copyCube));
                    copyCube = RotateZ(copyCube);
                    CubeSet.Add(string.Join(string.Empty, copyCube));
                }

                copyCube = RotateZ(copyCube);
                for (int i = 0; i < 4; i++)
                {
                    copyCube = RotateX(copyCube);
                    CubeSet.Add(string.Join(string.Empty, copyCube));
                    copyCube = RotateY(copyCube);
                    CubeSet.Add(string.Join(string.Empty, copyCube));
                    copyCube = RotateZ(copyCube);
                    CubeSet.Add(string.Join(string.Empty, copyCube));
                }

                copyCube = RotateZ(copyCube);
                for (int i = 0; i < 4; i++)
                {
                    copyCube = RotateX(copyCube);
                    CubeSet.Add(string.Join(string.Empty, copyCube));
                    copyCube = RotateY(copyCube);
                    CubeSet.Add(string.Join(string.Empty, copyCube));
                    copyCube = RotateZ(copyCube);
                    CubeSet.Add(string.Join(string.Empty, copyCube));
                }

                count++;
            }
            
        }

        private static int[] RotateZ(int[] copyCube)
        {
            int[] result = new int[copyCube.Length];
            result[0] = copyCube[1];
            result[1] = copyCube[2];
            result[2] = copyCube[3];
            result[3] = copyCube[0];
            result[4] = copyCube[5];
            result[5] = copyCube[6];
            result[6] = copyCube[7];
            result[7] = copyCube[4];
            result[8] = copyCube[9];
            result[9] = copyCube[10];
            result[10] = copyCube[11];
            result[11] = copyCube[8];
            return result;
        }

        private static int[] RotateY(int[] copyCube)
        {
            int[] result = new int[copyCube.Length];
            result[0] = copyCube[8];
            result[1] = copyCube[4];
            result[2] = copyCube[0];
            result[3] = copyCube[7];
            result[4] = copyCube[9];
            result[5] = copyCube[1];
            result[6] = copyCube[3];
            result[7] = copyCube[11];
            result[8] = copyCube[10];
            result[9] = copyCube[5];
            result[10] = copyCube[2];
            result[11] = copyCube[6];
            return result;
        }

        private static int[] RotateX(int[] copyCube)
        {
            int[] result = new int[copyCube.Length];
            result[0] = copyCube[4];
            result[1] = copyCube[9];
            result[2] = copyCube[5];
            result[3] = copyCube[1];
            result[4] = copyCube[8];
            result[5] = copyCube[10];
            result[6] = copyCube[2];
            result[7] = copyCube[0];
            result[8] = copyCube[7];
            result[9] = copyCube[11];
            result[10] = copyCube[6];
            result[11] = copyCube[3];
            return result;
        }
    }
}
