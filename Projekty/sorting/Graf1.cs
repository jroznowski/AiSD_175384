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
    }


}
