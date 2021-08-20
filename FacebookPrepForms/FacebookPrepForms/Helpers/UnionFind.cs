using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookPrepForms.Helpers
{
    public class UnionFind
    {
        public int[] id { get; set; }
        public int[] Size { get; set; }
        public int Count { get; set; }

        public UnionFind(int N)
        {
            Count = N;

            id = new int[N];
            Size = new int[N];

            for (int i = 0; i < N; i++)
            {
                id[i] = i;
                Size[i] = 1;
            }
        }

        // Return the id of component corresponding to object p.
        public int find(int p)
        {

            int root = p;
            while (root != id[root])
                root = id[root];

            while (p != root)
            {
                int newp = id[p];
                id[p] = root;
                p = newp;
            }

            return root;
        }

        public void merge(int x, int y)
        {
            int i = find(x);
            int j = find(y);
            if (i == j) return;

            if (Size[i] < Size[j])
            {
                id[i] = j;
                Size[j] += Size[i];
            }
            else
            {
                id[j] = i;
                Size[i] += Size[j];
            }

            Count--;
        }


        public bool connected(int x, int y)
        {
            return find(x) == find(y);
        }

        public int count()
        {
            return Count;
        }
    }
}
