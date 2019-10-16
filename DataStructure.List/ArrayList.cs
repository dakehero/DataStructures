using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.List
{
    public class ArrayList<T> :IList<T> where T:IEquatable<T>
    {

        private const int DefaultCapacity = 10;

        private T[] _itemsArray;

        private int _size;

        public ArrayList()
        {
            _itemsArray = new T[DefaultCapacity];
            _size = 0;
        }

        public ArrayList(int capacity)
        {
            _itemsArray =new T[capacity];
            _size = 0;
        }

        public int Count => _size;

        public bool IsReadOnly => false;

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in _itemsArray)
            {
                yield return item;//black magic by compiler which generates a Enumerator class
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            //when array is full
            if (_size == _itemsArray.Length)
            {
                Resize();
            }

            _itemsArray[_size++] = item;

        }

        public void Clear()
        {
            _size = 0;
            _itemsArray = new T[DefaultCapacity];
        }

        public bool Contains(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var arrayItem in _itemsArray)
            {
                if (arrayItem.Equals(item))
                    return true;
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _itemsArray.CopyTo(array,arrayIndex);
        }

        public bool Remove(T item)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_itemsArray[i].Equals(item))
                {
                    for (int j = i+1; j < _size; j++,i++)
                    {
                        _itemsArray[i] = _itemsArray[j];
                    }
                    _size--;
                    return true;
                }
            }

            return false;
        }


        public int IndexOf(T item)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_itemsArray[i].Equals(item))
                    return i;
            }
            throw new IndexOutOfRangeException();
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > _size)
            {
                throw new IndexOutOfRangeException();
            }
            if (_size == _itemsArray.Length)
            {
                Resize();
            }
            //move all items
            for (int i = _size; i > index; i--)
            {
                _itemsArray[i] = _itemsArray[i - 1];
            }

            _itemsArray[index] = item;
            _size++;

        }

        public void RemoveAt(int index)
        {

            if (index < 0 || index >= _size)
            {
                throw new IndexOutOfRangeException();
            }

            for (int i = index; i < _size; i++)
            {
                _itemsArray[i] = _itemsArray[i + 1];
            }
            

        }

        public T this[int index]
        {
            get
            {
                if (index < _size)
                    return _itemsArray[index];
                else
                    throw new IndexOutOfRangeException();
            }
            set
            {
                if (index < _size) 
                    _itemsArray[index]=value;
                else
                    throw new IndexOutOfRangeException();
            }
        }

        private void Resize()
        {
            var newArray = new T[_itemsArray.Length * 2];
            _itemsArray.CopyTo(newArray,0);
            _itemsArray = newArray;
        }


    }
}
