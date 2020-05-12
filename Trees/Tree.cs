using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public class Tree
    {
        private Node root;
        private List<int> list = new List<int>();
        private class Node
        {
            public int value;
            public Node leftChild;
            public Node rightChild;
            public Node(int val)
            {
                value = val;
            }
        }
        public void Insert(int value)
        {
            if (root == null)
            {
                root = new Node(value);
                return;
            }
            var current = root;
            while (true)
            {
                if (current.value >= value)
                {
                    if (current.leftChild == null)
                    {
                        current.leftChild = new Node(value);
                        break;
                    }
                    current = current.leftChild;
                }
                else
                {
                    if (current.rightChild == null)
                    {
                        current.rightChild = new Node(value);
                        break;
                    }
                    current = current.rightChild;
                }
            }
        }
        public bool Find(int value)
        {
            var current = root;
            while (current != null)
            {
                if (current.value == value)
                    return true;

                if (current.value > value)
                    current = current.leftChild;
                else
                    current = current.rightChild;
            }
            return false;
        }
        public void Traverse()
        {
            TraversePreOrder(root);
            Console.WriteLine("-------------------");
            TraverseInOrder(root);
            Console.WriteLine("-------------------");
            TraversePostOrder(root);
            Console.WriteLine("-------------------");
            TraverseLvelOrder(root);
        }
        private void TraversePreOrder(Node root)
        {
            if (root == null)
                return;
            Console.WriteLine(root.value);
            TraversePreOrder(root.leftChild);
            TraversePreOrder(root.rightChild);
        }
        private void TraverseInOrder(Node root)
        {
            if (root == null)
                return;
            TraverseInOrder(root.leftChild);
            Console.WriteLine(root.value);
            TraverseInOrder(root.rightChild);
        }
        private void TraversePostOrder(Node root)
        {
            if (root == null)
                return;
            TraversePostOrder(root.leftChild);
            TraversePostOrder(root.rightChild);
            Console.WriteLine(root.value);
        }
        public int Height()
        {
            return Height(root);
        }
        private int Height(Node root)
        {
            if (root == null)
                return -1;

            if (root.leftChild == null && root.rightChild == null)
                return 0;

            return 1 + Math.Max(Height(root.leftChild), Height(root.rightChild));
        }
        public int MinBinaryTree()
        {
            return MinBinaryTree(root);
        }
        public int MinBinarySearchTree()
        {
            return MinBinarySearchTree(root);
        }
        public int MaxBinarySearchTree()
        {
            return MaxBinarySearchTree(root);
        }
        private int MaxBinarySearchTree(Node root)
        {
            if (root == null)
                throw new ArgumentNullException();

            var current = root;
            var last = current;
            while (current != null)
            {
                last = current;
                current = current.rightChild;
            }
            return last.value;
        }
        private int MinBinarySearchTree(Node root)
        {
            if (root == null)
                throw new ArgumentNullException();

            var current = root;
            var last = current;
            while (current != null)
            {
                last = current;
                current = current.leftChild;
            }
            return last.value;
        }
        private int MinBinaryTree(Node root)
        {
            if (root.leftChild == null && root.rightChild == null)
                return root.value;

            var left = MinBinaryTree(root.leftChild);
            var right = MinBinaryTree(root.rightChild);
            return Math.Min(Math.Min(left, right), root.value);
        }
        public bool Equals(Tree tree)
        {
            if (tree == null)
                throw new ArgumentNullException();

            return Equals(root, tree.root);
        }
        private bool Equals(Node first, Node second)
        {
            if (first == null && second == null)
                return true;

            if (first != null && second != null)
                return first.value == second.value
                    && Equals(first.leftChild, second.leftChild)
                    && Equals(first.rightChild, second.rightChild);

            return false;
        }
        public bool IsBinarySearchTree()
        {
            return IsBinarySearchTree(root, int.MinValue, int.MaxValue);
        }
        private bool IsBinarySearchTree(Node root, int min, int max)
        {
            if (root == null)
                return true;

            return root.value > min
                && root.value < max
                && IsBinarySearchTree(root.leftChild, min, root.value)
                && IsBinarySearchTree(root.rightChild, root.value, max);
        }
        public void PrintNodesInKthDistance(int dist)
        {
            PrintNodesInKthDistance(root, dist);
        }
        private void PrintNodesInKthDistance(Node root, int dist)
        {
            if (root == null)
                return;

            if (dist == 0)
            {
                Console.WriteLine(root.value);
                return;
            }
            PrintNodesInKthDistance(root.leftChild, dist - 1);
            PrintNodesInKthDistance(root.rightChild, dist - 1);
        }
        private void TraverseLvelOrder(Node root)
        {
            for (int i = 0; i <= Height(root); ++i)
                PrintNodesInKthDistance(i);
        }
        public int Size()
        {
            return Size(root);
        }
        private int Size(Node root)
        {
            if (root.leftChild == null && root.rightChild == null)
                return 1;

            return 1 + Size(root.leftChild) + Size(root.rightChild);
        }
        public int CountLeaves()
        {
            return CountLeaves(root, Height(root), 0);
        }
        private int CountLeaves(Node root, int height, int count)
        {
            if (root == null)
                return -1;

            if (height == 0)
            {
                count++;
                return count;
            }

            return CountLeaves(root.leftChild, height - 1, count) +
                   CountLeaves(root.rightChild, height - 1, count);
        }
        public int MaxRecursive()
        {
            return MaxRecursive(root);
        }
        private int MaxRecursive(Node root)
        {
            if (root.rightChild == null)
                return root.value;

            return MaxRecursive(root.rightChild);
        }
        public bool Contains(int value)
        {
            return Contains(root, value);
        }
        private bool Contains(Node root, int value)
        {
            if (root == null)
                return false;

            return root.value == value
                   || Contains(root.leftChild, value)
                   || Contains(root.rightChild, value);
        }
        public bool AreSibling(int first, int second)
        {
            return AreSibling(root, first, second);
        }
        private bool AreSibling(Node root, int first, int second)
        {
            if (root == null)
                return false;

            if (root.leftChild != null && root.rightChild != null)
            {
                if (root.leftChild.value == first && root.rightChild.value == second)
                    return true;
                else if (root.rightChild.value == first && root.leftChild.value == second)
                    return true;
            }

            return AreSibling(root.leftChild, first, second)
                 || AreSibling(root.rightChild, first, second);
        }
        public List<int> FindAncestors(int value)
        {
            var result = Found(root, value, list);
            if (result)
                return list;
            return list;
        }
        private bool Found(Node root, int value, List<int> list)
        {
            if (root == null)
                return false;

            if (root.value == value)
                return true;

            bool left = Found(root.leftChild, value, list);
            bool right = false;
            if (!left)
                right = Found(root.rightChild, value, list);

            if (left || right)
                list.Add(root.value);

            return left || right;
        }
    }
}
