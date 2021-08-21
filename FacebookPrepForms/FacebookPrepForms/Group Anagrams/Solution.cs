using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookPrepForms.Group_Anagrams
{
    public static class Solution
    {
        public static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var gropuedAnagrams = new List<IList<string>>();
            if(strs != null || strs.Length != 0)
            {
                var map = new Dictionary<string, List<string>>();
                foreach (var current in strs)
                {
                    var sorted = String.Concat(current.OrderBy(c => c));
                    if (!map.ContainsKey(sorted))
                    {
                        map[sorted] = new List<string>();
                    }
                    map[sorted].Add(current);
                }
                gropuedAnagrams.AddRange(map.Values);
            }
            return gropuedAnagrams;
        }
    }
}
