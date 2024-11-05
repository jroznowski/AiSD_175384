using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sorting
{
    internal class Tree
    {
        NodeT root;

        public void InsertNode(NodeT node)
        {
            if (this.root == null)
            {
                this.root = node;
            }
            else
            {
                Insert(this.root, node);
            }
        }

        public void Insert(NodeT root, NodeT node)
        {
            if (node.data < root.data)
            {
                if (root.lewe == null)
                {
                    root.lewe = node;
                }
                else
                {
                    Insert(root.lewe, node);
                }

            }
            else if (node.data > root.data)
            {
                if (root.prawe == null)
                {
                    root.prawe = node;
                }
                else
                {
                    Insert(root.prawe, node);
                }
            }
        }

        public void InOrder(NodeT root)
        {
            if (root.lewe != null)
            {
                InOrder(root.lewe);
            }
            Console.WriteLine(root.data);
            if (root.prawe != null)
            {
                InOrder(root.prawe);
            }
        }
        public static void Main(string[] args)
        {
            Tree drzewo = new Tree();
            drzewo.InsertNode(new NodeT(4));
            drzewo.InsertNode(new NodeT(2));
            drzewo.InsertNode(new NodeT(1));
            drzewo.InsertNode(new NodeT(6));
            drzewo.InsertNode(new NodeT(3));
            drzewo.InsertNode(new NodeT(7));
            drzewo.InsertNode(new NodeT(5));
            drzewo.InOrder(drzewo.root);
        }
    }
}

