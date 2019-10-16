using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.List
{
    internal class LinkedListNode<T> where T : IEquatable<T>, new()
    {
        public LinkedListNode(){}

        public LinkedListNode(T item)
        {
            Value = item;
            Next = null;
            Previous = null;
        }

        public T Value { get; set; }

        public LinkedListNode<T> Next { get; set; }

        public LinkedListNode<T> Previous { get; set; }
    }

    public class LinkedList<T> : IList<T> where T : IEquatable<T>, new()
    {
        public int Count { get; private set; }

        public bool IsReadOnly => false;

        private LinkedListNode<T> _head;

        private LinkedListNode<T> _last;

        public LinkedList()
        {
            _head = new LinkedListNode<T>()
            {
                Value = default(T),
                Next = null,
                Previous = null
            };
            _last = _head;

            Count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = _head.Next;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            _last.Next = new LinkedListNode<T>()
            {
                Value = item,
                Next = null,
                Previous = _last
            };
            _last = _last.Next;
            Count++;
        }

        public void Clear()
        {
            _head = new LinkedListNode<T>()
            {
                Value = default(T),
                Next = null,
                Previous = null
            };
            _last = _head;
            Count = 0;
        }

        public bool Contains(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            var currentNode = _head.Next;
            while (currentNode != null)
            {
                if (currentNode.Value.Equals(item))
                {
                    return true;
                }

                currentNode = currentNode.Next;
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            var currentNode = _head.Next;
            try
            {
                for (int i = arrayIndex; currentNode != null; i++, currentNode = currentNode.Next)
                {
                    array[i] = currentNode.Value;
                }
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public bool Remove(T item)
        {
            var currentNode = _head.Next;
            while (currentNode != null)
            {
                if (currentNode.Value.Equals(item))
                {
                    if (currentNode == _last)
                    {
                        _last = currentNode.Previous;
                    }

                    //delete item
                    var prior = currentNode.Previous;
                    var next = currentNode.Next;
                    prior.Next = next;
                    next.Previous = prior;
                    currentNode.Next = null;
                    currentNode.Previous = null;


                    Count--;
                    return true;
                }

                currentNode = currentNode.Next;
            }

            return false;
        }


        public int IndexOf(T item)
        {
            int index = -1;
            var current = _head.Next;

            for (int i = 0; current != null; i++, current = current.Next)
            {
                if (current.Value.Equals(item))
                {
                    index = i;
                }
            }


            return index;
        }

        public void Insert(int index, T item)
        {
            if (index >= Count-1 || index < 0)
                throw new ArgumentOutOfRangeException();

            var current = _head.Next;
            for (int i = 0; current != null; i++, current = current.Next)
            {
                if (i == index)
                {
                    var newNode = new LinkedListNode<T>(item);

                    newNode.Previous = current.Previous;
                    newNode.Previous.Next = newNode;
                    newNode.Next = current;
                    current.Previous = newNode;

                    Count++;

                    return;
                }
            }

        }

        public void RemoveAt(int index)
        {
            if (index >= Count || index < 0)
                throw new ArgumentOutOfRangeException();

            var current = _head.Next;

            for (int i = 0; current != null; i++, current = current.Next)
            {
                if (i == index)
                {
                    if (current == _last)
                    {
                        _last = current.Previous;
                    }
                    var prior = current.Previous;
                    var next = current.Next;
                    prior.Next = next;
                    next.Previous = prior;
                    current.Next = null;
                    current.Previous = null;

                    Count--;
                    return;
                }
            }
        }

        public T this[int index]
        {
            get
            {
                if (index >= Count || index < 0)
                    throw new IndexOutOfRangeException();
                var current = _head.Next;
                for (var i = 0; current != null; i++, current = current.Next)
                {
                    if (i == index)
                    {
                        return current.Value;
                    }
                }
                throw new Exception();
            }
            set
            {
                if (index >= Count || index < 0)
                    throw new IndexOutOfRangeException();
                var current = _head.Next;
                for (var i = 0; current != null; i++, current = current.Next)
                {
                    if (i == index)
                    {
                        current.Value = value;
                    }
                }
                throw new Exception();
            }
        }
    }


}
