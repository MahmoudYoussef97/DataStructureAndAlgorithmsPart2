using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    public class Heap
    {
        private int[] heap = new int[7];
        private int size;
        public void Insert(int value)
        {
            if (size == heap.Length)
                throw new Exception("HeapIsFull()");
            heap[size++] = value;
            BubbleUp(); // if needed
        }
        public void BubbleUp()
        {
            var index = size - 1; // index of last item
            var parentIndex = (index - 1) / 2;
            while (index > 0 &&
                heap[index] > heap[parentIndex])
            {
                int temp = heap[index];
                heap[index] = heap[parentIndex];
                heap[parentIndex] = temp;
                index = parentIndex;
                parentIndex = (index - 1) / 2;
            }
        }
        public int Remove()
        {
            if (size == 0)
                throw new Exception("HeapIsEmpty()");

            var root = heap[0];
            heap[0] = heap[--size];
            var index = 0;
            while (!IsValidParent(index))
            {
                var largeChildren = GetLargerChildrenIndex(index);
                    
                var temp = heap[largeChildren];
                heap[largeChildren] = heap[index];
                heap[index] = temp;
                index = largeChildren;
            }
            return root;
        }
        private bool IsValidParent(int index)
        {
            if (!HasLeftChild(index))
                return true;

            var isValid = heap[index] >= heap[GetLeftChildIndex(index)];
            if (!HasRightChild(index))
                isValid &= heap[index] >= heap[GetRightChildIndex(index)];

            return isValid;
        }
        private int GetLargerChildrenIndex(int index)
        {
            if (!HasLeftChild(index))
                return index;
            if (!HasRightChild(index))
                return GetLeftChildIndex(index);

            return heap[GetLeftChildIndex(index)] > heap[GetRightChildIndex(index)]
                    ? GetLeftChildIndex(index) : GetRightChildIndex(index);
        }
        private bool HasLeftChild(int index)
        {
            return GetLeftChildIndex(index) <= size;
        }
        private bool HasRightChild(int index)
        {
            return GetRightChildIndex(index) <= size;
        }
        private int GetLeftChildIndex(int index)
        {
            return index * 2 + 1;
        }
        private int GetRightChildIndex(int index)
        {
            return index * 2 + 2;
        }
        public void Print()
            {
                for (int i = 0; i < heap.Length; i++)
                {
                    Console.WriteLine($"index: {i} value: {heap[i]}");
                }
            }
        public bool IsEmpty()
        {
            return size == 0;
        }
    }
    }
