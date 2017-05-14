using System;
using System.Collections.Generic;
using System.IO;

class Solution
{
    public static int FibonacciRecursion(int n)
    {
        if (n < 2)
            return n;
        return FibonacciRecursion(n - 2) + FibonacciRecursion(n - 1);
    }

    public static int FibonacciCycle(int n)
    {
        int a = 0;
        int b = 1;
        for (int i = 1; i < n; i++)
        {
            int temp = b;
            b += a;
            a = temp;
        }
        return b;
    }

    static void Main(String[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(FibonacciCycle(n));
    }
}
