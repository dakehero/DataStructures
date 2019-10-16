using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace DataStructure.Stack
{
    public class Stack<T>: IEnumerable<T>,IReadOnlyCollection<T> where T:IEquatable<T>
    {
        private T[] _array;
        private int _size;

        private const int InitialCapacity = 10;

        public Stack()
        {
            _array=new T[InitialCapacity];
            _size = 0;
        }

        public Stack(ushort capacity)
        {
            _array=new T[capacity];
            _size = 0;
        }

        public Stack(IEnumerable<T> collection):this()
        {
            if (collection == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var item in collection)
            {
                Push(item);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = _size - 1; i >= 0; i--)
            {
                yield return _array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Count => _size;


        public void Clear()
        {
            Array.Clear(_array,0,_size);
            _size = 0;
        }

        public bool Contains(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }
            for (int i = 0; i < _size; i++)
            {
                if (_array[i].Equals(item))
                    return true;
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (arrayIndex < 0 || arrayIndex > _array.Length)
            {
                throw new ArgumentOutOfRangeException();
            }
            try 
            {                
                Array.Copy(_array, 0, array, arrayIndex, _size);
                Array.Reverse(array, arrayIndex, _size);
            }
            catch(ArrayTypeMismatchException)
            {
                throw new ArgumentException();
            }
        }

        public T Peek()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("Empty stack!");
            }

            return _array[_size - 1];
        }

        public T Pop()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("Empty stack!");
            }
            return _array[-- _size];
        }

        public void Push(T item)
        {
            if (_size == _array.Length) {
                T[] newArray = new T[(_array.Length == 0) ? InitialCapacity : 2*_array.Length];
                Array.Copy(_array, 0, newArray, 0, _size);
                _array = newArray;
            }
            _array[_size++] = item;
        }

        public T[] ToArray()
        {
            var newArray = new T[_size];
            Array.Copy(_array,0,newArray,0,_size);
            return newArray;
        }
    }
}
