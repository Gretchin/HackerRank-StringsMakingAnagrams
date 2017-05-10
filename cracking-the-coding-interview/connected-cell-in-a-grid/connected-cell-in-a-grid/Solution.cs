using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    class Solver
    {
        int[][] matrix;
        int n;
        int m;
        bool[,] flag;
        //public int N { get; set; }
        //public int M { get; set; }
        int[] nextI = new int[8] { -1, -1, -1, 0, 0, 1, 1, 1 };
        int[] nextJ = new int[8] { -1, 0, 1, -1, 1, -1, 0, 1 };

        public Solver(int[][] matrix, int n, int m)
        {
            this.matrix = matrix;
            this.n = n;
            this.m = m;
            flag = new bool[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    flag[i, j] = false;
        }

        //return the number of cells in the largest region in the given matrix
        public int Connectivity()
        {
            int maxNumber = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    int counter = 0;
                    if (!flag[i, j])
                        counter += dfs(i, j);
                    if (counter > maxNumber)
                        maxNumber = counter;
                }
            return maxNumber;
        }

        int dfs(int i, int j)
        {
            if (i < 0 || i >= n || j < 0 || j >= m || matrix[i][j]==0 || flag[i, j] == true)
                return 0;
            flag[i, j] = true;
            int counter = 1;
            for (int k = 0; k < nextI.Length; k++)
                counter += dfs(i + nextI[k], j + nextJ[k]);
            return counter;
        }
    }
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
        Solver s = new Solver(grid, n, m);
        Console.WriteLine(s.Connectivity());
    }
}