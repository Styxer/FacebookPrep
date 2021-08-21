using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookPrepForms.Fruit_Into_Baskets
{
    public static class Solution
    {
        const int NUM_OF_BASKETS = 2;
        public static int TotalFruit(int[] fruits)
        {
            if(fruits == null || fruits.Length == 0)
            {
                return 0;
            }

            int max = 1;
            var fruitFrequency  = new Dictionary<int, int>();
            int i = 0, j = 0;
            while(j < fruits.Length)
            {
                if(fruitFrequency.Count <= NUM_OF_BASKETS)
                {
                    fruitFrequency[fruits[j]] = j++; //map.put(key, value) -> map[key] = value
                }
                if (fruitFrequency.Count > NUM_OF_BASKETS)
                {
                    int min = fruits.Length - 1;
                    foreach (var value in fruitFrequency.Values)
                    {
                        min = Math.Min(min, value);
                    }

                    i = min + 1;
                    fruitFrequency .Remove(fruits[min]);
                }
                max = Math.Max(max, j - i);
            }

            return max;
        }
    }
}
