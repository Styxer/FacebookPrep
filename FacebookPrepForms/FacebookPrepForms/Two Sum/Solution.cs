using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookPrepForms.Two_Sum
{
    public static class Solution
    {
        //Input: nums = [2,7,11,15], target = 9
        public static int[] TwoSum(int[] nums, int target)
        {
            int[] result = new int[2];
            if (nums != null && nums.Length >= 2)
            {
                var orderedNums = nums.OrderBy(x => x);
                for (int i = 0; i < orderedNums.Count(); i++)
                {
                    var temp = orderedNums.ElementAt(i);
                    var selectedItem = orderedNums
                        .Skip(i + 1)
                        .Where(x => target - temp == x);
                    //  var selectedItemIndex = or



                    if (selectedItem.Any())
                    {
                        result[0] = nums.ToList().IndexOf(temp);
                        result[1] = nums.ToList().IndexOf(selectedItem.First());
                    }

                }
            }


            return result;
        }
    }
}
