using NUnit.Framework;
using DataStructure.Tree;

namespace DataStructures.Test
{
    [TestFixture]
    public class BinaryTreeTest
    {

        public BinaryTreeTest()
        {
            //_binaryTree = new BinaryTree<int>();
        }

        [Test]
        public void ReturnTrueGivenEmptyTree()
        {
            var binaryTree = new BinaryTree<int>();

            var result = binaryTree.IsEmpty();

            Assert.IsTrue(result);
        }

        [Test]
        public void TrueWhenGivenLeafNode()
        {
            var binaryNode = new BinaryTreeNode<object>(this,null,null);
            var result = binaryNode.IsLeafNode();
            Assert.IsTrue(result);
        }



    }
}
