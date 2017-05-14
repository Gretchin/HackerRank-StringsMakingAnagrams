using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    static bool Primal(int n)
    {
        if (n == 1)
            return false;
        if (n < 4)
            return true;
        if (n % 2 == 0)
            return false;
        if (n % 3 == 0)
            return false;

        int[] k = new int[] { 2, 4 };
        bool kk = true;
        int nn = (int)Math.Sqrt(n);
        for (int i = 5; i <= nn; i += k[(kk) ? 1 : 0])
        {
            if (n % i == 0)
                return false;
            kk = !kk;
        }
        return true;
    }

    static void Main(String[] args)
    {
        int p = Convert.ToInt32(Console.ReadLine());
        for (int a0 = 0; a0 < p; a0++)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            if (Primal(n))
                Console.WriteLine("Prime");
            else
                Console.WriteLine("Not prime");
        }
    }
}