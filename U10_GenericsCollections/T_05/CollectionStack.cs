// <copyright file="CollectionStack.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

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
            this.Stack = new List<T>();
        }

        public int Count => this.Stack.Count;

        private IList<T> Stack { get; set; }

        public void Push(T item)
        {
            this.Stack.Add(item);
        }

        public bool IsEmpty()
        {
            return !this.Stack.Any();
        }

        public IList<T> GetItems()
        {
            return this.Stack;
        }

        public T Pop()
        {
            if (this.IsEmpty())
            {
                throw new Exception("Stack is empty");
            }

            var v = this.Stack.Last();
            this.Stack.Remove(v);
            return v;
        }

        public override IEnumerator GetEnumerator()
        {
            return new StackIterator<T>(this);
        }
    }
}