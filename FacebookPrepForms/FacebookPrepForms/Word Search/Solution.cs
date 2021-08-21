using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookPrepForms.Word_Search
{
    public static class Solution
    {
        public static bool Exist(char[][] board, string word)
        {
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if(board[i][j] == word[0] && DFS(board,i, j, 0, word))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private static bool DFS(char[][] board, int i, int j, int count, string word)
        {
            if(count == word.Length)
            {
                return true;
            }
            if(i< 0 || i >= board.Length || j< 0 || j >= board[i].Length || board[i][j] != word[count])
            {
                return false;
            }
            var temp = board[i][j];
            board[i][j] = ' ';
            var found =
                    DFS(board, i + 1, j, count + 1, word) ||
                    DFS(board, i - 1, j, count + 1, word) ||
                    DFS(board, i, j + 1, count + 1, word) ||
                    DFS(board, i , j - 1, count + 1, word);

            board[i][j] = temp;

            return found;
        }
    }
}
