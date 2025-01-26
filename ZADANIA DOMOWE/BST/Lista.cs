using System;
using System.Collections.Generic;

namespace BST
{

    internal class Lista
    {
        private Node head;

        public Lista()
        {
            this.head = null;
        }

        public void AddFirst(int data)
        {
            Node nowyNode = new Node(data);
            nowyNode.next = head;
            head = nowyNode;
        }

        public void AddLast(int data)
        {
            Node nowyNode = new Node(data);
            if (head == null)
            {
                head = nowyNode;
                return;
            }

            Node current = head;
            while (current.next != null)
            {
                current = current.next;
            }
            current.next = nowyNode;
        }

        public int Get(int index)
        {
            Node current = head;
            int count = 0;

            while (current != null)
            {
                if (count == index)
                {
                    return current.data;
                }
                count++;
                current = current.next;
            }

            throw new IndexOutOfRangeException("Index spoza zakresu");
        }

        public void RemoveFirst()
        {
            if (head != null)
            {
                head = head.next;
            }
        }

        public void RemoveLast()
        {
            if (head == null)
            {
                return;
            }

            if (head.next == null)
            {
                head = null;
                return;
            }

            Node current = head;
            while (current.next.next != null)
            {
                current = current.next;
            }
            current.next = null;
        }

        public void PrintList()
        {
            Node current = head;
            while (current != null)
            {
                Console.Write(current.data + " ");
                current = current.next;
            }
            Console.WriteLine();
        }
    }
}
