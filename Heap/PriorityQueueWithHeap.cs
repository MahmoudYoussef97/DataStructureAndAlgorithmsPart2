using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    public class PriorityQueueWithHeap
    {
        private Heap heap = new Heap();
        public void Enqueue(int value)
        {
            heap.Insert(value);
        }
        public int Dequeue()
        {
            return heap.Remove();
        }
        public bool IsEmpty()
        {
            return heap.IsEmpty();
        }
    }
}
