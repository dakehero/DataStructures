using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.Tree
{
    public class BinaryTreeNode<T>
    {

        public T data { get; set; }

        public BinaryTreeNode<T> LeftChild { get; set; }

        public BinaryTreeNode<T> RightChild { get; set; }

        public BinaryTreeNode() { }

        public BinaryTreeNode(T data)
        {
            this.data = data;
            LeftChild = null;
            RightChild = null;
        }

        public BinaryTreeNode(T data, BinaryTreeNode<T> lchild, BinaryTreeNode<T> rchild)
        {
            this.data = data;
            this.LeftChild = lchild;
            this.RightChild = rchild;
        }

        public bool IsLeafNode()
        {
            return LeftChild == null && RightChild == null;
        }

    }
}

