using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BST
{
    internal class Tree
    {
        public NodeT? root;

        public void AddNode(NodeT node)
        {
            if(this.root == null)
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

        public void Remove(int key)
        {
            this.root = RemoveNode(this.root, key);
        }

        public NodeT RemoveNode(NodeT node, int key)
        {
            if (node == null)
            {
                return node;
            }
            if(key > node.data)
            {
                node.prawe = RemoveNode(node.prawe, key);
            }
            else if (key < node.data)
            {
                node.lewe = RemoveNode(node.lewe, key);
            }
            else
            {
                if(node.lewe == null)
                {
                    return node.prawe;
                }
                else if(node.prawe == null)
                {
                    return node.lewe;
                }

                NodeT temp = node.prawe;
                while(temp.lewe != null)
                {
                    temp = temp.lewe;
                }

                node.data = temp.data;

                node.prawe = this.RemoveNode(node.prawe, temp.data);
            }
            return node;
        }

        public void inOrder(NodeT root)
        {
            if(root.lewe != null)
            {
                inOrder(root.lewe);
            }
            Console.WriteLine(root.data);
            if(root.prawe != null)
            {
                inOrder(root.prawe);
            }
        }

        public void preOrder(NodeT root)
        {
            Console.WriteLine(root.data);
            if (root.lewe != null)
            {
                preOrder(root.lewe);
            }
            
            if (root.prawe != null)
            {
                preOrder(root.prawe);
            }
        }
    }
}
