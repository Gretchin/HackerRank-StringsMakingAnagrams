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
            MaxHeap max = new MaxHeap();
            MinHeap min = new MinHeap();
            for (int a_i = 0; a_i < n; a_i++)
            {
                int buff = Convert.ToInt32(Console.ReadLine());

                if (max.isEmpty())
                {
                    if (min.isEmpty())
                        max.add(buff);
                    else if (buff < min.peek())
                    {
                        max.add(buff);
                    }
                    else
                    {
                        min.add(buff);
                    }
                }
                else if (min.isEmpty())
                {
                    if (buff > max.peek())
                        min.add(buff);
                    else
                    {
                        max.add(buff);
                    }
                }
                // both heaps is't empty
                else if (buff > max.peek())
                    min.add(buff);
                else
                    max.add(buff);
                int temp = max.Size - min.Size;
                if (Math.Abs(temp) > 1)
                    if (temp > 0)
                        min.add(max.poll());
                    else
                        max.add(min.poll());

                if(max.Size==min.Size)
                    Console.WriteLine(((max.peek()+min.peek())/2.0).ToString(".0"));
                else if(temp>0)
                    Console.WriteLine((max.peek()).ToString(".0"));
                else
                    Console.WriteLine((min.peek()).ToString(".0"));
            }
        }
    }
}
