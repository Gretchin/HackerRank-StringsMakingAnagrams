using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution
{
    static public void IceCream(int[] arr, int n, int money)
    {
        int[] keys = new int[n];
        for (int j = 0; j < n; j++)
            keys[j] = j + 1;

        Array.Sort(arr, keys);
        int indexInArrFst;
        int indexInArrSec = 0;
        for (indexInArrFst = 0; indexInArrFst < n; indexInArrFst++)
        {
            indexInArrSec = Array.BinarySearch(arr, money - arr[indexInArrFst]);
            if (indexInArrSec > 0)
            {
                if (indexInArrFst != indexInArrSec)
                    break;
            }
        }
        Console.WriteLine((keys[indexInArrFst] < keys[indexInArrSec]) ? "{0} {1}" : "{1} {0}", keys[indexInArrFst], keys[indexInArrSec]);
    }

    static void Main(String[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine());
        for (int a0 = 0; a0 < t; a0++)
        {
            int m = Convert.ToInt32(Console.ReadLine());
            int n = Convert.ToInt32(Console.ReadLine());
            string[] a_temp = Console.ReadLine().Split(' ');
            int[] a = Array.ConvertAll(a_temp, Int32.Parse);
            IceCream(a, n, m);
        }
    }
}