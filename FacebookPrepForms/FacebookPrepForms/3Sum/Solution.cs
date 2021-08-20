using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookPrepForms._3Sum
{
    public static class Solution
    {

        private static int[] TwoSum(int[] numbers, int target)
        {
            int[] result = new int[2];
            IDictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; (i < numbers.Length); i++)
            {
                if (map.ContainsKey((target - numbers[i])))
                {
                    result[1] = i;
                    result[0] = map[(target - numbers[i])];
                    return result;
                }

                map[numbers[i]] = i;
            }

            return result;
        }

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            var orderedNums = nums.OrderBy(x => x);

            var negatives = orderedNums.Where(x => x < 0);
            var postives = orderedNums.Where(x => x > 0);
            var zero = orderedNums.Where(x => x == 0);

            HashSet<List<int>> set = new HashSet<List<int>>();
            List<IList<int>> result = new List<IList<int>>();

            if (!negatives.Any() || !postives.Any())
                return null;

            for (int i = 0; i < negatives.Count(); i++)
            {
                List<int> items = new List<int>();
                var mirroredItem = postives.Where(x => -1 * negatives.ElementAt(i) == x);
                if (mirroredItem.Any() && zero.Any())
                {
                    items.Add(negatives.ElementAt(i));
                    items.Add(0);
                    items.Add(mirroredItem.First());
                }
                else
                {
                    var sum = TwoSum(postives.ToArray(), -1 * negatives.ElementAt(i));


                    if (sum.All(x => x == default(int)))
                    {
                        foreach (var item in sum)
                        {
                            Console.WriteLine(items);
                        }
                        items.AddRange(sum);
                        items.Add(negatives.ElementAt(i));
                    }

                }
            }

            return result;
        }
    }
}
