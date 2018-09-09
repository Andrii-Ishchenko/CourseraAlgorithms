using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.UnionFind
{
    public class Percolation
    {
        private int N;
        private bool[] closedCells;
        private CompressedWeightedQuickUnionFind UF;//union-find data structure to track connection between Cells

        /// <summary>
        /// Percolation grid. All sites are
        /// </summary>
        /// <param name="N"></param>
        public Percolation(int N)
        {
            this.N = N;
            closedCells = new bool[N * N];
            UF = new CompressedWeightedQuickUnionFind(N * N + 2); //elements with indexes N^2; N^2 + 1 is the two hidden points.
            for(int i=0; i < N*N; i++)
            {
                closedCells[i] = true;
            }
            AddVirtualSites();
        }

        private int IndexAt(int row, int col)
        {
            if(row < 0 || row >= N)
                throw new ArgumentOutOfRangeException("Row is out of range");

            if(col < 0 || col >= N)
                throw new ArgumentOutOfRangeException("Col is out of range");

            return col + N * row;
        }

        /// <summary>
        /// Connect cell at(row,col) to all neighbours if they are open
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        public void Open(int row, int col)
        {
            Validate(row, col);
            int curr = IndexAt(row, col);
            
            if ( row-1 >= 0)
            {
                if(isOpen(row-1, col))
                {
                    UF.Union(curr, IndexAt(row - 1, col));
                }             
            }

            if ( row+1 < N)
            {          
                if (isOpen(row + 1, col))
                {
                    UF.Union(curr, IndexAt(row + 1, col));
                }
            }

            if (col + 1 < N)
            {
                if (isOpen(row, col+1))
                {
                    UF.Union(curr, IndexAt(row, col+1));
                }
            }

            if (col - 1 >= 0)
            {
                if (isOpen(row, col-1))
                {
                    UF.Union(curr, IndexAt(row, col-1));
                }
            }
            closedCells[curr] = false;
        }

        private void Validate(int row, int col)
        {
            if (!(col >= 0 || col < N || row >= 0 || row < N))
                throw new ArgumentOutOfRangeException($"Row({row}) Or Col({col}) is Out Of Range");
        }

        private void AddVirtualSites()
        {
            for (int i=0; i< N; i++)
            {
                UF.Union(N * N, IndexAt(0,i));
                UF.Union(N * N + 1, IndexAt(N - 1, i));
            }
        }

        public bool isOpen(int row, int col)
        {
            return !isFull(row, col);
        }

        public bool isFull(int row, int col)
        {
            int index = IndexAt(row, col);
            return closedCells[index];
        }

        public bool Percolates()
        {
            return UF.IsConnected(N * N, N * N + 1);
        }

    }
}
