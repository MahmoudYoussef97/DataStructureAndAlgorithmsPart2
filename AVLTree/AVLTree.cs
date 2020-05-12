using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLTree
{
    public class AVLTree
    {
        private AVLNode root;
        private class AVLNode
        {
            public int value;
            public AVLNode leftChild;
            public AVLNode rightChild;
            public int height;
            public int size;
            public AVLNode(int val)
            {
                value = val;
            }
        }
        public void Insert(int value)
        {
            root = Insert(root, value);
        }
        private AVLNode Insert(AVLNode root, int value)
        {
            if (root == null)
                return new AVLNode(value);

            if (root.value > value)
                root.leftChild = Insert(root.leftChild, value);
            else
                root.rightChild = Insert(root.rightChild, value);

            SetHeight(root);
            SetSize(root);

            return Balance(root);
        }
        private void SetSize(AVLNode node)
        {
            node.size = Size(node.leftChild) + Size(node.rightChild);
        }
        private AVLNode Balance(AVLNode node)
        {
            if (IsLeftHeavy(node))
            {
                if (BalanceFactor(node.leftChild) > 0)
                    return RotateRight(node);
                else if (BalanceFactor(node.leftChild) < 0)
                {
                    node.leftChild = RotateLeft(node.leftChild);
                    return RotateRight(node);
                }
            }
            else if (IsRightHeavy(node))
            {
                if (BalanceFactor(node.rightChild) < 0)
                    return RotateLeft(node);
                else if (BalanceFactor(node.rightChild) > 0)
                {
                    node.rightChild = RotateRight(node.rightChild);
                    return RotateLeft(node);
                }
            }
            return node;
        }
        private AVLNode RotateLeft(AVLNode node)
        {
            var newRoot = node.rightChild;
            node.rightChild = newRoot.leftChild;
            newRoot.leftChild = node;

            SetHeight(node);
            SetHeight(newRoot);
            SetSize(node);
            SetSize(newRoot);

            return newRoot;
        }
        private AVLNode RotateRight(AVLNode node)
        {
            var newRoot = node.leftChild;
            node.leftChild = newRoot.rightChild;
            newRoot.rightChild = node;

            SetHeight(node);
            SetHeight(newRoot);
            SetSize(node);
            SetSize(newRoot);

            return newRoot;
        }
        private void SetHeight(AVLNode node)
        {
            node.height = Math.Max(Height(node.leftChild),
                                   Height(node.rightChild)) + 1;
        }
        private bool IsLeftHeavy(AVLNode node)
        {
            return BalanceFactor(node) > 1;
        }
        private bool IsRightHeavy(AVLNode node)
        {
            return BalanceFactor(node) < -1;
        }
        private int BalanceFactor(AVLNode node)
        {
            return node == null ? 0 : Height(node.leftChild) - Height(node.rightChild);
        }
        private int Height(AVLNode node)
        {
            return node == null ? -1 : node.height;
        }
        public void Traverse()
        {
            TraversePreOrder(root);
            Console.WriteLine("-------------------");
            TraverseInOrder(root);
            Console.WriteLine("-------------------");
            TraversePostOrder(root);
        }
        private void TraversePreOrder(AVLNode root)
        {
            if (root == null)
                return;
            Console.WriteLine(root.value);
            TraversePreOrder(root.leftChild);
            TraversePreOrder(root.rightChild);
        }
        private void TraverseInOrder(AVLNode root)
        {
            if (root == null)
                return;
            TraverseInOrder(root.leftChild);
            Console.WriteLine(root.value);
            TraverseInOrder(root.rightChild);
        }
        private void TraversePostOrder(AVLNode root)
        {
            if (root == null)
                return;
            TraversePostOrder(root.leftChild);
            TraversePostOrder(root.rightChild);
            Console.WriteLine(root.value);
        }
        public bool IsPerfect()
        {
            return IsPerfect(root);
        }
        private bool IsPerfect(AVLNode node)
        {
            return (node.leftChild.height) == (node.rightChild.height)
                && node.leftChild.size == node.rightChild.size;
        }
        private int Size(AVLNode node)
        {
            return node == null ? 1 : node.size;
        }
    }
}
