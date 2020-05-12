﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree tree = new Tree();
            tree.Insert(7);
            tree.Insert(4);
            tree.Insert(9);
            tree.Insert(1);
            tree.Insert(6);
            tree.Insert(8);
            tree.Insert(10);
            foreach (var item in tree.FindAncestors(10))
            {
                Console.WriteLine(item);
            }
            //tree.Traverse();
            //tree.PrintNodesInKthDistance(1);
        }
    }
}
