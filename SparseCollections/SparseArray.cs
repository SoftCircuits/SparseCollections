// Copyright (c) 2019-2025 Jonathan Wood (www.softcircuits.com)
// Licensed under the MIT license.
//
using System.Collections.Generic;

namespace SoftCircuits.SparseCollections
{
    /// <summary>
    /// Represents a sparse collection with an array interface.
    /// </summary>
    /// <typeparam name="T">Array type.</typeparam>
    /// <param name="defaultValue">Specifies the value returned for array
    /// positions that have no value.</param>
    public class SparseArray<T>(T? defaultValue = default)
    {
        /// <summary>
        /// Gets or sets the default value returned for empty positions.
        /// </summary>
        public T? DefaultValue { get; set; } = defaultValue;

        /// <summary>
        /// Internal data.
        /// </summary>
        private readonly Dictionary<int, T?> Data = [];

        /// <summary>
        /// Gets or sets the item at the specified index.
        /// </summary>
        /// <param name="index">Item index position.</param>
        /// <returns>The item at the specified position, or the default value if the
        /// position is empty.</returns>
        public T? this[int index]
        {
            get => Data.TryGetValue(index, out T? item) ? item : DefaultValue;
            set => Data[index] = value;
        }

        /// <summary>
        /// Gets the total number of items in this collection.
        /// </summary>
        public int Count => Data.Count;

        /// <summary>
        /// Clears all items from this collection.
        /// </summary>
        public void Clear() => Data.Clear();

        /// <summary>
        /// Removes the specified item from the collection.
        /// </summary>
        /// <param name="index">Item index position.</param>
        /// <returns>True if successful, false if the specified item didn't exist.</returns>
        public bool RemoveAt(int index) => Data.Remove(index);

        /// <summary>
        /// Returns all items from this collection.
        /// </summary>
        /// <returns>All items from this collection.</returns>
        public IEnumerable<T?> GetItems() => Data.Values;

        /// <summary>
        /// Returns all the array indexes that refer to non-empty items.
        /// </summary>
        /// <returns>All the array indexes that refer to non-empty items.</returns>
        public IEnumerable<int> GetIndexes() => Data.Keys;
    }
}
