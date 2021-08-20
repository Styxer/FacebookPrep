using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookPrepForms.Pairs_of_Songs_with_Total_Durations_Divisible_by_Sixty
{
    public static class Solution
    {


        public static int NumPairsDivisibleBy4(int[] time)
        {
            int count = 0;

            if (time != null)
            {
                for (int i = 0; i < time.Length; i++)
                {
                    int x = time[i];
                    for (int j = i + 1; j < time.Length; j++)
                    {
                        int y = time[j];
                        if (x + y % 4 == 0)
                        {
                            count++;
                        }
                    }
                }
            }

            return count;
        }

        /*
       * 
       *  x%4 + y%4 == 4
       *  x%4 == 0 ==> y%4==0
       *  hasTable tables of reminders
       *  [8,5,9,7]
       *  x =0
       *  table = {0:1, 1:2} rem:count
       *  x%4 == 3 ==> y%4 = 4 - 3 =1
       */
        public static int NumPairsDivisibleBy60(int[] time)
        {
            int count = 0;

            if (time != null)
            {
                int[] rem2Count = new int[60];
                for (int i = 0; i < time.Length; i++)
                {
                    int rem = time[i] % 60;
                    if (rem == 0)
                    {
                        count += rem2Count[0];
                    }
                    else
                    {
                        count += rem2Count[60 - rem];
                    }
                    rem2Count[rem]++;
                }
            }

            return count;

        }

        public static int NumPairsDivisibleBy60V2(int[] time)
        {
            int count = 0;
            int reminder = 0;

            if (time != null)
            {
                int[] reminder2Count = new int[60];
                for (int i = 0; i < time.Length; i++)
                {
                    reminder = time[i] % 60;
                    count += reminder2Count[reminder == 0 ? 0 : 60 - reminder];
                    reminder2Count[reminder]++;
                }
            }

            return count;

        }
    }
}
