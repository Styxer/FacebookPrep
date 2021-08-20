using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookPrepForms.Product_of_Array_Except_Self
{
    public static class Soltuion
    {

        //O(N^2)
        public static int[] ProductExceptSelf1(int[] nums)
        {
            var result = new List<int>();
            if (nums != null)
            {
                var n = nums.Length;
                for (int i = 0; i < n; i++)
                {
                    int prefix = 1;
                    for (int j = 0; j < i; j++)
                    {
                        prefix *= nums[j];
                    }
                    int suffix = 1;
                    for (int j = i + 1; j < n; j++)
                    {
                        suffix *= nums[j];
                    }
                    result.Add(suffix * prefix);
                }
            }
            return result.ToArray();
        }



        /*
         * prefix[0] = 1
         * prefix[1] = input[0]
         * prefix[2] = input[0] * input[1]
         * prefix[3] = input[0] * input[1] * input[2]
         * prefix[n] = input[0] * .... * input[n-1]
         * 
         * so(like fib sequnce)
         * 
         * prefix[0] = 1
         * prefix[1] = input[0]
         * prefix[2] = prefix[1] * input[1]
         * prefix[3] = prefix[2] * input[2]
         * prefix[n] = prefix[i-1] * input[i-1] 
         */
        public static int[] ProductExceptSelf2(int[] nums)
        {
            var result = new List<int>();
            if (nums != null)
            {
                var n = nums.Length;
                var prefix = new int[n];
                prefix[0] = 1;
                for (int i = 1; i < n; i++)
                {
                    prefix[i] = prefix[i - 1] * nums[i - 1];
                }

                var suffix = new int[n];
                suffix[n - 1] = 1;
                for (int i = n - 2; i >= 0; i--)
                {
                    suffix[i] = suffix[i + 1] * nums[i + 1];
                }

                for (int i = 0; i < n; i++)
                {
                    result.Add(prefix[i] * suffix[i]);
                }
            }
            return result.ToArray();
        }

        //no extra space
        public static int[] ProductExceptItSelf(int[] nums)
        {
            var n = nums == null ? 0 : nums.Length;
            var result = new int[n];
            if (n > 0)
            {
                result[n - 1] = 1;
                for (int i = n - 2; i >= 0; i--)
                {
                    result[i] = result[i + 1] * nums[i + 1];
                }

                int prefix = 1;
                for (int i = 1; i < n; i++)
                {
                    prefix = prefix * nums[i - 1];
                    result[i] = prefix * result[i];
                }
            }

            return result;
        }
    }
}
