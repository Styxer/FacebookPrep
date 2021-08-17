using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook_Prep
{
    class clsGraph
    {
        
        private int vertices;
        
        private List<Int32>[] adj;

        public clsGraph(int vertices)
        {
            this.vertices = vertices;
            InitGraph();


        }

        private void InitGraph()
        {
            adj = new List<Int32>[vertices];           
            for (int i = 0; i < vertices; i++)
            {
                adj[i] = new List<Int32>();
            }
        }

        void BFS(int startNode)
        {
            bool[] visited = new bool[vertices];

            Queue<int> queue = new Queue<int>();
            visited[startNode] = true;
            queue.Enqueue(startNode);

            //loop through all nodes in queue
            while (queue.Count != 0)
            {
                
                startNode = queue.Dequeue();
                Console.WriteLine("next->" + startNode);

             
                foreach (int next in adj[startNode])
                {
                    if (!visited[next])
                    {
                        visited[next] = true;
                        queue.Enqueue(next);
                    }
                }

            }
        }

        public void DFS(int startNode)
        {
            bool[] visited = new bool[vertices];

            //For DFS use stack
            Stack<int> stack = new Stack<int>();
            visited[startNode] = true;
            stack.Push(startNode);

            while (stack.Count != 0)
            {
                startNode = stack.Pop();
                Console.WriteLine("next->" + startNode);
                foreach (int i in adj[startNode])
                {
                    if (!visited[i])
                    {
                        visited[i] = true;
                        stack.Push(i);
                    }
                }
            }
        }
    }
}
