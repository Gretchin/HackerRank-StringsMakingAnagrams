using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Solution
{
    class Node
    {
        Dictionary<char, Node> table;
        bool finish;
        int countOfAdded;

        public Node()
        {
            table = new Dictionary<char, Node>();
            finish = false;
            countOfAdded = 0;
        }
        public void Add(string contact)
        {
            Node cur = this;
            int i;

            Stack<Node> st = new Stack<Node>();
            st.Push(cur);

            for (i = 0; i < contact.Length; i++)
            {
                if (!cur.table.ContainsKey(contact[i]))
                {
                    Node temp = new Node();
                    cur.table.Add(contact[i], temp);
                    cur = temp;
                    st.Push(cur);
                }
                else
                {
                    cur = cur.table[contact[i]];
                    st.Push(cur);
                    continue;
                }
            }
            if (!cur.finish)
            {
                cur.finish = true;
                while (st.Count != 0)
                    st.Pop().countOfAdded++;
            }
            else
                st = null;
        }
        public int Search(string contact)
        {
            Node cur = this;
            int i;
            for (i = 0; i < contact.Length; i++)
            {
                if (!cur.table.ContainsKey(contact[i]))
                    return 0;
                cur = cur.table[contact[i]];
            }            
            return cur.countOfAdded;
        }
    }

    static void Main(String[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        Node root = new Node();
        for (int a0 = 0; a0 < n; a0++)
        {
            string[] tokens_op = Console.ReadLine().Split(' ');
            string op = tokens_op[0];
            string contact = tokens_op[1];
            switch (op)
            {
                case "add":
                    {
                        root.Add(contact);
                        break;
                    }
                case "find":
                    {
                        Console.WriteLine(root.Search(contact));
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Unknown '{0}' comand", op);
                        break;
                    }
            }
        }
    }
}
