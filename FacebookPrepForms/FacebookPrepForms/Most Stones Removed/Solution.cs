using FacebookPrepForms.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookPrepForms.Most_Stones_Removed
{
    static class Solution
    {
        public static int RemoveStones(int[][] stones)
        {
            int result = -1;

            if (stones != null || stones.Count() > 1)
            {
                ISet<int[]> visited = new HashSet<int[]>();
                int numOfIslands = 0;
                foreach (int[] s1 in stones)
                {
                    if (!visited.Contains(s1))
                    {
                        DFS.dfs(s1, visited, stones);
                        numOfIslands++;
                    }
                }
                result = stones.Length - numOfIslands;
            }

            return result;
        }


    }
}
