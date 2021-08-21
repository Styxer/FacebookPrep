using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookPrepForms.Best_Time_to_Buy_and_Sell_Stock
{
    public static class Solution
    {
        public static int MaxProfit(int[] prices)
        {
            if(prices == null || prices.Length == 0)
            {
                return 0;
            }

            int max = 0;
            int min = int.MaxValue;
            for (int i = 0; i < prices.Length; i++)
            {
                if(prices[i] < min)
                {
                    min = prices[i];    
                }
                else
                {
                    max = Math.Max(max, prices[i] - min);
                }
            }

            return max;
        }
    }
}
