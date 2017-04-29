using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace find_the_running_median
{
    public static class Heap
    {
        private static int size = 0;

        static void Heapify(List<int> arr, int i)
        {
            int left = 2 * i + 1;
            int right = left + 1;
            int max = i;
            if (left < size)
            {
                if (arr[left] > arr[max])
                    max = left;
                if (right < size)
                    if (arr[right] > arr[max])
                        max = right;
            }
            if (max != i)
            {
                int temp = arr[i];
                arr[i] = arr[max];
                arr[max] = temp;
                Heapify(arr, max);
            }
        }

        public static void Sort(List<int> arr)
        {
            Build(arr);

            while (size > 0)
            {
                size--;
                int temp = arr[0];
                arr[0] = arr[size];
                arr[size] = temp;

                Heapify(arr, 0);
            }
        }

        static void Build(List<int> arr)
        {
            size = arr.Count;
            for (int i = (size - 1) / 2; i >= 0; i--)
            {
                Heapify(arr, i);
            }
        }
    }
}
