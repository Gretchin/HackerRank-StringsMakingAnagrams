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
        public Node()
        {
            table = new Dictionary<char, Node>();
            finish = false;
        }
        public void Add(string contact)
        {
            Node cur = this;
            int i;
            for (i = 0; i < contact.Length; i++)
            {
                if (!cur.table.ContainsKey(contact[i]))
                {
                    Node temp = new Node();
                    cur.table.Add(contact[i], temp);
                    cur = temp;
                }
                else
                {
                    cur = cur.table[contact[i]];
                    continue;
                }
            }
            cur.finish = true;
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
            int count = 0;
            count += Counter(cur);

            return count;
        }

        int Counter(Node cur)
        {
            int count = (cur.finish) ? 1 : 0;
            if (cur.table.Count != 0)
                foreach (Node node in cur.table.Values)
                    count += Counter(node);
            return count;
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
