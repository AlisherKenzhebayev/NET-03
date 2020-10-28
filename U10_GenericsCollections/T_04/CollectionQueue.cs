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
            Queue = new List<T>();
        }

        private IList<T> Queue { get; set; }

        public int Count => Queue.Count;

        public void Enqueue(T item)
        {
            Queue.Add(item);
        }

        public bool IsEmpty()
        {
            return !Queue.Any();
        }

        public IList<T> GetItems()
        {
            return Queue;
        }

        public T Dequeue()
        {
            if (this.IsEmpty()) throw new Exception("Queue is empty");

            var v = Queue.GetEnumerator();
            v.MoveNext();
            var t = v.Current;
            Queue.Remove(t);
            v.Dispose();
            return t;
        }

        public override IEnumerator GetEnumerator()
        {
            return new QueueIterator<T>(this);
        }
    }
}