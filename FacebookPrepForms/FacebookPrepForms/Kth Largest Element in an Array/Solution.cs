using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookPrepForms.Kth_Largest_Element_in_an_Array
{
    public static class Solution
    {
        public static int FindKthLargest(int[] nums, int k)
        {
            return nums.OrderByDescending(x => x).ElementAt(k);
        }

        public static int FindKthLargestV2(int[] nums, int k)
        {
            PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();
            foreach (var item in nums)
            {
                minHeap.Enqueue(item, item);
                if(minHeap.Count > k)
                {
                    minHeap.Dequeue();
                }
            }

            return minHeap.Dequeue();
           
        }
    }
}
