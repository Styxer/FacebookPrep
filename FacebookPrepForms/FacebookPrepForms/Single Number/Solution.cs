using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookPrepForms.Single_Number
{
    public static class Solution
    {
        public static int SingleNumber(int[] nums)
        {
            int result = 0;

            foreach (var item in nums)
            {
                result ^= item;
            }

            return result;
        }
    }
}
