using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sorting
{
    internal class NodeG
    {
        List<NodeG> sasiedzi = new List<NodeG>();
        int data;
        NodeG(int liczba)
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
        
        public void move_wszerz()
        {
            List<NodeG> odwiedzone = new List<NodeG>();
            for(int i = 0; i < this.sasiedzi.Count; i++)
            {
                if (!odwiedzone.Contains(this.sasiedzi.ElementAt(i))){
                    Console.WriteLine(this.sasiedzi.ElementAt(i));
                    odwiedzone.Add(this.sasiedzi.ElementAt(i));
                }
            }
        } 
    }
}
