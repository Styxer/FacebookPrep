using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookPrepForms.Maximum_Length_of_a_Concatenated_String_with_Unique_Characters
{
    public static class Solution
    {
        public static int MaxLength(IList<string> arr)
        {
            int[] result = new int[1];
            MaxUnique(arr, 0, "", result);

            return result[0];

        }

        private static void MaxUnique(IList<string> arr, int index, string current, int[] result)
        {
            if (index == arr.Count && uniqueCharCount(current) > result[0])
            {
                result[0] = current.Length;
                return;
            }
            if (index == arr.Count)
            {
                return;
            }
            MaxUnique(arr, index + 1, current, result);
            MaxUnique(arr, index + 1, current + arr[index], result);
        }

        private static int uniqueCharCount(string s)
        {
            int[] counts = new int[26];
            foreach (var c in s)
            {
                if (counts[c - 'a']++ > 0)
                {
                    return -1;
                }
            }

            return s.Length;
        }


        /*
         * Initial the result res to include the case of empty string "".
            res include all possible combinations we find during we iterate the input.

            Itearte the the input strings,
            but skip the word that have duplicate characters.            
            the input string can have duplicate characters,
            no need to considerate these strings.

            For each string,
            we check if it's conflit with the combination that we found.
            If they have intersection of characters, we skip it.
            If not, we append this new combination to result.

            return the maximum length from all combinations.
         * 
         */
        public static int MaxLengthV2(IList<string> arr)
        {
            IList<int> dp = new List<int>();
            dp.Add(0);
            int res = 0;
            foreach (string s in arr)
            {
                int a = 0, dup = 0;
                foreach (char c in s.ToCharArray())
                {
                    dup |= a & (1 << (c - 'a'));
                    a |= 1 << (c - 'a');
                }
                if (dup > 0)
                {
                    continue;
                }
                for (int i = dp.Count - 1; i >= 0; --i)
                {
                    if ((dp[i] & a) > 0)
                    {
                        continue;
                    }
                    dp.Add(dp[i] | a);
                    res = Math.Max(res, BitCount(dp[i] | a));
                }
            }
            return res;

        }
        public static int BitCount(int n)
        {
            var count = 0;
            while (n != 0)
            {
                count++;
                n &= (n - 1); //walking through all the bits which are set to one
            }

            return count;
        }
    }
}
