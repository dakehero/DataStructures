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
    public class BinaryTree<T>
    {
        public BinaryTreeNode<T> Root { get; protected set; }

        public BinaryTree() { }

        public BinaryTree(T data)
        {
            this.Root = new BinaryTreeNode<T>(data);
        }

        #region Basic Methods
        public bool IsEmpty()
        {
            return Root == null;
        }

        public int GetDepth()
        {
            return GetDepth(Root);
        }

        private int GetDepth(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                return 0;
            }

            int leftDepth = GetDepth(node.LeftChild);
            int rightDepth = GetDepth(node.RightChild);
            return leftDepth > rightDepth ? leftDepth + 1 : rightDepth + 1;
        }

        #endregion

        #region Traversals
        public virtual void PreOrder(Action<BinaryTreeNode<T>> visitNode)
        {
            if (IsEmpty())
                throw new NullReferenceException("Empty Tree");
            PreOrder(Root, visitNode);
        }

        private void PreOrder(BinaryTreeNode<T> node, Action<BinaryTreeNode<T>> visitNode)
        {
            
            visitNode(node);
            if (node.LeftChild!=null)
            {
                PreOrder(node.LeftChild,visitNode);
            }
            if (node.RightChild!=null)
            {
                PreOrder(node.RightChild,visitNode);
            }
                
            
        }

        public virtual void MidOrder(Action<BinaryTreeNode<T>> visitNode)
        {
            if (IsEmpty())
                throw new NullReferenceException("Empty Tree");
            MidOrder(Root, visitNode);
        }

        private void MidOrder(BinaryTreeNode<T> node, Action<BinaryTreeNode<T>> visitNode)
        {
            if (node.LeftChild!=null)
            {
                PreOrder(node.LeftChild,visitNode);
            }
            visitNode(node);
            if (node.RightChild!=null)
            {
                PreOrder(node.RightChild,visitNode);
            }

        }

        public virtual void PostOrder(Action<BinaryTreeNode<T>> visitNode)
        {
            if (IsEmpty())
                throw new NullReferenceException("Empty Tree");
            PostOrder(Root, visitNode);
        }

        private void PostOrder(BinaryTreeNode<T> node, Action<BinaryTreeNode<T>> visitNode)
        {
            if (node.LeftChild!=null)
            {
                PreOrder(node.LeftChild,visitNode);
            }

            if (node.RightChild!=null)
            {
                PreOrder(node.RightChild,visitNode);
            }

            visitNode(node);
        }

        public virtual void LevelOrder(Action<BinaryTreeNode<T>> visitNode)
        {
            if (IsEmpty())
                throw new NullReferenceException("Empty Tree");
            LevelOrder(Root, visitNode);
        }

        public static void LevelOrder(BinaryTreeNode<T> node, Action<BinaryTreeNode<T>> visitNode)
        {
            Queue<BinaryTreeNode<T>> queue = new Queue<BinaryTreeNode<T>>();
            queue.Enqueue(node);
            BinaryTreeNode<T> currentNode = null;
            while(queue.Count!=0)
            {
                currentNode = queue.Dequeue();
                visitNode(currentNode);
                if(currentNode.LeftChild!=null)
                {
                    queue.Enqueue(currentNode.LeftChild);
                }
                if (currentNode.RightChild != null)
                {
                    queue.Enqueue(currentNode.RightChild);
                }
            }
        }

        //TODO: Add Traversals without recursion


        #endregion

    }
}
