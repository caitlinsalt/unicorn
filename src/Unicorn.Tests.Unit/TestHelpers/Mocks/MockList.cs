using System.Collections;
using System.Collections.Generic;

namespace Unicorn.Tests.Unit.TestHelpers.Mocks
{
    internal class MockList<T> : IList<T>
    {
        private readonly List<T> _underlying = new();

        public T this[int index]
        {
            get => _underlying[index];
            set => _underlying[index] = value;
        }

        public int Count => _underlying.Count;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            _underlying.Add(item);
        }

        public void Clear()
        {
            _underlying.Clear();
        }

        public bool Contains(T item) => _underlying.Contains(item);

        public void CopyTo(T[] array, int arrayIndex)
        {
            _underlying.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator() => _underlying.GetEnumerator();

        public int IndexOf(T item) => _underlying.IndexOf(item);

        public void Insert(int index, T item)
        {
            _underlying.Insert(index, item);
        }

        public bool Remove(T item) => _underlying.Remove(item);

        public void RemoveAt(int index)
        {
            _underlying.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        internal static MockList<T> FromEnumerable(IEnumerable<T> data)
        {
            MockList<T> newList = new();
            newList._underlying.AddRange(data);
            return newList;
        }
    }
}
