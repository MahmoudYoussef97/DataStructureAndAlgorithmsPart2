using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    public class MaxHeap
    {
        public static void Heapify(int[] array)
        {
            //for (int i = 0; i < array.Length; i++)
            //{
            //    Heapify(array, i);
            //}
            // for optimizaion leafe nodes doesn't matter

            for (int i = array.Length / 2 - 1; i >= 0; i--)
            {
                Heapify(array, i);
            }
        }
        private static void Heapify(int[] array, int index)
        {
            var leftChildIndex = index * 2 + 1;
            var rightChildIndex = index * 2 + 2;
            var largerChildIndex = index;

            if (leftChildIndex < array.Length && array[leftChildIndex] > array[index])
                largerChildIndex = leftChildIndex;

            if (rightChildIndex < array.Length && array[rightChildIndex] > array[largerChildIndex])
                largerChildIndex = rightChildIndex;

            if (index != largerChildIndex)
            {
                var temp = array[index];
                array[index] = array[largerChildIndex];
                array[largerChildIndex] = temp;
                Heapify(array, largerChildIndex);
            }
        }
        public static int GetKthLargestItem(int[] array, int k)
        {
            var heap = new Heap();
            foreach (var item in array)
            {
                heap.Insert(item);
            }
            var result = 0;
            while(k-- > 0)
            {
                result = heap.Remove();
            }
            return result;
        }
        public static bool IsMaxHeap(int[] numbers)
        {   
            for (int i = 0; i < numbers.Length / 2 - 1; i++)
            {
                var parentNode = i;
                var leftChild = parentNode * 2 + 1;
                var rightChild = parentNode * 2 + 2;
                if (numbers[parentNode] < numbers[leftChild]
                    || numbers[parentNode] < numbers[rightChild])
                    return false;
            }
            return true;
        }
    }
}
