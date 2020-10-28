using System.Collections;
using System.Collections.Generic;

namespace U10_GenericsCollections
{
    public abstract class Iterator<T> : IEnumerator
    {
        public abstract bool MoveNext();

        public abstract void Reset();

        object? IEnumerator.Current
        {
            get
            {
                return Current();
            }
        }


        public abstract T Current();
    }
}