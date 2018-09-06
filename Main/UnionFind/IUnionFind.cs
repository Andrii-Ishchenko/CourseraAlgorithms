using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.UnionFind
{
    interface IUnionFind
    {
        void Union(int p, int q);
        bool IsConnected(int p, int q);
    }
}
