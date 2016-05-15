namespace Mergesort
{
    using System;

    class Program
    {
        static void Main()
        {
            var elements = new int[] {5, 6, 2, 10, 3, 2, 10, 8};
            Mergesort(elements, 0, elements.Length - 1);
            Console.WriteLine(string.Join(", ", elements));
        }

        private static void Mergesort(int[] arr, int start, int end)
        {
            if (start == end)
            {
                return;
            }
            var mid = (start + end)/2;
            
            Mergesort(arr, start, mid);
            Mergesort(arr, mid + 1, end);

            int left = start;
            int right = mid + 1;
            int result = 0;
            int[] temp = new int[end - start + 1];

            while (left <= mid && right <= end)
            {
                if (arr[left] <= arr[right])
                {
                    temp[result] = arr[left];
                    left ++;
                }
                else
                {
                    temp[result] = arr[right];
                    right++;
                }
                result ++;
            }

            while (left <= mid)
            {
                temp[result] = arr[left];
                left++;
                result++;
            }

            while (right <= end)
            {
                temp[result] = arr[right];
                right++;
                result++;
            }

            Array.Copy(temp, 0, arr, start, temp.Length);
        }
    }
}
