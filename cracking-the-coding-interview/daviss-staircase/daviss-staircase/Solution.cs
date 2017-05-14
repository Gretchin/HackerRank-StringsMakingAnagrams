using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    static int StaircaseClimb(int n)
    {
        int[] ways = new int[n];
        ways[0] = 1;
        return Ways(n, ways);
    }
    static int Ways(int n, int[] ways)
    {
        if (n == 0)
            return 1;
        int res = 0;
        if (ways[n - 1] == 0)
            ways[n - 1] = Ways(n - 1, ways);
        res += ways[n - 1];
        if (n > 1)
        {
            if (ways[n - 2] == 0)
                ways[n - 2] = Ways(n - 2, ways);
            res += ways[n - 2];
        }
        if (n > 2)
        {
            if (ways[n - 3] == 0)
                ways[n - 3] = Ways(n - 3, ways);
            res += ways[n - 3];
        }
        return res;
    }
    static void Main(String[] args)
    {
        int s = Convert.ToInt32(Console.ReadLine());
        for (int a0 = 0; a0 < s; a0++)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(StaircaseClimb(n));
        }
        Console.Read();
    }
}
