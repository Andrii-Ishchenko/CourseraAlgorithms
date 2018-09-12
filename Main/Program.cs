using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.UnionFind;
namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            Common.BinarySearch.Test(args);
        }

        static void TestPercolation()
        {
            Percolation perc = new Percolation(4);
            perc.Open(0, 3);
            perc.Open(1, 1);
            perc.Open(1, 2);
            perc.Open(1, 3);
            perc.Open(2, 0);
            perc.Open(2, 1);
            Console.WriteLine("Percolates: " + (perc.Percolates() ? "YES" : "NO"));
            perc.Open(3, 0);
            Console.WriteLine("Percolates: " + (perc.Percolates() ? "YES" : "NO"));
            Console.ReadKey();
        }

  
    }
}
