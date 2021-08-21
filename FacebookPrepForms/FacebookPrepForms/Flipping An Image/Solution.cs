using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookPrepForms.Flipping_An_Image
{
    public static class Solution
    {
        public static int[][] FlipAndInvertImage(int[][] image)
        {
            if (image == null)
                return image;
            for (int i = 0; i < image.Length; i++)
            {
                int start = 0;
                int end = image[0].Length - 1;
                while (start < end)
                {
                    int temp = image[i][start];
                    image[i][start++] = image[i][end] ^ 1;
                    image[i][end--] = temp ^ 1;                   
                }

                if (start == end)
                {
                    image[i][start] = image[i][start] ^ 1;
                }
            }
            return image;
        }
    }
}
