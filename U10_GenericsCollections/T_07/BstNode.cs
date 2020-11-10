// <copyright file="BstNode.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace U10_GenericsCollections.T_07
{
    public class BstNode<T>
    {
        public BstNode(T root)
        {
            this.TValue = root;
        }

        public T TValue { get; set; }
    }
}
