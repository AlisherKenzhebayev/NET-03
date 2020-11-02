// <copyright file="IteratorAggregate.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace U10_GenericsCollections
{
    using System.Collections;
    using System.Collections.Generic;

    public abstract class IteratorAggregate<T> : IEnumerable
    {
        public abstract IEnumerator GetEnumerator();
    }
}