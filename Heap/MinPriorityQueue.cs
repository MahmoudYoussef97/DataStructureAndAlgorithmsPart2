using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    public class MinPriorityQueue
    {
        private MinHeap heap = new MinHeap();
        public void Add(string value, int priority)
        {
            heap.Insert(priority, value);
        }
        
    }
}
