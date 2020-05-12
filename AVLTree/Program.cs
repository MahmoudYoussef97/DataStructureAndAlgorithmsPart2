using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLTree
{
    class Program
    {
        static void Main(string[] args)
        {
            AVLTree tree = new AVLTree();
            //tree.Insert(7);
            //tree.Insert(4);
            //tree.Insert(9);
            //tree.Insert(1);
            //tree.Insert(6);
            //tree.Insert(8);
            //tree.Insert(10);
            //tree.Traverse();
            tree.Insert(10);
            tree.Insert(30);
            tree.Insert(20);
            Console.WriteLine(tree.IsPerfect());
        }
    }
}
