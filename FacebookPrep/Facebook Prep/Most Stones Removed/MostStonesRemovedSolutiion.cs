using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook_Prep.Most_Stones_Removed
{
    static class MostStonesRemovedSolutiion
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
                        dfs(s1, visited, stones);
                        numOfIslands++;
                    }
                }
                result = stones.Length - numOfIslands;
            }

            return result;
        }

        private static void dfs(int[] s1, ISet<int[]> visited, int[][] stones)
        {
            visited.Add(s1);
            foreach (int[] s2 in stones)
            {
                if (!visited.Contains(s2))
                {
                    // stone with same row or column. group them into island
                    if (s1[0] == s2[0] || s1[1] == s2[1])
                    {
                        dfs(s2, visited, stones);
                    }
                }
            }


        }
    }
}
