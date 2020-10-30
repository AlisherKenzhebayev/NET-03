using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;

namespace U10_GenericsCollections.T_06
{
    public class CollectionSet<T> : IEnumerable<T>, IEnumerator<T>, ICollection<T>
    {
        private CollectionSet()
        {
            Set = new List<T>();
            Iterator = -1;
        }

        public int Count => Set.Count();

        public bool IsReadOnly => Set.IsReadOnly;

        private IList<T> Set { get; set; }

        private int Iterator { get; set; }

        public IEnumerator<T> GetEnumerator()
        {
            return Set.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool MoveNext()
        {
            var updatedPosition = Iterator + 1;

            if (updatedPosition >= 0 && updatedPosition < Set.Count)
            {
                Iterator = updatedPosition;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            Iterator = 0;
        }

        public T Current { get; }

        object? IEnumerator.Current => Current;

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public void Add(T item)
        {
            if (!this.Contains(item))
            {
                Set.Add(item);
            }
        }

        public void Clear()
        {
            Set.Clear();
        }

        public bool Contains(T item)
        {
            return Set.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Set.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return Set.Remove(item);
        }
    }
}