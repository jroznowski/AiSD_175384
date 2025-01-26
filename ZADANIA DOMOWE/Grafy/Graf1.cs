using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafy
{
    internal class Graf1
    {
        public List<NodeG1> nodes;
        public List<Edge> edges;

        public Graf1(List<NodeG1> nodes, List<Edge> edges)
        {
            this.nodes = nodes;
            this.edges = edges;
        }

        public Graf1(Edge k)
        {
            this.nodes = new List<NodeG1> { k.start, k.end };
            this.edges = new List<Edge> { k };
        }

        public int IleNowych(Edge k)
        {
            int noweWierzcholki = 0;

            if (!this.nodes.Contains(k.start))
            {
                noweWierzcholki++;
            }

            if (!this.nodes.Contains(k.end))
            {
                noweWierzcholki++;
            }

            return noweWierzcholki;
        }

        public void Add(Edge k)
        {
            this.edges.Add(k);

            if (!this.nodes.Contains(k.start))
            {
                this.nodes.Add(k.start);
            }

            if (!this.nodes.Contains(k.end))
            {
                this.nodes.Add(k.end);
            }

            if (IleNowych(k) == 2)
            {
                Graf1 g2 = new Graf1(k);
            }
        }

        public void Join(Graf1 g1)
        {
            foreach (var edge in g1.edges)
            {
                this.Add(edge);
            }
        }

        public Graf1 Kruskal_()
        {
            var krawedzie = this.edges.OrderBy(k => k.weight).ToList();
            var grafy = new List<Graf1>() { new Graf1(krawedzie[0]) };

            for (int i = 1; i < krawedzie.Count; i++)
            {
                var k = krawedzie[i];
                var l = -1;

                for (int j = 0; j < grafy.Count; j++)
                {
                    var g = grafy[j];
                    switch (g.IleNowych(k))
                    {
                        case 2:
                            grafy.Add(new Graf1(k));
                            j = grafy.Count;
                            break;
                        case 0:
                            j = grafy.Count;
                            break;
                        case 1:
                            if (l == -1)
                            {
                                g.Add(k);
                                l = j;
                                break;
                            }
                            else
                            {
                                grafy[l].Join(g);
                                grafy.RemoveAt(j);
                                j = grafy.Count;
                                break;
                            }
                    }
                }
            }

            return grafy[0];
        }

        public List<Element> PrzygotujTabelke(NodeG1 start)
        {
            var tabelka = new List<Element>();

            foreach (var node in this.nodes)
            {
                tabelka.Add(new Element(node, int.MaxValue));
            }

            var startElement = tabelka.First(e => e.wezel == start);
            startElement.dystans = 0;

            return tabelka;
        }

        public List<Element> Dijkstra(NodeG1 start)
        {
            var tabelka = this.PrzygotujTabelke(start);
            var zbS = new List<NodeG1>();
            var kandydaci = tabelka.Where(e => !zbS.Contains(e.wezel)).ToList();

            while (kandydaci.Count > 0)
            {
                var kandydat = kandydaci.OrderBy(e => e.dystans).First();
                zbS.Add(kandydat.wezel);

                var sasiedzi = this.edges.Where(k => k.start == kandydat.wezel).ToList();

                foreach (var edge in sasiedzi)
                {
                    var sasiadElement = tabelka.First(e => e.wezel == edge.end);
                    var nowyDystans = kandydat.dystans + edge.weight;

                    if (nowyDystans < sasiadElement.dystans)
                    {
                        sasiadElement.dystans = nowyDystans;
                    }
                }

                kandydaci = tabelka.Where(e => !zbS.Contains(e.wezel)).ToList();
            }

            return tabelka;
        }
    }

    internal class Element
    {
        public NodeG1 wezel;
        public int dystans;

        public Element(NodeG1 wezel, int dystans)
        {
            this.wezel = wezel;
            this.dystans = dystans;
        }
    }
}
