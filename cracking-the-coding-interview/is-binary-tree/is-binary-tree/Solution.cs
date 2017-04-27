using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace is_binary_tree
{


    class Solution
    {
        static void Main(string[] args)
        {
            //hackerrank has no c#. this solution was made in Java 7 and was't tested. Thus i'm hope that this code are working =)
        }

        public bool checkBST(Node root) //boolean
        {
            LinkedList<Node> l = new LinkedList<Node>();
            TreeToList(root, l);

            while (l.First != null && l.First.Next != null)
            {
                if (l.First.Value.data <= l.First.Next.Value.data)
                    return false;
                l.RemoveFirst();
            }
            return true;
        }
        public void TreeToList(Node root, LinkedList<Node> l)
        {
            if (root.left != null)
                TreeToList(root.left, l);
            l.AddFirst(root);
            if (root.right != null)
                TreeToList(root.right, l);
        }

        public class Node
        {
            public int data;
            public Node left;
            public Node right;

        }
    }
}
