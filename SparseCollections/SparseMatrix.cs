// Copyright (c) 2019 Jonathan Wood (www.softcircuits.com)
// Licensed under the MIT license.
//
using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftCircuits.SparseCollections
{
    public class SparseMatrix<T>
    {
        /// <summary>
        /// Internal data.
        /// </summary>
        private Dictionary<long, T> Data;

        /// <summary>
        /// The default value returned for an empty position.
        /// </summary>
        public T DefaultValue { get; set; }

        /// <summary>
        /// Constructs a new SparseMatrix instance.
        /// </summary>
        public SparseMatrix()
        {
            Data = new Dictionary<long, T>();
            DefaultValue = default;
        }

        /// <summary>
        /// Gets or sets the specified item.
        /// </summary>
        /// <param name="row">Item row position.</param>
        /// <param name="col">Item column position.</param>
        /// <returns>The item at the specified position, or the default value if the
        /// position is empty.</returns>
        public T this[int row, int col]
        {
            get => Data.TryGetValue(ToKey(row, col), out T item) ? item : DefaultValue;
            set => Data[ToKey(row, col)] = value;
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
        /// <param name="row">Item row position.</param>
        /// <param name="col">Item column position.</param>
        /// <returns>True if successful, false if the specified item didn't exist.</returns>
        public bool RemoveAt(int row, int col) => Data.Remove(ToKey(row, col));

        /// <summary>
        /// Returns all items from this collection.
        /// </summary>
        /// <returns>All items from this collection.</returns>
        public IEnumerable<T> GetItems() => Data.Values;

        /// <summary>
        /// Returns all the row, column indices that refer to non-empty items.
        /// </summary>
        /// <returns>All the row, column indices that refer to non-empty items.</returns>
        public IEnumerable<(int Row, int Col)> GetIndices() => Data.Keys.Select(k => (ToRow(k), ToColumn(k)));

        #region Helper methods

        private long ToKey(Int32 row, Int32 col) => ((Int64)row << 32) | ((Int64)col & 0xffffffff);
        private int ToRow(Int64 key) => (Int32)(key >> 32);
        private int ToColumn(Int64 key) => (Int32)(key & 0xffffffff);

        #endregion

    }
}
