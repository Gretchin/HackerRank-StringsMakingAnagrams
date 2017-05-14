using System;
using System.Collections.Generic;
using System.IO;
class Solution
{
    abstract class Graph
    {
        protected bool directed;

        Queue<int> que;

        public int V { get; protected set; }
        protected virtual void Enqueue(int v)
        {
            que.Enqueue(v);
        }
        protected virtual int Dequeue()
        {
            return que.Dequeue();
        }
        protected virtual bool HasElInQueue()
        {
            return (que.Count > 0) ? true : false;
        }
        protected abstract bool GetFlag(int v);
        protected abstract void SetFlag(int v, bool flag);
        protected abstract bool HasPrev(int v);
        protected abstract int DistPrev(int v);
        protected abstract void SetDist(int v, int dist);
        protected abstract int GetDist(int v);
        protected abstract void AddAllAdjToQue(int v);
        public abstract void AddEdge(int v, int u);

        public Graph(bool directed)
        {
            this.directed = directed;
            que = new Queue<int>();
        }

        public int[] BFS(int start)
        {
            const int weight = 6;
            start--;
            Enqueue(start);
            while (HasElInQueue())
            {
                int cur = Dequeue();
                if (GetFlag(cur))
                    continue;
                SetFlag(cur, true);
                SetDist(cur, (HasPrev(cur)) ? DistPrev(cur) + weight : 0);
                AddAllAdjToQue(cur);
            }
            int[] res = new int[V - 1];
            for (int i = 0, k = 0; i < V - 1; i++, k++)
            {
                if (GetDist(k) == 0)
                    k++;
                res[i] = GetDist(k);
            }
            return res;
        }
    }

    class GraphWithList : Graph
    {
        Node[] graph;

        class Node
        {
            int num;

            public Node Prev { get; set; }
            public Adjacent Adj { get; set; }
            public bool Flag { get; set; }
            public int Distance { get; set; }

            public Node(int num)
            {
                this.Distance = -1;
                this.num = num + 1;
            }

            public void AddAdj(int num)
            {
                if (Adj == null)
                {
                    Adj = new Adjacent(num);
                    return;
                }
                Adjacent cur = Adj;
                while (cur.Next != null)
                    cur = cur.Next;
                cur.Next = new Adjacent(num);
            }
        }
        class Adjacent
        {
            public int Num { get; set; }
            public Adjacent Next { get; set; }

            public Adjacent(int num)
            {
                this.Num = num;
            }
        }

        public GraphWithList(int n, bool directed)
            : base(directed)
        {
            graph = new Node[n];
            for (int i = 0; i < n; i++)
                graph[i] = new Node(i);
            V = n;
        }


        protected override bool GetFlag(int v)
        {
            return graph[v].Flag;
        }
        protected override void SetFlag(int v, bool flag)
        {
            graph[v].Flag = flag;
        }
        protected override bool HasPrev(int v)
        {
            return (graph[v].Prev == null) ? false : true;
        }
        protected override int DistPrev(int v)
        {
            return graph[v].Prev.Distance;
        }
        protected override void SetDist(int v, int dist)
        {
            graph[v].Distance = dist;
        }
        protected override int GetDist(int v)
        {
            return graph[v].Distance;
        }
        protected override void AddAllAdjToQue(int v)
        {
            Node cur = graph[v];
            Adjacent adj = cur.Adj;
            while (adj != null)
            {
                if (!HasPrev(adj.Num))
                {
                    graph[adj.Num].Prev = cur;
                    Enqueue(adj.Num);
                }
                adj = adj.Next;
            }
        }
        public override void AddEdge(int v, int u)
        {
            graph[v - 1].AddAdj(u - 1);
            if (!directed)
                graph[u - 1].AddAdj(v - 1);
        }
    }
    class GraphWithMatrix : Graph
    {
        int[][] graph;
        Node[] vertex;
        class Node
        {
            public int Prev { get; set; }
            public bool Flag { get; set; }
            public int Dist { get; set; }

            public Node()
            {
                Prev = -1;
                Flag = false;
                Dist = -1;
            }
        }
        public GraphWithMatrix(int n, bool directed)
            : base(directed)
        {
            graph = new int[n][];
            vertex = new Node[n];
            for (int i = 0; i < n; i++)
                vertex[i] = new Node();
            if (directed)
                for (int i = 0; i < n; i++)
                {
                    graph[i] = new int[i + 1];
                    for (int j = 0; j < i + 1; j++)
                        graph[i][j] = 0;
                }
            else
                for (int i = 0; i < n; i++)
                {
                    graph[i] = new int[n];
                    for (int j = 0; j < n; j++)
                        graph[i][j] = 0;
                }
            V = n;
        }

        protected override bool GetFlag(int v)
        {
            return vertex[v].Flag;
        }
        protected override void SetFlag(int v, bool flag)
        {
            vertex[v].Flag = flag;
        }
        protected override bool HasPrev(int v)
        {
            return (vertex[v].Prev == -1) ? false : true;
        }
        protected override int DistPrev(int v)
        {
            return vertex[vertex[v].Prev].Dist;
        }
        protected override void SetDist(int v, int dist)
        {
            vertex[v].Dist = dist;
        }
        protected override int GetDist(int v)
        {
            return vertex[v].Dist;
        }
        protected override void AddAllAdjToQue(int v)
        {
            if (directed)
            {
                for (int i = 0; i < V; i++)
                    if (graph[v][i] == 1)
                        if (!HasPrev(i))
                        {
                            vertex[i].Prev = v;
                            Enqueue(i);
                        }
            }
            else
            {
                for (int i = 0; i < v; i++)
                    if (graph[v][i] == 1)
                        if (!HasPrev(i))
                        {
                            vertex[i].Prev = v;
                            Enqueue(i);
                        }
                for (int i = v + 1; i < V; i++)
                    if (graph[i][v] == 1)
                        if (!HasPrev(i))
                        {
                            vertex[i].Prev = v;
                            Enqueue(i);
                        }
            }
        }
        public override void AddEdge(int v, int u)
        {
            v--; u--;
            if (directed)
                graph[v][u] = 1;
            else
                if (u > v)
                    graph[u][v] = 1;
                else
                    graph[v][u] = 1;
        }
    }
    static void Main(String[] args)
    {
        int q = Convert.ToInt32(Console.ReadLine());
        for (int a0 = 0; a0 < q; a0++)
        {
            string[] m_temp = Console.ReadLine().Split(' ');
            int[] m = Array.ConvertAll(m_temp, Int32.Parse);
            Graph gr = new GraphWithMatrix(m[0], false);
            for (int i = 0; i < m[1]; i++)
            {
                string[] a_temp = Console.ReadLine().Split(' ');
                int[] a = Array.ConvertAll(a_temp, Int32.Parse);
                gr.AddEdge(a[0], a[1]);
            }
            int s = Convert.ToInt32(Console.ReadLine());
            int[] res = gr.BFS(s);
            foreach (int r in res)
                Console.Write(r + " ");
            Console.Write("\n");
        }
        Console.Read();
    }
}