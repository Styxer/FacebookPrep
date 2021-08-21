using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookPrepForms.Path_Sum_II
{


    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }


    public static class Solution
    {
        public static IList<IList<int>> PathSum(TreeNode root, int targetSum)
        {            
            var paths = new List<IList<int>>();
            FindPaths(root, targetSum, new List<int>(), paths);

            return paths;
        }

        private static void FindPaths(TreeNode root, int targetSum, List<int> current, List<IList<int>> paths)
        {
            if(root == null)
            {
                return;
            }

            current.Add(root.val);
            if(root.val == targetSum && root.left == null  && root.right == null)
            {
                paths.Add(current);
                return;
            }

            FindPaths(root.left, targetSum - root.val, new List<int>(current), paths);
            FindPaths(root.right, targetSum - root.val, new List<int>(current), paths);
        }
    }
}
