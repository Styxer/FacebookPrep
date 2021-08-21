using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookPrepForms.Battleships_in_a_Board
{
    public static class Solution
    {
        public static int CountBattleshipsV2(char[][] board)
        {
            int numBattleShips = 0;

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if(board[i][j] == '.')
                    {
                        continue;
                    }
                    if(i > 0 && board[i - 1][j] == 'X')
                    {
                        continue;
                    }
                    if(j > 0 && board[i][j-1] == 'X')
                    {
                        continue;
                    }
                    numBattleShips++;
                }
            }

            return numBattleShips;
        }

        private static void Sink(char[][] board, int i, int j)
        {
            if(i < 0 || i >= board.Length || j< 0 || j>= board[i].Length || board[i][j] != 'X')            
            {
                return;
            }
            board[i][j] = '.';
            Sink(board, i + 1, j);
            Sink(board, i - 1, j);
            Sink(board, i, j + 1);
            Sink(board, i, j - 1);
        }


        public static int CountBattleships(char[][] board)
        {
            int numBattleShips = 0;

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (board[i][j] == 'X')
                    {
                        numBattleShips++;
                        Sink(board, i, j);
                    }
                }
            }

            return numBattleShips;
        }
    }
}
