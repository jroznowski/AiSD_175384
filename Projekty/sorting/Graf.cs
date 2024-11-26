using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sorting
{
    internal class Graf
    {
        List<NodeG> nodes = new List<NodeG>();

        public void dodajWezel(NodeG node)
        {
            nodes.Add(node);
        }

        public void wzdluz(NodeG start, List<NodeG> wizyty)
        {
            if (wizyty.Contains(start))
            {
                return;
            }

            wizyty.Add(start);
            Console.WriteLine(start);

            foreach (NodeG sasiad in start.sasiedzi)
            {
                if (!wizyty.Contains(sasiad))
                {
                    wzdluz(sasiad, wizyty);
                }
            }
        }

        public void wrzesz(NodeG start)
        {
            List<NodeG> wizyty = new List<NodeG> { start };
            List<NodeG> odwiedzone = new List<NodeG> { start };

            while (odwiedzone.Count > 0)
            {
                NodeG aktualny = odwiedzone[0];
                odwiedzone.RemoveAt(0);

                if (!wizyty.Contains(aktualny))
                {
                    wizyty.Add(aktualny);
                    Console.WriteLine(aktualny);

                    foreach (var sasiad in aktualny.sasiedzi)
                    {
                        if (!wizyty.Contains(sasiad))
                        {
                            odwiedzone.Add(sasiad);
                        }
                    }
                }
            }
        }

        /*
        static void Main(string[] args)
        {
               
            NodeG w1 = new NodeG(1);
            NodeG w2 = new NodeG(2);
            NodeG w3 = new NodeG(3);
            NodeG w4 = new NodeG(4);

            w1.dodaj_sasiada(w2);
            w1.dodaj_sasiada(w3);
            w2.dodaj_sasiada(w4);

            Graf graf = new Graf();
            graf.dodajWezel(w1);
            graf.dodajWezel(w2);
            graf.dodajWezel(w3);
            graf.dodajWezel(w4);

            Console.WriteLine("Przejście BFS:");
            graf.wrzesz(w1);

            // Inicjalizacja listy odwiedzonych węzłów i wywołanie metody DFS
            var wizyty = new List<NodeG>();
            Console.WriteLine("\nPrzejście DFS:");
            graf.wzdluz(w1, wizyty);
        }
        */

    }






}
