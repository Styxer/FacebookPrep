using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookPrepForms.Asteroid_Collision
{
    public static class Solution
    {
        public static int[] AsteroidCollision(int[] asteroids)
        {
            Stack<int> stack = new Stack<int>();

            int i = 0;
            while (i < asteroids.Length)
            {
                if (asteroids[i] > 0)
                {
                    stack.Push(asteroids[i]);
                }
                else
                {
                    while (stack.Count != 0 && stack.Peek() > 0 && stack.Peek() < Math.Abs(asteroids[i]))
                    {
                        stack.Pop();
                    }
                    if (stack.Count == 0 || stack.Peek() < 0)
                    {
                        stack.Push(asteroids[i]);
                    }

                    else if (stack.Peek() == Math.Abs(asteroids[i]))
                    {
                        stack.Pop();
                    }
                }
                i++;
            }

            return stack.Reverse().ToArray();
        }


        public static int[] AsteroidCollisionV2(int[] asteroids)
        {
            LinkedList<int> s = new LinkedList<int>(); // use LinkedList to simulate stack so that we don't need to reverse at end.
            for (int i = 0; i < asteroids.Length; i++)
            {
                if (asteroids[i] > 0 || s.Count == 0 || s.Last.Value < 0)
                {
                    s.AddLast(asteroids[i]);
                }
                else if (s.Last.Value <= -asteroids[i])
                {
                    s.RemoveLast();
                    i--;
                }
            }
            return s.ToArray();
        }
    }
}
