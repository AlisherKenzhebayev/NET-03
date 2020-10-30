namespace U10_GenericsCollections.T_05
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class CollectionStack<T> : IteratorAggregate<T>
    {
        public CollectionStack()
        {
            Stack = new List<T>();
        }

        public int Count => Stack.Count;

        private IList<T> Stack { get; set; }

        public void Push(T item)
        {
            Stack.Add(item);
        }

        public bool IsEmpty()
        {
            return !Stack.Any();
        }

        public IList<T> GetItems()
        {
            return Stack;
        }

        public T Pop()
        {
            if (this.IsEmpty()) throw new Exception("Stack is empty");

            var v = Stack.Last();
            Stack.Remove(v);
            return v;
        }

        public override IEnumerator GetEnumerator()
        {
            return new StackIterator<T>(this);
        }
    }
}