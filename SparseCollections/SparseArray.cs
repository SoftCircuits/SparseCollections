// Copyright (c) 2019 Jonathan Wood (www.softcircuits.com)
// Licensed under the MIT license.
//
using System.Collections.Generic;

namespace SoftCircuits.SparseCollections
{
    public class SparseArray<T>
    {
        /// <summary>
        /// Internal data.
        /// </summary>
        private Dictionary<int, T> Data;

        /// <summary>
        /// Constructs a new SparseArray instance.
        /// </summary>
        public SparseArray()
        {
            Data = new Dictionary<int, T>();
        }

        /// <summary>
        /// Gets or sets the specified item.
        /// </summary>
        /// <param name="index">Item position.</param>
        /// <returns>The item at the specified position, or default(T) if the position is empty.</returns>
        public T this[int index]
        {
            get => Data.TryGetValue(index, out T item) ? item : default;
            set => Data[index] = value;
        }

        /// <summary>
        /// Gets the total number of items in this collection.
        /// </summary>
        public int Count => Data.Count;

        /// <summary>
        /// Clears all items from this collection.
        /// </summary>
        public void Clear()
        {
            Data.Clear();
        }

        /// <summary>
        /// Removes the specified item from the collection.
        /// </summary>
        /// <param name="index">Item position.</param>
        /// <returns>True if successful, false if the specified item didn't exist.</returns>
        public bool RemoveAt(int index) => Data.Remove(index);

        /// <summary>
        /// Returns all items from this collection.
        /// </summary>
        /// <returns>All items from this collection.</returns>
        public IEnumerable<T> GetItems() => Data.Values;

        /// <summary>
        /// Returns all the indices that refer to non-empty items.
        /// </summary>
        /// <returns>All the indices that refer to non-empty items.</returns>
        public IEnumerable<int> GetIndices() => Data.Keys;
    }
}
