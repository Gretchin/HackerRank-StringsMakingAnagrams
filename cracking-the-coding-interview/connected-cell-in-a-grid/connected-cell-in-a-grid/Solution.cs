using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{

    static void Main(String[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int m = Convert.ToInt32(Console.ReadLine());
        int[][] grid = new int[n][];
        for (int grid_i = 0; grid_i < n; grid_i++)
        {
            string[] grid_temp = Console.ReadLine().Split(' ');
            grid[grid_i] = Array.ConvertAll(grid_temp, Int32.Parse);
        }
    }
}
