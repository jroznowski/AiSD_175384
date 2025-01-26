using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sorting
{
    public class NodeG
    {
        public List<NodeG> sasiedzi = new List<NodeG>();
        public int data;
        public NodeG(int liczba)
        {
            this.data = liczba;
        }

        public override string ToString()
        {
            return this.data.ToString();
        }

        public void dodaj_sasiada(NodeG dane)
        {
            if (!this.sasiedzi.Contains(dane))
            {
                this.sasiedzi.Add(dane);
            }
        }
       
    }
}
