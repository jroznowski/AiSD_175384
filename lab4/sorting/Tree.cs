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

        public void AddNode(NodeT node)
        {
            if (this.root == null)
            {
                this.root = node;
            }
            else
            {
                Add(this.root, node);
            }
        }

        public void Add(NodeT root, NodeT node)
        {
            if (node.data < root.data)
            {
                if (root.lewe == null)
                {
                    root.lewe = node;
                }
                else
                {
                    Add(root.lewe, node);
                }

            }
            else
            {
                if (root.prawe == null)
                {
                    root.prawe = node;
                }
                else
                {
                    Add(root.prawe, node);
                }
            }
        }

        /*public void Remove(NodeT node)
        {

        }*/

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
        /*public static void Main(string[] args)
        {
            Tree drzewo = new Tree();
            drzewo.AddNode(new NodeT(4));
            drzewo.AddNode(new NodeT(2));
            drzewo.AddNode(new NodeT(1));
            drzewo.AddNode(new NodeT(6));
            drzewo.AddNode(new NodeT(3));
            drzewo.AddNode(new NodeT(7));
            drzewo.AddNode(new NodeT(5));
            drzewo.InOrder(drzewo.root);
        }*/
    }
}

