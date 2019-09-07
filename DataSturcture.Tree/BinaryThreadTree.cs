using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.Tree
{
    public class BinaryThreadTreeNode<T> : BinaryTreeNode<T>
    {

        public bool IsLeftThread { get; set; }
        public bool IsRightThread { get; set; }

        public BinaryThreadTreeNode() : base() { }
        public BinaryThreadTreeNode(T data)
        {
            this.data = data;
            LeftChild = null;
            RightChild = null;
            IsLeftThread = false;
            IsRightThread = false;
        }

    }

    public enum TraversalType
    {
        PreOrder,MidOrder,PostOrder
    }

    public class BinaryThreadTree<T> : BinaryTree<T>
    {
        //public new BinaryThreadTreeNode<T> Root { get; set; }

        public BinaryThreadTree() : base() { }

        public BinaryThreadTree(T data)
        {
            this.Root = new BinaryThreadTreeNode<T>(data);
        }

        #region traversals

        private void PreOrder(BinaryThreadTreeNode<T> node,Action<BinaryThreadTreeNode<T>> visitNode)
        {
            visitNode(node);
            if(!node.IsLeftThread)
                visitNode(node.LeftChild as BinaryThreadTreeNode<T>);
            if(!node.IsRightThread)
                visitNode(node.RightChild as BinaryThreadTreeNode<T>);
        }

        private void MidOrder(BinaryThreadTreeNode<T> node, Action<BinaryThreadTreeNode<T>> visitNode)
        {
            if(!node.IsLeftThread)
                visitNode(node.LeftChild as BinaryThreadTreeNode<T>);
            visitNode(node);
            if(!node.IsRightThread)
                visitNode(node.RightChild as BinaryThreadTreeNode<T>);
        }

        private void PostOrder(BinaryThreadTreeNode<T> node, Action<BinaryThreadTreeNode<T>> visitNode)
        {
            if(!node.IsLeftThread)
                visitNode(node.LeftChild as BinaryThreadTreeNode<T>);
            if(!node.IsRightThread)
            visitNode(node.RightChild as BinaryThreadTreeNode<T>);
            visitNode(node);
        }
        #endregion

        public void Threaded(TraversalType t)
        {
            var preNode = new BinaryThreadTreeNode<T>();
            if (t == TraversalType.PreOrder)
            {
                PreOrder(Root as BinaryThreadTreeNode<T>,
                    (BinaryThreadTreeNode<T> node) =>
                    {

                        if (preNode.IsRightThread)
                        {
                            preNode.RightChild = node;
                        }
                        if (node.LeftChild == null)
                        {
                            node.IsLeftThread = true;
                            node.LeftChild = preNode;
                        }
                        if (node.RightChild == null)
                        {
                            node.IsRightThread = true;
                        }

                        preNode = node;
                    });
            }

            else if (t == TraversalType.MidOrder)
            {
                MidOrder(Root as BinaryThreadTreeNode<T>,
                    (BinaryThreadTreeNode<T> node) =>
                    {

                        if (preNode.IsRightThread)
                        {
                            preNode.RightChild = node;
                        }
                        if (node.LeftChild == null)
                        {
                            node.IsLeftThread = true;
                            node.LeftChild = preNode;
                        }
                        if (node.RightChild == null)
                        {
                            node.IsRightThread = true;
                        }

                        preNode = node;
                    });
            }

            else if(t==TraversalType.PostOrder)
            {
                PostOrder(Root as BinaryThreadTreeNode<T>,
                    (BinaryThreadTreeNode<T> node) =>
                    {

                        if (preNode.IsRightThread)
                        {
                            preNode.RightChild = node;
                        }
                        if (node.LeftChild == null)
                        {
                            node.IsLeftThread = true;
                            node.LeftChild = preNode;
                        }
                        if (node.RightChild == null)
                        {
                            node.IsRightThread = true;
                        }

                        preNode = node;
                    });
            }
        }


    }

}
