using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    static int ForeverAlone(int[] a,int n)
    {
        int res = 0;
        for (int i = 0; i < n; i++)
        {
            res ^= a[i];
        }
        return res;
    }

    static void Main(String[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] a_temp = Console.ReadLine().Split(' ');
        int[] a = Array.ConvertAll(a_temp, Int32.Parse);
        Console.WriteLine(ForeverAlone(a, n));
    }
}