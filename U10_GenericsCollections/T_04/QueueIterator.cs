// <copyright file="QueueIterator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace U10_GenericsCollections.T_04
{
    public class QueueIterator<T> : Iterator<T>
    {
        private CollectionQueue<T> _collection;
        private int _position = -1;

        public QueueIterator(CollectionQueue<T> collection)
        {
            this._collection = collection;
        }

        public override bool MoveNext()
        {
            var updatedPosition = this._position + 1;

            if (updatedPosition >= 0 && updatedPosition < this._collection.GetItems().Count)
            {
                this._position = updatedPosition;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Reset()
        {
            this._position = 0;
        }

        public override T Current()
        {
            return this._collection.GetItems()[this._position];
        }
    }
}