using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookPrepForms.Combination_Sum_II
{
    public static class Solution
    {
        public static IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            var result = new List<IList<int>>();
            Array.Sort(candidates);
            FindCombination(candidates, 0, target, new List<int>(), result);

            return result;
        }

        private static void FindCombination(int[] candidates, int index, int target, List<int> current, List<IList<int>> result)
        {
            if (target == 0)
            {
                result.Add(new List<int>(current));
                return;
            }
            if (target < 0)
            {
                return;
            }
            for (int i = index; i < candidates.Length; i++)
            {
                if(i == index || candidates[i] != candidates[i - 1])
                {
                    current.Add(candidates[i]);
                    FindCombination(candidates, i + 1, target - candidates[i], current, result);
                    current.RemoveAt(current.Count - 1);
                }
            }
        }

    }
}
