using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafy
{
    internal class NodeG
    {
        public int data;
        public List<NodeG> sasiedzi;

        public NodeG(int data)
        {
            this.data = data;
            this.sasiedzi = new List<NodeG>();
        }

        public void dodaj_sasiada(NodeG sasiad)
        {
            if (!this.sasiedzi.Contains(sasiad))
            {
                this.sasiedzi.Add(sasiad);
            }
        }
    }
}