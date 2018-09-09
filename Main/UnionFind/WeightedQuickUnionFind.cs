using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.UnionFind
{
    class WeightedQuickUnionFind : IUnionFind
    {
        private int n;
        private int[] id;
        private int[] size;

        public WeightedQuickUnionFind(int N)
        {
            n = N;
            id = new int[N];
            size = new int[N];
            for (int i = 0; i < N; i++)
            {
                id[i] = i;
                size[i] = 1;
            }
        }

        public bool IsConnected(int p, int q)
        {
            return Root(p) == Root(q);
        }

        private int Root(int i)
        {
            while (i != id[i])
            {
                i = id[i];
            }
            return i;
        }

        public void Union(int p, int q)
        {
            int rootP = Root(p);
            int rootQ = Root(q);

            if (rootP == rootQ)
                return;

            if( size[rootP] < size[rootQ])
            {
                id[rootP] = rootQ;
                size[rootQ] += rootP;
            }
            else
            {
                id[rootQ] = rootP;
                size[rootP] += rootQ;
            }
        }
    }
}
