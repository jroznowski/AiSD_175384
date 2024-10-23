using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sorting
{
    internal class Node
    {
        public Node next;
        public Node prev;
        public int data;

        public Node(int data)
        {
            this.data = data;
            this.next = null;
            this.prev = null;
        }
    }


}
