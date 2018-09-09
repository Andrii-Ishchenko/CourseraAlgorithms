using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.UnionFind
{
    class QuickUnionFind : IUnionFind
    {
        private int[] id;// id[i] is parent of i;

        public QuickUnionFind(int N)
        {
            id = new int[N];
            for(int i=0; i<N; i++)
            {
                id[i] = i;
            }
        }

        private int Root(int i)
        {
            while (i != id[i])
            {
                i = id[i];
            }
            return i;
        }

        public bool IsConnected(int p, int q)
        {
            return Root(p) == Root(q);
        }

        public void Union(int p, int q)
        {
            int i = Root(p);
            int j = Root(q);
            id[i] = j;
        }
    }
}
