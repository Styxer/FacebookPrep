using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookPrepForms.Longest_Increasing_Path_in_a_Matrix
{
    /*
     *only 1 direction we can go in'
     *recursion
     *longestPath(i,j) = 1+ max {
     *                        longestPath(i-1,j) --> if valid && increasing  [TOP] 
     *                        longestPath(i,j-1) --> if valid && increasing  [LEFT] 
     *                        longestPath(i+1,j) --> if valid && increasing  [DOWN] 
     *                        longestPath(i,j+1) --> if valid && increasing  [RIGHT]
     *                        }
     *      max_path = 0
     *      for i in rows
     *         for j in cols
     *              len = longestPath(i,j) --> duplicate computation ,need to cache the result
     *              max_path = max(max_path, len)
     *      return max_path
     *                        
     */
    public static class Solution
    {
        static int rows, cols;
        static int[,] cache;
        static int[][] dirs = new int[][]
        {
        new int[] { -1, 0 },
        new int[] { 0, -1},
        new int[] { 1, 0 },
        new int[] { 0, 1 }
        };
        public static int LongestIncreasingPath(int[][] matrix)
        {
            int maxPath = 0;

            if (matrix != null)
            {
                rows = matrix.Length;
                if (rows > 0)
                {
                    cols = matrix[0].Length;
                    cache = new int[rows, cols];
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < cols; j++)
                        {
                            maxPath = Math.Max(maxPath, longestIncPat(matrix, i, j));
                        }
                    }
                }
            }


            return maxPath;
        }

        private static int longestIncPat(int[][] matrix, int i, int j)
        {
            if (cache[i, j] != 0)
            {
                return cache[i, j];
            }
            int maxDirPath = 0;
            foreach (var dir in dirs)
            {
                int dir_i = i + dir[0];
                int dir_j = j + dir[1];
                if (valid(dir_i, dir_j) && matrix[i][j] < matrix[dir_i][dir_j])
                {
                    maxDirPath = Math.Max(maxDirPath, longestIncPat(matrix, dir_i, dir_j));
                }
            }

            cache[i, j] = maxDirPath + 1;
            return cache[i, j];
        }

        private static bool valid(int i, int j)
        {
            return i < rows && i >= 0 && j < cols && j >= 0;

        }
    }
}
