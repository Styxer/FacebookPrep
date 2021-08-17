using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook_Prep.Number_of_Islands
{
    public static class NumberOfIslandsSolution
    {
        public static int NumIslands(char[][] grid)
        {
            int result = 0;

            if (grid != null || grid.Length != 0)
            {
                bool[,] visited = new bool[grid.Length, grid[0].Length];
                int count = 0;

                for (int i = 0; i < grid.Length; i++)
                {
                    for (int j = 0; j < grid[i].Length; j++)
                    {
                        if (!visited[i, j] && grid[i][j] == '1')
                        {
                            count++;
                            DFS.dfs(grid, visited, i, j);
                        }
                    }
                }
            }

            return result;
        }
    }
}
