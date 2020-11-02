// <copyright file="CollectionSet.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace U10_GenericsCollections.T_06
{
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.Design;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public class CollectionSet<T> : IEnumerable<T>
    {
        public CollectionSet()
        {
            this.Set = new List<T>();
        }

        public int Count => this.Set.Count();

        public bool IsReadOnly => this.Set.IsReadOnly;

        private IList<T> Set { get; set; }

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = 0; i < this.Set.Count; i++)
            {
                yield return this.Set[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Add(T item)
        {
            if (!this.Contains(item))
            {
                this.Set.Add(item);
            }
        }

        public void Clear()
        {
            this.Set.Clear();
        }

        public bool Contains(T item)
        {
            return this.Set.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            this.Set.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return this.Set.Remove(item);
        }
    }
}