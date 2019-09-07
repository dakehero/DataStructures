using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.Tree
{
    public class BinarySearchTree<T> : BinaryTree<T> where T : IComparable<T>, IEquatable<T>
    {
        public BinarySearchTree() { }

        public BinarySearchTree(T node) : base(node) { }

        public BinaryTreeNode<T> Find(T data)
        {
            if (IsEmpty())
                throw new NullReferenceException("Empty Tree");
            return Find(data, Root);
        }

        public bool Contains(T data)
        {
            if (Find(data) != null)
                return true;
            else
                return false;
        }

        private BinaryTreeNode<T> Find(T data, BinaryTreeNode<T> node)
        {
            if (node == null)
                return null;
            if (data.Equals(node.data))
            {
                return node;
            }
            else if (!node.IsLeafNode())
            {
                if (data.CompareTo(node.data) < 0)
                    return node.LeftChild ?? Find(data, node.LeftChild);
                else if (data.CompareTo(node.data) > 0)
                    return node.RightChild ?? Find(data, node.RightChild);
                else
                    return node;
            }
            return null;//not suppoesd to be here
        }

        public BinaryTreeNode<T> FindMin()
        {
            if (IsEmpty())
                throw new NullReferenceException("Empty Tree");
            return FindMin(Root);
        }

        private BinaryTreeNode<T> FindMin(BinaryTreeNode<T> node)
        {
            if (node != null)
                while (node.LeftChild != null)
                    node = node.LeftChild;
            return node;
        }

        public BinaryTreeNode<T> FindMax()
        {
            if (IsEmpty())
                throw new NullReferenceException("Empty Tree");
            return FindMax(Root);
        }

        private BinaryTreeNode<T> FindMax(BinaryTreeNode<T> node)
        {
            if (node != null)
                while (node.RightChild != null)
                    node = node.RightChild;
            return node;
        }

        public void Insert(T data)
        {
            Root = Insert(data, Root);
        }

        private BinaryTreeNode<T> Insert(T data, BinaryTreeNode<T> node)
        {
            if (node == null)
                return new BinaryTreeNode<T>(data, null, null);
            else
            {
                int compareResult = data.CompareTo(node.data);
                if (compareResult > 0)
                    node.RightChild = Insert(data, node.RightChild);
                else if (compareResult < 0)
                    node.LeftChild = Insert(data, node.LeftChild);
            }
            return node;

        }

        public void Remove(T data)
        {
            Root = Remove(data, Root);
        }

        private BinaryTreeNode<T> Remove(T data, BinaryTreeNode<T> node)
        {
            if (node == null)
                return null;

            int compareResult = data.CompareTo(node.data);
            if (compareResult > 0)
                node.RightChild = Remove(data, node.RightChild);
            else if (compareResult < 0)
                node.LeftChild = Remove(data, node.LeftChild);
            else if (node.RightChild != null && node.RightChild != null)
            {
                node.data = FindMin(node.RightChild).data;
                node.RightChild = Remove(node.data, node.RightChild);
            }
            else
            {
                node = node.LeftChild ?? node.RightChild;
            }
            return node;
        }
    }
}
