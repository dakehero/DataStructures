using NUnit.Framework;
using DataStructure.List;

namespace DataStructures.Test
{
    [TestFixture]
    public class ArrayListTest
    {
        public ArrayListTest()
        {
            
        }

        [Test]
        public void CreateNewArray()
        {
            var list = new ArrayList<int>();
            var capacity = list.Count;
            Assert.IsTrue(capacity==0);
        }

        [Test]
        public void AddItem(int item)
        {
            var list = new ArrayList<int>();
            list.Add(item);
        }
    }
}