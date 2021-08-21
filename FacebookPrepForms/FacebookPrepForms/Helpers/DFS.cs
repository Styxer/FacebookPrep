using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookPrepForms.Helpers
{
    public static class DFS
    {
        public static void dfs(int[] s1, ISet<int[]> visited, int[][] stones)
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

        public static void dfs(char[][] grid, bool[,] visited, int x, int y)
        {
            int[,] directions = new int[,] { { -1, 0 }, { 0, 1 }, { 1, 0 }, { 0, -1 } };
            for (int i = 0; i < directions.GetLength(0); i++)
            {
                int newx = x + directions[i, 0];
                int newy = y + directions[i, 1];

                if (newx >= 0 && newy >= 0 && newx < grid.Length && newy < grid[0].Length
                  && grid[newx][newy] == '1' && !visited[newx, newy])
                {
                    visited[newx, newy] = true;
                    dfs(grid, visited, newx, newy);
                }
            }
        }

    }
}

