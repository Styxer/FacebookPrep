using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookPrepForms.Power_of_Two
{
    public static class Solution
    {
        //15
        public static bool IsPowerOfTwo(int n)
        {

            long i = 1; //1 first power of two
            while (i < n)
            {
                i *= 2;
            }

            return i == n;
        }

        public static bool IsPowerOfTwoV2(int n)
        {
            int count = 0;
            while (n > 0)
            {
                n &= (n - 1);
                count++;
            }
            return count == 1;
        }
        /*
         * 1000
         * 0001
         * 0000
         */
        public static bool IsPowerOfTwoV3(int n)
        {
            if (n <= 0) return false;
            return (n & n - 1) == 0;
        }
    }
}
