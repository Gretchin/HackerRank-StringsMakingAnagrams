using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Solution
{
    class Node
    {
        Node left, right;
        string contact;

        public Node() { }
        public Node(string contact)
        {
            this.contact = contact;
        }

        public Node Left
        {
            get { return left; }
            set { left = value; }
        }
        public Node Right
        {
            get { return right; }
            set { right = value; }
        }
        public string Contact
        {
            get { return contact; }
            set { contact = value; }
        }



        public bool Search(string contact)
        {
            Node cur = this;
            while (cur != null)
            {
                if (cur.Contact == contact)
                    return true;
                if (cur > contact)
                    cur = cur.left;
                else
                    cur = cur.right;
            }
            return false;
        }

        public bool isStartWith(string part)
        {
            for (int i = 0; i < part.Length; i++)
                if (i >= this.contact.Length || this.contact[i] != part[i])
                    return false;
            return true;
        }
        public int PartialSearch(string part)
        {
            Node cur = this;
            int count = 0;
            while (cur !=null && cur.contact != null)
            {
                if (cur.isStartWith(part))
                {
                    count++;
                    if(cur.left!=null)
                        count += cur.left.PartialSearch(part);
                    if(cur.right!=null)
                        count += cur.right.PartialSearch(part);
                    break;
                }
                else if (cur > part)
                    cur = cur.left;
                else
                    cur = cur.right;
            }
            return count;
        }
        public void Add(string contact)
        {
            Node cur = this;
            while (cur != null)
            {
                if (cur > contact)
                    if (cur.left != null)
                        cur = cur.left;
                    else
                    {
                        cur.left = new Node(contact);
                        return;
                    }
                else
                    if (cur.right != null)
                        cur = cur.right;
                    else
                    {
                        cur.right = new Node(contact);
                        return;
                    }
            }
        }


        public static bool operator >(Node arrA, string arrB)
        {

            int sizeA = arrA.contact.Length;
            int sizeB = arrB.Length;
            int minSize = Math.Min(sizeA, sizeB);
            int i = 0;
            while (i < minSize && arrA.contact[i] == arrB[i])
                i++;
            if (i == minSize)
                return (sizeA > sizeB) ? true : false;
            return (arrA.contact[i] > arrB[i]) ? true : false;
        }
        public static bool operator <(Node arrB, string arrA)
        {

            int sizeA = arrA.Length;
            int sizeB = arrB.contact.Length;
            int minSize = Math.Min(sizeA, sizeB);
            int i = 0;
            while (i < minSize && arrA[i] == arrB.contact[i])
                i++;
            if (i == minSize)
                return (sizeA > sizeB) ? true : false;
            return (arrA[i] > arrB.contact[i]) ? true : false;
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
                        if (root.Contact == null)
                            root.Contact = contact;
                        else
                            root.Add(contact);
                        break;
                    }
                case "find":
                    {
                        Console.WriteLine(root.PartialSearch(contact));
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
