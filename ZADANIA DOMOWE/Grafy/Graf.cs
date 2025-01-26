using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;

namespace Grafy
{
    internal class Graf
    {
        public List<NodeG> wezly;

        public Graf()
        {
            this.wezly = new List<NodeG>();
        }

        public void dodaj_wezel(NodeG wezel)
        {
            if (!this.wezly.Contains(wezel))
            {
                this.wezly.Add(wezel);
            }
        }

        public void dodaj_krawedz(NodeG wezel1, NodeG wezel2)
        {
            if (this.wezly.Contains(wezel1) && this.wezly.Contains(wezel2))
            {
                wezel1.dodaj_sasiada(wezel2);
                wezel2.dodaj_sasiada(wezel1);
            }
        }

        public void bfs(NodeG start)
        {
            var odwiedzony = new HashSet<NodeG>();
            var queue = new Queue<NodeG>();
            odwiedzony.Add(start);
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                Console.Write(current.data + " ");

                foreach (var sasiad in current.sasiedzi)
                {
                    if (!odwiedzony.Contains(sasiad))
                    {
                        odwiedzony.Add(sasiad);
                        queue.Enqueue(sasiad);
                    }
                }
            }
            Console.WriteLine();
        }

        public void dfs(NodeG start)
        {
            var odwiedzony = new HashSet<NodeG>();
            var stack = new Stack<NodeG>();
            stack.Push(start);

            while (stack.Count > 0)
            {
                var current = stack.Pop();

                if (!odwiedzony.Contains(current))
                {
                    odwiedzony.Add(current);
                    Console.Write(current.data + " ");

                    foreach (var sasiad in current.sasiedzi)
                    {
                        if (!odwiedzony.Contains(sasiad))
                        {
                            stack.Push(sasiad);
                        }
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
