using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sorting
{
    internal class Lista
    {
        public Node head;
        public Node tail;
        public int count;

        public void AddFirst(int data)
        {
            Node newNode = new Node(data);
            if (head == null)
            {
                head = tail = newNode;
            }
            else
            {
                newNode.next = head;
                head.prev = newNode;
                head = newNode;
            }
            count++;
        }

        public void AddLast(int data)
        {
            Node newNode = new Node(data);
            if (tail == null)
            {
                head = tail = newNode;
            }
            else
            {
                newNode.prev = tail;
                this.tail.next = newNode;
                this.tail = newNode;
            }
            count++;
        }

        public void RemoveFirst()
        {
            if (head == null)
            {
                Console.WriteLine("Lista jest pusta.");
                return;
            }
            if (head == tail)
            {
                head = tail = null;
            }
            else
            {
                head = head.next;
                head.prev = null;
            }
            count--;
        }

        public void RemoveLast()
        {
            if (tail == null)
            {
                Console.WriteLine("Lista jest pusta.");
                return;
            }
            if (head == tail)
            {
                head = tail = null;
            }
            else
            {
                tail = tail.prev;
                tail.next = null;
            }
            count--;
        }

        public int Get(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("Index out of range.");
            }

            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.next;
            }

            return current.data;
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


