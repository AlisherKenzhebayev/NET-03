using System.Collections;
using System.Collections.Generic;

namespace U10_GenericsCollections
{
    public abstract class IteratorAggregate<T> : IEnumerable
    {
        public abstract IEnumerator GetEnumerator();
    }
}