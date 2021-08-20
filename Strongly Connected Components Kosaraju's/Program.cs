using System;

namespace Strongly_Connected_Components_Kosaraju_s
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph G = new Graph(4);

            G.AddEdge(0, 1);
            G.AddEdge(1, 2);
            G.AddEdge(2, 0);
            G.AddEdge(0, 3);

            G.SCC(0);
        }
    }
}
