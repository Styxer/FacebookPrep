using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookPrepForms.String_Compression
{
    public static class Solution
    {
        public static int Compress(char[] chars)
        {
            int index = 0, i = 0;
            while (i < chars.Length)
            {
                int j = i;
                while (j < chars.Length && chars[j] == chars[i])
                {
                    j++;
                }
                chars[index++] = chars[i];
                if (j - i > 1)//can be compressed
                {
                    string count = j - i + "";
                    foreach (var c in count)
                    {
                        chars[index++] = c;
                    }
                }
                i = j;
            }

            return index;
        }
    }
}
