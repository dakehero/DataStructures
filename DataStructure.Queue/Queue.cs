using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.Queue
{
    public class Queue<T>: IEnumerable<T>,IReadOnlyCollection<T>
    where T:IEquatable<T>
    {
        private T[] _array;
        private int _size;
        private int _head;
        private int _tail;
        
        private const int DefaultInitialCapacity = 10;

        public Queue()
        {
            _array = new T[DefaultInitialCapacity];
        }

        public Queue(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            _array = new T[capacity];
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (_size == 0)
            {
                yield break;
            }

            for (int i = _head; i != (_tail + 1) % _array.Length; i++)
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
            Array.Clear(_array,0,_array.Length);
            _size = 0;
            _head = 0;
            _tail = 0;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {

            if (array == null)
            {
                throw new ArgumentNullException();
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (array.Length - arrayIndex < _size)
            {
                throw new ArgumentException();
            }

            if(_size == 0) return;

            if (_array.Length - _head < _size)
            {
                Array.Copy(_array,_head,array,arrayIndex,_array.Length-_head);
                Array.Copy(_array,0,
                    array,arrayIndex+_array.Length-_head,
                    _size-(_array.Length-_head));
            }
            else
            {
                Array.Copy(_array,_head,array,arrayIndex,_size);
            }
        }

        public void Enqueue(T item)
        {
            if (_size == _array.Length)
            {
                int newCapacity = (int) (_array.Length * 1.25);
                var newArray = new T[newCapacity];
                Array.Copy(_array,newArray,_array.Length);
                _array = newArray;
            }

            _array[_tail++] = item;
            _tail %= _array.Length;
            _size++;
            //corefx said % operation would be much slower than use comparison expression
            //but here, we just keep it simple
        }

        public T Dequeue()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("Empty Queue!");
            }

            var result = _array[_head++];
            _head %= _array.Length;
            _size--;

            return result;
        }

        public bool TryDequeue(out T result)
        {
            if (_size == 0)
            {
                result = default(T);
                return false;
            }

            result = _array[_head++];
            _head %= _array.Length;
            _size--;

            return true;
        }

        public T Peek()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("Empty Queue!");
            }

            return _array[_head];
        }

        public bool TryPeek(out T result)
        {
            if (_size == 0)
            {
                result = default(T);
                return false;
            }

            result = _array[_head];
            return true;
        }

        public bool Contains(T item)
        {
            if (_size == 0)
            {
                return false;
            }

            for (int i = _head; i != (_tail + 1) % _array.Length; i++)
            {
                if (_array[i].Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public T[] ToArray()
        {
            if (_size == 0)
            {
                return Array.Empty<T>();
            }

            var array = new T[_size];
            if (_head > _tail)
            {
                Array.Copy(_array,_head,array,0,_array.Length-_head);
                Array.Copy(_array,0,
                    array,_array.Length-_head,
                    _size-(_array.Length-_head));
            }
            else
            {
                Array.Copy(_array,_head,array,0,_size);
            }

            return array;
        }
    }
}
