using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 5, 3, 8, 4, 1, 2};
            MinHeap heap = new MinHeap();
            foreach (var item in numbers)
            {
                heap.Insert(item, "Hello");
            }
            heap.Print();
        }
    }
}
