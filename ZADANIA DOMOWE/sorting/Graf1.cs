using System;
using System.Collections.Generic;

namespace sorting
{
    internal class Graf1
    {
        //To-Do: przenieść grafy do oddzielnej aplikacji konsolowej, Algorytm Dijkstry
        List<NodeG1> nodes = new List<NodeG1>();
        List<Edge> edges = new List<Edge>();

        public Graf1(Edge K)
        {
            Add(K);
        }

        public int ileNowychWezlow(Edge K)
        {
            int noweWezly = 0;
            if (!nodes.Contains(K.start))
            {
                noweWezly++;
            }
            if (!nodes.Contains(K.end))
            {
                noweWezly++;
            }
            return noweWezly;
        }
        public void Add(Edge K)
        {
            if (!nodes.Contains(K.start))
            {
                nodes.Add(K.start);
            }
            if (!nodes.Contains(K.end))
            {
                nodes.Add(K.end);
            }
            edges.Add(K);
        }

        public void Join(Graf1 g1)
        {
            for (int i = 0; i < g1.edges.Count(); i++)
            {
                this.Add(g1.edges[i]);
            }
        }

        public List<Edge> Kruskal()
        {
            Graf1 MST = new Graf1();
            this.edges.Sort((k, r) => k.weight.CompareTo(r.weight)); 

            foreach (Edge edge in edges)
            {
                Graf1 tmpGraf = new Graf1(edge); 
                if (MST.ileNowychWezlow(edge) > 0) 
                {
                    MST.Join(tmpGraf); 
                }
            }

            return MST.edges; 
        }
    }

}
