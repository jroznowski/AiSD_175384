﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sorting
{
    internal class NodeT
    {
        public NodeT? lewe;
        public NodeT? prawe;
        public NodeT? root;
        public int data;

        public NodeT(int data)
        {
            this.data = data;
        }
    }
}
