using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    public class MinHeap
    {
        Node[] heap = new Node[6];
        private int size;
        private class Node
        {
            public int key;
            public string value;
            public Node(int k, string v)
            {
                key = k;
                value = v;
            }
        }
        public void Insert(int k, string s)
        {
            if (size == heap.Length)
                throw new Exception("HeapIsFull()");

            heap[size++] = new Node(k, s);
            // Bubble Up
            BubbleUp();
        }
        private void BubbleUp()
        {
            var index = size - 1; // index of last element
            while(index > 0 && heap[index].key < GetParentKey(index))
            {
                // swap
                Swap(index, GetParentIndex(index));
                index = GetParentIndex(index);
            }
        }
        private void Swap(int first, int second)
        {
            var temp = heap[first];
            heap[first] = heap[second];
            heap[second] = temp;
        }
        private int GetParentKey(int index)
        {
            return heap[GetParentIndex(index)].key;
        }
        private int GetParentIndex(int index)
        {
            return (index - 1) / 2;
        }
        public void Print()
        {
            foreach (var item in heap)
            {
                Console.WriteLine(item.key);
            }
        }
    }
}
