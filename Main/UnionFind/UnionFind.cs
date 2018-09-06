using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.UnionFind
{
    public class UnionFind : IUnionFind
    {
        private readonly int N;
        private int[] id;

        public UnionFind(int N)
        {
            this.N = N;
            id = new int[N];
            
            for(int i = 0; i < N; i++)
                id[i] = i;

        }

        public void Union(int p, int q)
        {
            int pid = id[p];
            int qid = id[q];

            for(int i=0; i<N; i++)
                if( id[i] == pid) id[i] = qid;
        }

        public bool IsConnected(int p, int q)
        {
            return id[p] == id[q];
        }
    }
}
