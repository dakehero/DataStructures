using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.Tree
{
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
        public void PreOrder(Action<BinaryTreeNode<T>> visitNode)
        {
            if (IsEmpty())
                throw new NullReferenceException("Empty Tree");
            PreOrder(Root, visitNode);
        }

        private void PreOrder(BinaryTreeNode<T> node, Action<BinaryTreeNode<T>> visitNode)
        {

            visitNode(node);
            visitNode(node.LeftChild);
            visitNode(node.RightChild);

        }

        public void MidOrder(Action<BinaryTreeNode<T>> visitNode)
        {
            if (IsEmpty())
                throw new NullReferenceException("Empty Tree");
            MidOrder(Root, visitNode);
        }

        private void MidOrder(BinaryTreeNode<T> node, Action<BinaryTreeNode<T>> visitNode)
        {
            visitNode(node.LeftChild);
            visitNode(node);
            visitNode(node.RightChild);
        }

        public void PostOrder(Action<BinaryTreeNode<T>> visitNode)
        {
            if (IsEmpty())
                throw new NullReferenceException("Empty Tree");
            PostOrder(Root, visitNode);
        }

        private void PostOrder(BinaryTreeNode<T> node, Action<BinaryTreeNode<T>> visitNode)
        {
            visitNode(node.LeftChild);
            visitNode(node.RightChild);
            visitNode(node);
        }

        public void LevelOrder(Action<BinaryTreeNode<T>> visitNode)
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

        //TODO: Add Traversals wihtout recursion


        #endregion

    }
}
