using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookPrepForms.Boats_to_Save_People
{
    public static class Solution
    {
        public static int NumRescueBoats(int[] people, int limit)
        {
            Array.Sort(people);

            int numBoats = 0;
            int i = 0, j = people.Length - 1;
            while(i<=j)
            {
                if(people[i] + people[j] <= limit)
                {
                    i++;
                    j--;
                }
                else
                {
                    j--;
                }
                numBoats++;
            }
            return numBoats++;
        }
    }
}
