using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafy
{
    public class MinHeapNode
    {
        public char data;
        public uint freq;
        public MinHeapNode left, right;

        public MinHeapNode(char data, uint freq)
        {
            left = right = null;
            this.data = data;
            this.freq = freq;
        }
    }

    public class CompareMinHeapNode : IComparer<MinHeapNode>
    {
        public int Compare(MinHeapNode x, MinHeapNode y)
        {
            return x.freq.CompareTo(y.freq);
        }
    }

    public class Program
    {
        static void printCodes(MinHeapNode root, string str)
        {
            if (root == null)
                return;

            if (root.data != '$')
                Console.WriteLine(root.data + ": " + str);

            printCodes(root.left, str + "0");
            printCodes(root.right, str + "1");
        }

        static void HuffmanCodes(char[] data, uint[] freq, int size)
        {
            MinHeapNode left, right, top;
            var minHeap = new SortedSet<MinHeapNode>(new CompareMinHeapNode());

            for (int i = 0; i < size; ++i)
                minHeap.Add(new MinHeapNode(data[i], freq[i]));

            while (minHeap.Count != 1)
            {
                left = minHeap.Min;
                minHeap.Remove(left);

                right = minHeap.Min;
                minHeap.Remove(right);

                top = new MinHeapNode('$', left.freq + right.freq);
                top.left = left;
                top.right = right;

                minHeap.Add(top);
            }

            printCodes(minHeap.Min, "");
        }

        static void Main()
        {
            char[] arr = { 'A','B','C','D'};
            uint[] freq = { 1,2,3,4 };
            int size = arr.Length;
            HuffmanCodes(arr, freq, size);
        }
    }
}
