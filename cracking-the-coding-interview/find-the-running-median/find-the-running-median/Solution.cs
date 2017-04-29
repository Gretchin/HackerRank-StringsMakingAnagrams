using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace find_the_running_median
{
    class Solution
    {

        static void Main(String[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            List<int> a = new List<int>();
            for (int a_i = 0; a_i < n; a_i++)
            {
                a.Add(Convert.ToInt32(Console.ReadLine()));
                Heap.Sort(a);
                int temp = a.Count / 2;
                if (a.Count % 2 == 0)
                    Console.WriteLine(((a[temp - 1] + a[temp]) / 2.0).ToString(".0"));
                else
                    Console.WriteLine((a[temp]).ToString(".0"));
            }
        }
    }
}
