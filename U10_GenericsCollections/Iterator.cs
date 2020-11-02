// <copyright file="Iterator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace U10_GenericsCollections
{
    using System.Collections;
    using System.Collections.Generic;

    public abstract class Iterator<T> : IEnumerator
    {
        object? IEnumerator.Current
        {
            get
            {
                return this.Current();
            }
        }

        public abstract bool MoveNext();

        public abstract void Reset();

        public abstract T Current();
    }
}