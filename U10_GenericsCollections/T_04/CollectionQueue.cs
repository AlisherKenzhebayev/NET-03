// <copyright file="CollectionQueue.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace U10_GenericsCollections.T_04
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class CollectionQueue<T> : IteratorAggregate<T>
    {
        public CollectionQueue()
        {
            this.Queue = new List<T>();
        }

        public int Count => this.Queue.Count;

        private IList<T> Queue { get; set; }

        public void Enqueue(T item)
        {
            this.Queue.Add(item);
        }

        public bool IsEmpty()
        {
            return !this.Queue.Any();
        }

        public IList<T> GetItems()
        {
            return this.Queue;
        }

        public T Dequeue()
        {
            if (this.IsEmpty())
            {
                throw new Exception("Queue is empty");
            }

            var v = this.Queue.GetEnumerator();
            v.MoveNext();
            var t = v.Current;
            this.Queue.Remove(t);
            v.Dispose();
            return t;
        }

        public override IEnumerator GetEnumerator()
        {
            return new QueueIterator<T>(this);
        }
    }
}