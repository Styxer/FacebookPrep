using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookPrepForms.Container_With_Most_Water
{
    public static class Solution
    {
        public static int MaxArea(int[] height)
        {
            int left = 0;
            int right = height.Length - 1;
            int maxArea = 0;

            while (left < right)
            {
                int area = (right - left) * Math.Min(height[left], height[right]);
                if (area > maxArea) maxArea = area;

                if (height[left] > height[right]) right--;
                else left++;
            }
            return maxArea;


        }
    }
}
