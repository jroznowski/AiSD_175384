using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sorting
{
    internal class Graf1
    {
        List<NodeG1> nodes;
        List<Edge> edges;

        public Graf1(Edge K)
        {
            Add(K);
        }

        public int ileNowychWezlow(Edge K) { 
            int noweWezly = 0; 
            if (!nodes.Contains(K.start)) { 
                noweWezly++; 
            } 
            if (!nodes.Contains(K.end)) { 
                noweWezly++; 
            } 
            return noweWezly; 
        } 
        public void Add(Edge K) { 
            if (!nodes.Contains(K.start)) { 
                nodes.Add(K.start); 
            } 
            if (!nodes.Contains(K.end)) { 
                nodes.Add(K.end); 
            } 
            edges.Add(K); 
        }

        public void Join(Graf1 g1)
        {
            for(int i = 0; i < g1.edges.Count(); i++)
            {
                this.Add(g1.edges[i]);
            }
        }

        public List<Edge> Kruskal() { 
            List<Edge> MST = new List<Edge>();
            edges.Sort((a, b) => a.weight.CompareTo(b.weight)); 
            int[] parent = new int[nodes.Count]; 
            for (int i = 0; i < nodes.Count; i++) { 
                parent[i] = i; 
            } 
            int Find(int i) { 
                if (parent[i] == i) return i; 
                return parent[i] = Find(parent[i]); 
            } 
            void Union(int i, int j) { 
                int ri = Find(i); 
                int rj = Find(j); 
                if (ri != rj) parent[ri] = rj; 
            } 
            foreach (Edge edge in edges) { 
                int startIdx = nodes.IndexOf(edge.start); 
                int endIdx = nodes.IndexOf(edge.end); 
                if (Find(startIdx) != Find(endIdx)) { 
                    MST.Add(edge); 
                    Union(startIdx, endIdx); 
                } 
            } 
            return MST; 
        }
    }


}
