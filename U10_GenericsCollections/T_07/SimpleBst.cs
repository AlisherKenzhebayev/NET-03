// <copyright file="SimpleBst.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace U10_GenericsCollections.T_07
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SimpleBst<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        public SimpleBst(T[] input)
        {
            foreach (var item in input)
            {
                this.Insert(item);
            }
        }

        public SimpleBst()
        {
            this.Node = null;
            this.Left ??= null;
            this.Right ??= null;
            this.Enumerator = this.TransverseOrder;
        }

        public SimpleBst(T root)
        {
            this.Node = new BstNode<T>(root);
            this.Left ??= null;
            this.Right ??= null;
            this.Enumerator = this.TransverseOrder;
        }

        public delegate IEnumerator<T> BstEnumerator();

        public BstEnumerator Enumerator { get; set; }

        public SimpleBst<T> Left { get; private set; }

        public BstNode<T> Node { get; private set; }

        public SimpleBst<T> Right { get; private set; }

        public IComparer<T> Comparer { get; set; }

        public SimpleBst<T> Find(T search)
        {
            return this.Search(search);
        }

        public bool Add(T item)
        {
            return this.Insert(item);
        }

        public bool Remove(T item)
        {
            return this.Delete(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.Enumerator.Invoke();
        }

        public IEnumerator<T> TransverseOrder()
        {
            if (!(this.Left is null))
            {
                foreach (T item in this.Left)
                {
                    yield return item;
                }
            }

            if (this.Node != null)
            {
                yield return this.Node.TValue;
            }

            if (!(this.Right is null))
            {
                foreach (T item in this.Right)
                {
                    yield return item;
                }
            }
        }

        public IEnumerator<T> DirectOrder()
        {
            if (this.Node != null)
            {
                yield return this.Node.TValue;
            }

            if (!(this.Left is null))
            {
                foreach (T item in this.Left)
                {
                    yield return item;
                }
            }

            if (!(this.Right is null))
            {
                foreach (T item in this.Right)
                {
                    yield return item;
                }
            }
        }

        public IEnumerator<T> ReverseOrder()
        {
            if (!(this.Right is null))
            {
                foreach (T item in this.Right)
                {
                    yield return item;
                }
            }

            if (this.Node != null)
            {
                yield return this.Node.TValue;
            }

            if (!(this.Left is null))
            {
                foreach (T item in this.Left)
                {
                    yield return item;
                }
            }
        }

        public override string ToString()
        {
            var retStr = string.Empty;
            foreach (var item in this)
            {
                Console.WriteLine(item);
                retStr += item + " ";
            }

            return retStr;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private bool Insert(T item)
        {
            if (this.Node is null)
            {
                this.Node = new BstNode<T>(item);
                return true;
            }
            else
            {
                var c = this.Compare(item, this.Node.TValue);
                if (c >= 0)
                {
                    if (this.Right is null)
                    {
                        this.Right = new SimpleBst<T>(item);
                        return true;
                    }

                    return this.Right.Insert(item);
                }

                if (this.Left is null)
                {
                    this.Left = new SimpleBst<T>(item);
                    return true;
                }

                return this.Left.Insert(item);
            }
        }

        private SimpleBst<T> Search(T search)
        {
            if (this.Node is null)
            {
                return null;
            }
            else
            {
                var c = this.Compare(search, this.Node.TValue);
                if (c == 0)
                {
                    return this;
                }

                if (c > 0)
                {
                    if (this.Right != null)
                    {
                        return this.Right.Search(search);
                    }
                }

                if (c < 0)
                {
                    if (this.Left != null)
                    {
                        return this.Left.Search(search);
                    }
                }
            }

            return null;
        }

        private bool Delete(T item)
        {
            var f = this.Search(item);
            if (f.Equals(null))
            {
                return false;
            }

            SimpleBst<T> t = this.CopyToNoRoot(f);

            f.Node = null;
            f.Right = null;
            f.Left = null;
            if (t != null)
            {
                foreach (var i in t)
                {
                    this.Insert(i);
                }
            }

            return true;
        }

        private int Compare(T target, T compareTo)
        {
            if (this.Comparer is null)
            {
                return target.CompareTo(compareTo);
            }
            else
            {
                return this.Comparer.Compare(target, compareTo);
            }
        }

        private SimpleBst<T> CopyToNoRoot(SimpleBst<T> oldBST)
        {
            SimpleBst<T> newBST = null;
            foreach (var item in oldBST)
            {
                if (item.Equals(oldBST.Node.TValue))
                {
                    continue;
                }

                if (newBST == null)
                {
                    newBST = new SimpleBst<T>(item);
                    continue;
                }

                newBST.Insert(item);
            }

            return newBST;
        }
    }
}
