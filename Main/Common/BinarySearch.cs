using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Common
{
    public static class BinarySearch
    {
        public static int Search(int[] array, int element)
        {
            if (array.Length == 0)
                return -1;

            int left = 0;
            int right = array.Length - 1;
            
            while(left <= right)
            {
                int mid = left + (right - left) / 2;
                if (array[mid] < element)
                {
                    left = mid + 1;
                }
                else if (array[mid] > element)
                {
                    right = mid - 1;
                }
                else
                {
                    return mid;
                }
            }
            return -1; 
        }

        public static void Test(string[] args)
        {
            int[] arr = new int[] { 1, 3, 5, 6, 7, 8, 11, 15, 18, 19, 25, 35, 45, 65, 87, 102, 109, 117, 225, 228 };
            for (int i = 0; i < arr.Length; i++)
                Console.Write("{0}, ", arr[i]);
            Console.WriteLine();

            Console.Write("Looking for 22, its index is: ");
            int index = BinarySearch.Search(arr, 22);
            Console.WriteLine(index);
            Console.ReadKey();
        }
    }
}
