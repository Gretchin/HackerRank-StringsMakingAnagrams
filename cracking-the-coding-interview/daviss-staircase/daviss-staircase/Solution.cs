using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{

    static int Ways(int n)
    {
        if (n == 0)
            return 1;
        int res = 0;
        res += Ways(n - 1);
        if (n > 1)
            res += Ways(n - 2);
        if (n > 2)
            res += Ways(n - 3);
        return res;
    }

    static void Main(String[] args)
    {
        int s = Convert.ToInt32(Console.ReadLine());
        for (int a0 = 0; a0 < s; a0++)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(Ways(n));
        }
    }
}
