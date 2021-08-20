using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strongly_Connected_Components_Kosaraju_s
{
    class Graph
    {
        int nodes;
        List<List<int>> adj = new List<List<int>>();
        List<List<int>> rev = new List<List<int>>();

        public Graph(int N)
        {
            this.nodes = N;
            for (int i = 0; i < nodes; i++)
            {
                adj.Add(new List<int>());
                rev.Add(new List<int>());
            }
        }

        public void AddEdge(int Source, int Destination)
        {
            adj[Source].Add(Destination);
            rev[Destination].Add(Source);
        }

        public void SCC(int StartNode)
        {
            bool[] visited = new bool[nodes];
            Stack<int> S = new Stack<int>();


            for (int i = 0; i < nodes; i++)
            {
                if (!visited[i])
                    SCCUtil(visited, S, StartNode);
            }

            for (int i = 0; i < nodes; i++)
            {
                visited[i] = false;
            }

            while(S.Count != 0)
            {
                Queue<int> Q = new Queue<int>();
                int startRev = S.Pop();
                if(!visited[startRev])
                    RevUtil(visited, startRev, Q, S);
            }
        }

        public void RevUtil(bool[] visited,int RevNode,  Queue<int> Q, Stack<int> S)
        {
            Q.Enqueue(RevNode);
            visited[RevNode] = true;

            foreach (var child in rev[RevNode])
            {
                if (!visited[child])
                {
                    RevUtil(visited, child, Q, S);
                    return;
                }
            }
            Console.WriteLine(string.Join(",", Q));
        }

        public void SCCUtil(bool[] visited, Stack<int> S, int StartedNode)
        {
            visited[StartedNode] = true;

            foreach (var child in adj[StartedNode])
            {
                if (!visited[child])
                {
                    SCCUtil(visited, S, child);
                }
            }
            S.Push(StartedNode);
        }
    }
}
